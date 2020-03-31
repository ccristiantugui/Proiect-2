using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using WCF;

namespace ObjectWCF
{
    [ServiceContract]
    interface InterfaceMedia
    {
        [OperationContract]
        bool AddMedia(Media media);

        [OperationContract]
        bool UpdateMedia(Media media);

        [OperationContract]
        int DeleteMedia(Media media);

        [OperationContract]
        List<Media> SearchInDB(String searchKey);

        [OperationContract]
        List<ICollection<Person>> GetPeopleFromMedia(Media media);

        [OperationContract]
        List<ICollection<CustomAttributes>> GetCustomAttributesFromMedia(Media media);
    }

    [ServiceContract]
    interface InterfaceLocation
    {
        [OperationContract]
        bool AddLocation(Location location);
    }

    [ServiceContract]
    interface InterfaceEvent
    { 
        [OperationContract]
        bool AddEvent(Event mediaEvent);
    }

    [ServiceContract]
    interface InterfacePerson
    {
        [OperationContract]
        bool AddPerson(Person person);
    }

    [ServiceContract]
    interface InterfaceCustomAttributes
    {
        [OperationContract]
        bool AddCustomAttribute(CustomAttributes customAttribute);
    }

    [ServiceContract]
    interface IMediaManager: InterfaceMedia, InterfaceCustomAttributes, InterfaceEvent, InterfaceLocation, InterfacePerson
    {
    }
}
