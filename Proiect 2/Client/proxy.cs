﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Media", Namespace = "http://schemas.datacontract.org/2004/07/WCF", IsReference = true)]
    public partial class Media : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private System.DateTime CreatedAtField;

        private WCF.CustomAttributes[] CustomAttributesField;

        private WCF.Event EventField;

        private int EventEventIDField;

        private WCF.Location LocationField;

        private int LocationLocationIDField;

        private int MediaIDField;

        private WCF.MediaType MediaTypeField;

        private System.DateTime ModifiedAtField;

        private string PathField;

        private WCF.Person[] PeopleField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.CreatedAtField;
            }
            set
            {
                this.CreatedAtField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.CustomAttributes[] CustomAttributes
        {
            get
            {
                return this.CustomAttributesField;
            }
            set
            {
                this.CustomAttributesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Event Event
        {
            get
            {
                return this.EventField;
            }
            set
            {
                this.EventField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EventEventID
        {
            get
            {
                return this.EventEventIDField;
            }
            set
            {
                this.EventEventIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Location Location
        {
            get
            {
                return this.LocationField;
            }
            set
            {
                this.LocationField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LocationLocationID
        {
            get
            {
                return this.LocationLocationIDField;
            }
            set
            {
                this.LocationLocationIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MediaID
        {
            get
            {
                return this.MediaIDField;
            }
            set
            {
                this.MediaIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.MediaType MediaType
        {
            get
            {
                return this.MediaTypeField;
            }
            set
            {
                this.MediaTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifiedAt
        {
            get
            {
                return this.ModifiedAtField;
            }
            set
            {
                this.ModifiedAtField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Path
        {
            get
            {
                return this.PathField;
            }
            set
            {
                this.PathField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Person[] People
        {
            get
            {
                return this.PeopleField;
            }
            set
            {
                this.PeopleField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Event", Namespace = "http://schemas.datacontract.org/2004/07/WCF", IsReference = true)]
    public partial class Event : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int EventIDField;

        private WCF.Media[] MediaField;

        private string NameField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EventID
        {
            get
            {
                return this.EventIDField;
            }
            set
            {
                this.EventIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Media[] Media
        {
            get
            {
                return this.MediaField;
            }
            set
            {
                this.MediaField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Location", Namespace = "http://schemas.datacontract.org/2004/07/WCF", IsReference = true)]
    public partial class Location : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int LocationIDField;

        private WCF.Media[] MediaField;

        private string NameField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LocationID
        {
            get
            {
                return this.LocationIDField;
            }
            set
            {
                this.LocationIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Media[] Media
        {
            get
            {
                return this.MediaField;
            }
            set
            {
                this.MediaField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "CustomAttributes", Namespace = "http://schemas.datacontract.org/2004/07/WCF", IsReference = true)]
    public partial class CustomAttributes : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int CustomAttributeIDField;

        private string DescriptionField;

        private WCF.Media[] MediaField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CustomAttributeID
        {
            get
            {
                return this.CustomAttributeIDField;
            }
            set
            {
                this.CustomAttributeIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Media[] Media
        {
            get
            {
                return this.MediaField;
            }
            set
            {
                this.MediaField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MediaType", Namespace = "http://schemas.datacontract.org/2004/07/WCF")]
    public enum MediaType : int
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Photo = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Video = 1,
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Person", Namespace = "http://schemas.datacontract.org/2004/07/WCF", IsReference = true)]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private WCF.Media[] MediaField;

        private string NameField;

        private int PersonIDField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCF.Media[] Media
        {
            get
            {
                return this.MediaField;
            }
            set
            {
                this.MediaField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PersonID
        {
            get
            {
                return this.PersonIDField;
            }
            set
            {
                this.PersonIDField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IMediaManager")]
public interface IMediaManager
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/AddMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/AddMediaResponse")]
    bool AddMedia(WCF.Media media, WCF.Person[] people, WCF.CustomAttributes[] customAttributes);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/AddMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/AddMediaResponse")]
    System.Threading.Tasks.Task<bool> AddMediaAsync(WCF.Media media, WCF.Person[] people, WCF.CustomAttributes[] customAttributes);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/UpdateMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/UpdateMediaResponse")]
    bool UpdateMedia(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/UpdateMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/UpdateMediaResponse")]
    System.Threading.Tasks.Task<bool> UpdateMediaAsync(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/DeleteMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/DeleteMediaResponse")]
    int DeleteMedia(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/DeleteMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/DeleteMediaResponse")]
    System.Threading.Tasks.Task<int> DeleteMediaAsync(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/SearchInDB", ReplyAction = "http://tempuri.org/InterfaceMedia/SearchInDBResponse")]
    WCF.Media[] SearchInDB(string searchKey);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/SearchInDB", ReplyAction = "http://tempuri.org/InterfaceMedia/SearchInDBResponse")]
    System.Threading.Tasks.Task<WCF.Media[]> SearchInDBAsync(string searchKey);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/GetPeopleFromMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/GetPeopleFromMediaResponse")]
    WCF.Person[] GetPeopleFromMedia(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/GetPeopleFromMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/GetPeopleFromMediaResponse")]
    System.Threading.Tasks.Task<WCF.Person[]> GetPeopleFromMediaAsync(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/GetCustomAttributesFromMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/GetCustomAttributesFromMediaResponse")]
    WCF.CustomAttributes[] GetCustomAttributesFromMedia(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceMedia/GetCustomAttributesFromMedia", ReplyAction = "http://tempuri.org/InterfaceMedia/GetCustomAttributesFromMediaResponse")]
    System.Threading.Tasks.Task<WCF.CustomAttributes[]> GetCustomAttributesFromMediaAsync(WCF.Media media);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceCustomAttributes/AddCustomAttribute", ReplyAction = "http://tempuri.org/InterfaceCustomAttributes/AddCustomAttributeResponse")]
    bool AddCustomAttribute(WCF.CustomAttributes customAttribute);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceCustomAttributes/AddCustomAttribute", ReplyAction = "http://tempuri.org/InterfaceCustomAttributes/AddCustomAttributeResponse")]
    System.Threading.Tasks.Task<bool> AddCustomAttributeAsync(WCF.CustomAttributes customAttribute);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceCustomAttributes/GetAllAttributes", ReplyAction = "http://tempuri.org/InterfaceCustomAttributes/GetAllAttributesResponse")]
    string[] GetAllAttributes();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceCustomAttributes/GetAllAttributes", ReplyAction = "http://tempuri.org/InterfaceCustomAttributes/GetAllAttributesResponse")]
    System.Threading.Tasks.Task<string[]> GetAllAttributesAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceCustomAttributes/GetAttributeByDescription", ReplyAction = "http://tempuri.org/InterfaceCustomAttributes/GetAttributeByDescriptionResponse")]
    WCF.CustomAttributes GetAttributeByDescription(string description);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceCustomAttributes/GetAttributeByDescription", ReplyAction = "http://tempuri.org/InterfaceCustomAttributes/GetAttributeByDescriptionResponse")]
    System.Threading.Tasks.Task<WCF.CustomAttributes> GetAttributeByDescriptionAsync(string description);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceEvent/AddEvent", ReplyAction = "http://tempuri.org/InterfaceEvent/AddEventResponse")]
    bool AddEvent(WCF.Event mediaEvent);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceEvent/AddEvent", ReplyAction = "http://tempuri.org/InterfaceEvent/AddEventResponse")]
    System.Threading.Tasks.Task<bool> AddEventAsync(WCF.Event mediaEvent);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceEvent/GetEventByName", ReplyAction = "http://tempuri.org/InterfaceEvent/GetEventByNameResponse")]
    WCF.Event GetEventByName(string name);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceEvent/GetEventByName", ReplyAction = "http://tempuri.org/InterfaceEvent/GetEventByNameResponse")]
    System.Threading.Tasks.Task<WCF.Event> GetEventByNameAsync(string name);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceLocation/AddLocation", ReplyAction = "http://tempuri.org/InterfaceLocation/AddLocationResponse")]
    bool AddLocation(WCF.Location location);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceLocation/AddLocation", ReplyAction = "http://tempuri.org/InterfaceLocation/AddLocationResponse")]
    System.Threading.Tasks.Task<bool> AddLocationAsync(WCF.Location location);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceLocation/GetLocationByName", ReplyAction = "http://tempuri.org/InterfaceLocation/GetLocationByNameResponse")]
    WCF.Location GetLocationByName(string name);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfaceLocation/GetLocationByName", ReplyAction = "http://tempuri.org/InterfaceLocation/GetLocationByNameResponse")]
    System.Threading.Tasks.Task<WCF.Location> GetLocationByNameAsync(string name);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfacePerson/AddPerson", ReplyAction = "http://tempuri.org/InterfacePerson/AddPersonResponse")]
    bool AddPerson(WCF.Person person);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfacePerson/AddPerson", ReplyAction = "http://tempuri.org/InterfacePerson/AddPersonResponse")]
    System.Threading.Tasks.Task<bool> AddPersonAsync(WCF.Person person);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfacePerson/GetAllPersons", ReplyAction = "http://tempuri.org/InterfacePerson/GetAllPersonsResponse")]
    string[] GetAllPersons();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfacePerson/GetAllPersons", ReplyAction = "http://tempuri.org/InterfacePerson/GetAllPersonsResponse")]
    System.Threading.Tasks.Task<string[]> GetAllPersonsAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfacePerson/GetPersonByName", ReplyAction = "http://tempuri.org/InterfacePerson/GetPersonByNameResponse")]
    WCF.Person GetPersonByName(string name);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/InterfacePerson/GetPersonByName", ReplyAction = "http://tempuri.org/InterfacePerson/GetPersonByNameResponse")]
    System.Threading.Tasks.Task<WCF.Person> GetPersonByNameAsync(string name);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IMediaManagerChannel : IMediaManager, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MediaManagerClient : System.ServiceModel.ClientBase<IMediaManager>, IMediaManager
{

    public MediaManagerClient()
    {
    }

    public MediaManagerClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public MediaManagerClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public MediaManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public MediaManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    public bool AddMedia(WCF.Media media, WCF.Person[] people, WCF.CustomAttributes[] customAttributes)
    {
        return base.Channel.AddMedia(media, people, customAttributes);
    }

    public System.Threading.Tasks.Task<bool> AddMediaAsync(WCF.Media media, WCF.Person[] people, WCF.CustomAttributes[] customAttributes)
    {
        return base.Channel.AddMediaAsync(media, people, customAttributes);
    }

    public bool UpdateMedia(WCF.Media media)
    {
        return base.Channel.UpdateMedia(media);
    }

    public System.Threading.Tasks.Task<bool> UpdateMediaAsync(WCF.Media media)
    {
        return base.Channel.UpdateMediaAsync(media);
    }

    public int DeleteMedia(WCF.Media media)
    {
        return base.Channel.DeleteMedia(media);
    }

    public System.Threading.Tasks.Task<int> DeleteMediaAsync(WCF.Media media)
    {
        return base.Channel.DeleteMediaAsync(media);
    }

    public WCF.Media[] SearchInDB(string searchKey)
    {
        return base.Channel.SearchInDB(searchKey);
    }

    public System.Threading.Tasks.Task<WCF.Media[]> SearchInDBAsync(string searchKey)
    {
        return base.Channel.SearchInDBAsync(searchKey);
    }

    public WCF.Person[] GetPeopleFromMedia(WCF.Media media)
    {
        return base.Channel.GetPeopleFromMedia(media);
    }

    public System.Threading.Tasks.Task<WCF.Person[]> GetPeopleFromMediaAsync(WCF.Media media)
    {
        return base.Channel.GetPeopleFromMediaAsync(media);
    }

    public WCF.CustomAttributes[] GetCustomAttributesFromMedia(WCF.Media media)
    {
        return base.Channel.GetCustomAttributesFromMedia(media);
    }

    public System.Threading.Tasks.Task<WCF.CustomAttributes[]> GetCustomAttributesFromMediaAsync(WCF.Media media)
    {
        return base.Channel.GetCustomAttributesFromMediaAsync(media);
    }

    public bool AddCustomAttribute(WCF.CustomAttributes customAttribute)
    {
        return base.Channel.AddCustomAttribute(customAttribute);
    }

    public System.Threading.Tasks.Task<bool> AddCustomAttributeAsync(WCF.CustomAttributes customAttribute)
    {
        return base.Channel.AddCustomAttributeAsync(customAttribute);
    }

    public string[] GetAllAttributes()
    {
        return base.Channel.GetAllAttributes();
    }

    public System.Threading.Tasks.Task<string[]> GetAllAttributesAsync()
    {
        return base.Channel.GetAllAttributesAsync();
    }

    public WCF.CustomAttributes GetAttributeByDescription(string description)
    {
        return base.Channel.GetAttributeByDescription(description);
    }

    public System.Threading.Tasks.Task<WCF.CustomAttributes> GetAttributeByDescriptionAsync(string description)
    {
        return base.Channel.GetAttributeByDescriptionAsync(description);
    }

    public bool AddEvent(WCF.Event mediaEvent)
    {
        return base.Channel.AddEvent(mediaEvent);
    }

    public System.Threading.Tasks.Task<bool> AddEventAsync(WCF.Event mediaEvent)
    {
        return base.Channel.AddEventAsync(mediaEvent);
    }

    public WCF.Event GetEventByName(string name)
    {
        return base.Channel.GetEventByName(name);
    }

    public System.Threading.Tasks.Task<WCF.Event> GetEventByNameAsync(string name)
    {
        return base.Channel.GetEventByNameAsync(name);
    }

    public bool AddLocation(WCF.Location location)
    {
        return base.Channel.AddLocation(location);
    }

    public System.Threading.Tasks.Task<bool> AddLocationAsync(WCF.Location location)
    {
        return base.Channel.AddLocationAsync(location);
    }

    public WCF.Location GetLocationByName(string name)
    {
        return base.Channel.GetLocationByName(name);
    }

    public System.Threading.Tasks.Task<WCF.Location> GetLocationByNameAsync(string name)
    {
        return base.Channel.GetLocationByNameAsync(name);
    }

    public bool AddPerson(WCF.Person person)
    {
        return base.Channel.AddPerson(person);
    }

    public System.Threading.Tasks.Task<bool> AddPersonAsync(WCF.Person person)
    {
        return base.Channel.AddPersonAsync(person);
    }

    public string[] GetAllPersons()
    {
        return base.Channel.GetAllPersons();
    }

    public System.Threading.Tasks.Task<string[]> GetAllPersonsAsync()
    {
        return base.Channel.GetAllPersonsAsync();
    }

    public WCF.Person GetPersonByName(string name)
    {
        return base.Channel.GetPersonByName(name);
    }

    public System.Threading.Tasks.Task<WCF.Person> GetPersonByNameAsync(string name)
    {
        return base.Channel.GetPersonByNameAsync(name);
    }
}
