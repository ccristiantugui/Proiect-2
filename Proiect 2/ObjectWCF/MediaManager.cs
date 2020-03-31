using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF;

namespace ObjectWCF
{
    public class MediaManager : IMediaManager
    {
        public bool AddCustomAttribute(CustomAttributes customAttribute)
        {
            return API.addCustomAttributeToDatabase(customAttribute);
        }

        public bool AddEvent(Event mediaEvent)
        {
            return API.addEventToDatabase(mediaEvent);
        }

        public bool AddLocation(Location location)
        {
            return API.addLocationToDatabase(location);
        }

        public bool AddMedia(Media media)
        {
            return API.addMediaToDatabase(media);
        }

        public bool AddPerson(Person person)
        {
            return API.addPersonToDatabase(person);
        }

        public int DeleteMedia(Media media)
        {
            return API.removeMediaFromDatabase(media.Path);
        }

        public List<ICollection<CustomAttributes>> GetCustomAttributesFromMedia(Media media)
        {
            return API.getCustomAttributesFromMedia(media);
        }

        public List<ICollection<Person>> GetPeopleFromMedia(Media media)
        {
            return API.getPersonsFromMedia(media);
        }

        public List<Media> SearchInDB(string searchKey)
        {
            return API.searchInDB(searchKey);
        }

        public bool UpdateMedia(Media media)
        {
            return API.updateMediaInDatabase(media);
        }
    }
}
