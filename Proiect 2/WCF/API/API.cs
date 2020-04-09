using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace WCF
{
    public static class API
    {

        public static List<string> getPersonsFromDB()
        {
            /// Returneaza lista de persoane existente in baza de date.

            using (MediaContainer ctx = new MediaContainer())
            {
                List<string> persons = new List<string>();
                var personsResults = (from p in ctx.People select p.Name);
                if (personsResults.Any())
                    persons = personsResults.ToList();
                return persons;
            }
        }

        public static List<string> getCustomAttributesFromDB()
        {
            /// Returneaza lista de atribute "custom" existente in baza de date.

            using (MediaContainer ctx = new MediaContainer())
            {
                List<string> attributes = new List<string>();
                var attributesResults = (from ca in ctx.CustomAttributes select ca.Description);
                if (attributesResults.Any())
                    attributes = attributesResults.ToList();
                return attributes;
            }
        }

        public static bool addMediaToDatabase(Media media, List<Person> people, List<CustomAttributes> customAttributes)
        {
            /// Adauga in baza de date o intrare cu valorile parametrilor. 
            /// Daca calea specificata se afla in baza de date, atunci datele vor fi modificate cu noii parametrii.
            /// Returneaza True pentru executie reusita sau False altfel.

            using (MediaContainer ctx = new MediaContainer())
            {
                if (media.MediaID == 0)
                {
                    try
                    {
                        var it = ctx.Entry<Media>(media).State = EntityState.Added;
                        //ctx.Media.Add(media);

                        Console.WriteLine(media.LocationLocationID);

                        //if (media.LocationLocationID != 0)
                        //{
                        //    Console.WriteLine(media.LocationLocationID);
                        //    Location l = ctx.Locations.Find(media.LocationLocationID);
                        //    Console.WriteLine(l);
                        //    l.Media.Add(media);
                        //    ctx.Entry<Location>(l).State = EntityState.Modified;
                        //}

                        //if (media.EventEventID != 0)
                        //{
                        //    Event e = ctx.Events.Find(media.EventEventID);
                        //    e.Media.Add(media);
                        //    ctx.Entry<Event>(e).State = EntityState.Modified;
                        //}

                        foreach (Person p in people)
                        {
                            if (media.People == null)
                            {
                                media.People = new List<Person>();
                            }
                            if (!media.People.Contains(p))
                            {
                                ctx.Entry<Person>(p).State = EntityState.Unchanged;
                                media.People.Add(p);
                            }
                        }

                        foreach (CustomAttributes custom in customAttributes)
                        {
                            if (custom.Description.Any())
                            {
                                if (media.CustomAttributes == null)
                                {
                                    media.CustomAttributes = new List<CustomAttributes>();
                                }
                                if (media.CustomAttributes.Contains(custom))
                                {
                                    ctx.Entry<CustomAttributes>(custom).State = EntityState.Unchanged;
                                    media.CustomAttributes.Add(custom);
                                }
                            }
                        }

                        Location location = ctx.Locations.Find(media.LocationLocationID);
                        ctx.Entry<Location>(location).State = EntityState.Unchanged;

                        Event mEvent = ctx.Events.Find(media.EventEventID);
                        ctx.Entry<Event>(mEvent).State = EntityState.Unchanged;

                        ctx.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                    return true;
                }
                else
                {
                    return updateMediaInDatabase(media);
                }
            }
        }

        public static bool updateMediaInDatabase(Media media)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                Media oldMedia = ctx.Media.Find(media.MediaID);

                if (oldMedia == null)
                {
                    return false;
                }
                else
                {
                    oldMedia.Path = media.Path;
                    oldMedia.MediaType = media.MediaType;
                    oldMedia.LocationLocationID = media.LocationLocationID;
                    oldMedia.EventEventID = media.EventEventID;
                    oldMedia.CustomAttributes = media.CustomAttributes;
                    ctx.SaveChanges();
                    return true;
                }
            }
        }

        public static int removeMediaFromDatabase(string path)
        {
            /// Sterge din baza de date intrarea cu calea specificata in parametrii.
            /// Returneaza True pentru executie reusita sau False altfel.

            using (MediaContainer ctx = new MediaContainer())
            {
                const string Sql = "Delete From Media where path = @p0";
                return ctx.Database.ExecuteSqlCommand(Sql, path);
            }
        }

        public static bool addLocationToDatabase(Location location)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                if (location.LocationID == 0)
                {
                    var it = ctx.Entry<Location>(location).State = EntityState.Added;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool addEventToDatabase(Event mediaEvent)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                if (mediaEvent.EventID == 0)
                {
                    var it = ctx.Entry<Event>(mediaEvent).State = EntityState.Added;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool addPersonToDatabase(Person person)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                if (person.PersonID == 0)
                {
                    ctx.People.Add(person);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool addCustomAttributeToDatabase(CustomAttributes customAttributes)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                if (customAttributes.CustomAttributeID == 0)
                {
                    ctx.CustomAttributes.Add(customAttributes);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static Media getMediaByPath(string path)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                var media = from m in ctx.Media where m.Path == path select m;
                return (Media)media;
            }
        }

        public static List<Media> searchInDB(string searchQuery)
        {
            /// Primeste un string ce contine cuvinte cheie.
            /// Returneaza o lista de obiecte de tip Media ce se potrivesc cautarii.

            using (MediaContainer ctx = new MediaContainer())
            {
                List<Media> foundMedia = new List<Media>();

                var media = from m in ctx.Media where m.Path.Contains(searchQuery) select m;
                if (media != null)
                {
                    foreach (Media m in media)
                    {
                        foundMedia.Add(m);
                    }
                }

                media = from m in ctx.Media where m.Location.Name.Contains(searchQuery) select m;
                if (media != null)
                {
                    foreach (Media m in media)
                    {
                        foundMedia.Add(m);
                    }
                }

                media = from m in ctx.Media where m.Event.Name.Contains(searchQuery) select m;
                if (media != null)
                {
                    foreach (Media m in media)
                    {
                        foundMedia.Add(m);
                    }
                }

                media = ctx.Media.Include(m => m.People.Where(p => p.Name.Contains(searchQuery)));
                if (media != null)
                {
                    foreach (Media m in media)
                    {
                        foundMedia.Add(m);
                    }
                }
                media = ctx.Media.Include(m => m.CustomAttributes.Where(ca => ca.Description.Contains(searchQuery)));
                if (media != null)
                {
                    foreach (Media m in media)
                    {
                        foundMedia.Add(m);
                    }
                }

                return foundMedia;
            }

        }

        public static List<Person> getPersonsFromMedia(Media media)
        {
            /// Primeste un obiect de tip media.
            /// Returneaza o lista a persoanelor asociate fisierului media.

            using (MediaContainer ctx = new MediaContainer())
            {
                var people = ctx.Media
                                .Where(m => m.MediaID == media.MediaID)
                                .Select(m => m.People)
                                .FirstOrDefault();

                return people.ToList();
            }
        }

        public static List<CustomAttributes> getCustomAttributesFromMedia(Media media)
        {
            /// Primeste un obiect de tip media.
            /// Returneaza o lista a atributelor de tip "custom" asociate fisierului media.

            using (MediaContainer ctx = new MediaContainer())
            {
                var customAttributes = ctx.Media
                                          .Where(m => m.MediaID == media.MediaID)
                                          .Select(m => m.CustomAttributes)
                                          .FirstOrDefault();

                return customAttributes.ToList();
            }
        }

        public static Location getLocationByName(string name)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                var location = ctx.Locations
                                   .Where(l => l.Name == name)
                                   .FirstOrDefault();

                if (location != null)
                {
                    Console.WriteLine(location.Name);
                }
                return location;
            }
        }

        public static Event getEventByName(string name)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                var mediaEvent = ctx.Events
                                    .Where(e => e.Name == name)
                                    .FirstOrDefault();

                return mediaEvent;
            }
        }

        public static Person getPersonByName(string name)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                //Person person = ctx.People
                //                .FirstOrDefault(p => p.Name == name);

                var result = from p in ctx.People where p.Name == name select p;

                if (result.Any())
                {
                    return result.First();
                }
                return null;
            }
        }

        public static CustomAttributes getAttributeByDescription(string description)
        {
            using (MediaContainer ctx = new MediaContainer())
            {
                var attribute = ctx.CustomAttributes
                                    .Where(a => a.Description == description)
                                    .FirstOrDefault();
                return attribute;
            }
        }
    }
}
