using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Data.Entity;

namespace WCF
{
    public static class API
    {
        static string[] imageExtensions = {
            ".PNG", ".JPG", ".JPEG", ".BMP"
        };
        static string[] movieExtensions = {
            ".AVI", ".MP4", ".DIVX", ".WMV"
        };

        public static string fileType(string path)
        {
            /// Verifica tipul continutului fisierului primit ca parametru.
            /// Returneaza "Image", "Video" sau "Unsupported", dupa caz.

            if (Array.IndexOf(imageExtensions, Path.GetExtension(path).ToUpperInvariant()) != -1)
            {
                return "Image";
            }
            else if (Array.IndexOf(movieExtensions, Path.GetExtension(path).ToUpperInvariant()) != -1)
            {
                return "Video";
            }

            return "Unsupported";
        }

        public static Bitmap getVideoThumbnail(string path)
        {
            // Extrage o imagine din video pentru "preview".
            // Returneaza o imagine.



            return null;
        }

        public static List<string> getPersonsFromDB()
        {
            /// Returneaza lista de persoane existente in baza de date.
            
            using (MediaContainer ctx = new MediaContainer())
            {
                var persons = (from p in ctx.People select p.Name).ToList();
                return persons;
            }    
        }

        public static List<string> getCustomAttributesFromDB()
        {
            /// Returneaza lista de atribute "custom" existente in baza de date.

            using (MediaContainer ctx = new MediaContainer())
            {
                var attributes = (from ca in ctx.CustomAttributes select ca.Description).ToList();
            }

            return null;
        }

        public static bool addMediaToDatabase(Media media)
        {
            /// Adauga in baza de date o intrare cu valorile parametrilor. 
            /// Daca calea specificata se afla in baza de date, atunci datele vor fi modificate cu noii parametrii.
            /// Returneaza True pentru executie reusita sau False altfel.

            using (MediaContainer ctx = new MediaContainer())
            {
                if (media.MediaID == 0)
                {
                    var it = ctx.Entry<Media>(media).State = EntityState.Added;
                    ctx.SaveChanges();
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

                if(oldMedia == null)
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
                if(location.LocationID == 0)
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
                    var it = ctx.Entry<Person>(person).State = EntityState.Added;
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
                if (customAttributes.AttributeID == 0)
                {
                    var it = ctx.Entry<CustomAttributes>(customAttributes).State = EntityState.Added;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
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
                    foreach(Media m in media)
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

        public static List<ICollection<Person>> getPersonsFromMedia(Media media)
        {
            /// Primeste un obiect de tip media.
            /// Returneaza o lista a persoanelor asociate fisierului media.
            
            using (MediaContainer ctx = new MediaContainer())
            {
                var persons = (from m in ctx.Media where (m.MediaID == media.MediaID) select m.People).ToList();
                return persons;
            }
        }

        public static List<ICollection<CustomAttributes>> getCustomAttributesFromMedia(Media media)
        {
            /// Primeste un obiect de tip media.
            /// Returneaza o lista a atributelor de tip "custom" asociate fisierului media.

            using (MediaContainer ctx = new MediaContainer())
            {
                var custom_attributes = (from m in ctx.Media where (m.MediaID == media.MediaID) select m.CustomAttributes).ToList();
                return custom_attributes;
            }
        }
    }
}
