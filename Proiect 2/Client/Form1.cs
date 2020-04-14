using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using WMPLib;
//using MediaManager;
using System.Diagnostics;
using WCF;

namespace Client
{
    public partial class mmInterface : Form
    {
        private List<ComboBox> newAttributesList = new List<ComboBox>();
        private Dictionary<string, Media> searchResultsMap = new Dictionary<string, Media>();
        private List<string> addedPersons = new List<string>();
        private List<string> addedAttributes = new List<string>();
        MediaManagerClient mediaManagerProxy = new MediaManagerClient();

        public mmInterface()
        {
            InitializeComponent();
        }

        private void mmInterface_Load(object sender, EventArgs e)
        {
            this.newAttributesList.Add(attribute1_box);
            toolTip1.SetToolTip(persons_cmbBox, "To delete entry, type in the name again and press the \"add\" button.");
            toolTip1.SetToolTip(info_Box, "To modify an entry, fill in the desired path and the new characteristics,\n then press the \"Add\" button.");
            foreach (string element in Directory.GetFiles("..\\..\\Resources"))
            {
                Console.WriteLine(element);
            }
            info_Box.Image = Image.FromFile("..\\..\\Resources\\info.png");
        }

        //////////// First tab
        private void openFile_btn_Click(object sender, EventArgs e)
        {
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FileName = "Folder Selection.";
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            if (filename.EndsWith("Folder Selection"))
            {
                filename = Path.GetDirectoryName(openFileDialog.FileName);
            }

            if (Directory.Exists(filename))
            {
                if (addMediaToPath(filename))
                    path_CmbCox.SelectedIndex = 0;
            }
            else if (File.Exists(filename))
            {
                if (!path_CmbCox.Items.Contains(filename))
                {
                    if (API.fileType(filename) != "Unsupported")
                    {
                        path_CmbCox.Items.Add(filename);
                        path_CmbCox.SelectedIndex = 0;
                    }
                    else
                    {
                        setErrorMessage("File type unsupported", "media");
                    }
                }
                else
                {
                    setErrorMessage("File already added", "media");
                }
            }
            else
            {
                Console.WriteLine(filename);
                setErrorMessage("Invalid path", "media");
            }

            addedPersons = new List<string>(mediaManagerProxy.GetAllPersons());
            addedAttributes = new List<string>(mediaManagerProxy.GetAllAttributes());
        }

        private bool addMediaToPath(string filename)
        {
            bool addedAnElement = false;
            foreach (string file in Directory.GetFiles(filename))
            {
                if (API.fileType(file) != "Unsupported")
                {
                    if (!path_CmbCox.Items.Contains(file))
                    {
                        path_CmbCox.Items.Add(file);
                        addedAnElement = true;
                    }
                }
            }

            return addedAnElement;
        }

        private void path_CmbCox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = path_CmbCox.SelectedItem.ToString();

            if (mediaManagerProxy.GetMedia(filename) != null)
            {
                setErrorMessage("This media file will me modified after Add.", "add");
            }
            else
            {
                setErrorMessage("", "add");
            }

            switch (API.fileType(filename))
            {
                case "Image":
                    moviePreview_MediaPly.Visible = false;
                    moviePreview_MediaPly.Ctlcontrols.stop();
                    thumbnail_picBox.Visible = true;
                    thumbnail_picBox.Image = Image.FromFile(filename);
                    break;
                case "Video":
                    moviePreview_MediaPly.Visible = true;
                    thumbnail_picBox.Visible = false;
                    moviePreview_MediaPly.URL = filename;
                    break;
            }
        }

        private void addAttribute_btn_Click(object sender, EventArgs e)
        {
            /// Adauga dinamic un camp nou pentru atribute "custom". (Maxim: 6)
            if (String.IsNullOrWhiteSpace(this.newAttributesList[this.newAttributesList.Count - 1].Text))
            {
                return;
            }

            ComboBox newAttribute = new ComboBox();

            if (this.newAttributesList.Count != 3)
            {
                ComboBox lastAttribute = this.newAttributesList[this.newAttributesList.Count - 1];
                newAttribute.Font = new Font(newAttribute.Font.FontFamily, 10);
                newAttribute.Width = lastAttribute.Width;
                newAttribute.Location = lastAttribute.FindForm().PointToClient(lastAttribute.Parent.PointToScreen(lastAttribute.Location));
                newAttribute.Top += 5;
                newAttribute.Left -= 13;
                newAttribute.Name = "attribute" + this.newAttributesList.Count + "_box";

                newAttribute.BringToFront();
                addAttribute_btn.Top += 40;
                newAttribute.Parent = groupBox1;
                Debug.WriteLine(newAttribute.Parent);
                this.Controls.Add(newAttribute);
                addMedia_tab.Controls.Add(newAttribute);
                newAttribute.BringToFront();
                newAttributesList.Add(newAttribute);

                if (this.newAttributesList.Count > 5)
                {
                    addAttribute_btn.Visible = false;
                }
            }
            else
            {
                newAttribute.Font = new Font(newAttribute.Font.FontFamily, 10);
                newAttribute.Width = attribute1_box.Width;
                newAttribute.Location = this.attribute1_box.FindForm().PointToClient(this.attribute1_box.Parent.PointToScreen(this.attribute1_box.Location));
                newAttribute.Left += 427;
                addAttribute_btn.Top = 50;
                addAttribute_btn.Left = newAttribute.Left + 125;
                newAttribute.Parent = groupBox1;
                this.Controls.Add(newAttribute);
                newAttribute.BringToFront();
                newAttributesList.Add(newAttribute);
            }
        }

        private void addPerson_btn_Click(object sender, EventArgs e)
        {
            string person = persons_cmbBox.Text;

            if (String.IsNullOrWhiteSpace(person))
                return;

            if (persons_cmbBox.Items.Contains(person))
            {
                this.addedPersons.Remove(person);
                persons_cmbBox.Items.Remove(person);
            }
            else
            {
                this.addedPersons.Add(person);
                persons_cmbBox.Items.Add(person);
            }
            persons_cmbBox.Text = "";
        }

        private void addMedia_btn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(path_CmbCox.Text))
            {
                setErrorMessage("No media selected.", "media");
                return;
            }

            Media mediaToAdd = new Media();

            string mediaPath = path_CmbCox.SelectedItem.ToString();
            string mediaLocation = location_txt.Text;
            string mediaEvent = event_txt.Text;

            if(location_txt.Text == null)
            {

            }


            List<string> mediaPersons = new List<string>();
            foreach (object item in persons_cmbBox.Items)
            {
                mediaPersons.Add(item.ToString());
            }

            List<string> mediaAttributes = new List<string>();
            foreach (ComboBox att in newAttributesList)
            {
                if (att.Text != null)
                {
                    mediaAttributes.Add(att.Text);
                }
            }

            mediaToAdd.Path = mediaPath;

            if (addLocationToMedia(mediaToAdd, mediaLocation) == false)
                return;

            if (addEventToMedia(mediaToAdd, mediaEvent) == false)
                return;

            List<Person> associatedPersons = new List<Person>();
            associatedPersons = getAssociatedPersons(mediaPersons, associatedPersons);

            List<CustomAttributes> associatedAttributes = new List<CustomAttributes>();
            associatedAttributes = getAssociatedAttributes(mediaAttributes, associatedAttributes);

            mediaToAdd.ModifiedAt = DateTime.Now;
            mediaToAdd.CreatedAt = DateTime.Now;
            switch (API.fileType(mediaToAdd.Path))
            {
                case "Image":
                    mediaToAdd.MediaType = WCF.MediaType.Photo;
                    break;
                case "Video":
                    mediaToAdd.MediaType = WCF.MediaType.Video;
                    break;
            }

            bool succes = mediaManagerProxy.AddMedia(mediaToAdd, associatedPersons.ToArray(), associatedAttributes.ToArray());
            if (!succes)
            {
                setErrorMessage("The media could not be added.", "add");
                return;
            }
            else
            {
                var Msg = "The media was added.";
                MessageBox.Show(Msg);
            }

            clearTab1(mediaPath);
        }

        private void clearTab1(string mediaPath)
        {
            path_CmbCox.Items.Remove(mediaPath);
            location_txt.Text = "";
            event_txt.Text = "";
            persons_cmbBox.Items.Clear();
            moviePreview_MediaPly.Visible = false;
            thumbnail_picBox.Visible = false;
            moviePreview_MediaPly.Ctlcontrols.stop();
            moviePreview_MediaPly.Visible = false;
            ResetCustomAttributes();
        }

        private List<CustomAttributes> getAssociatedAttributes(List<string> mediaAttributes, List<CustomAttributes> associatedAttributes)
        {
            foreach (string attributeDescription in mediaAttributes)
            {
                if (attributeDescription.Any())
                {
                    CustomAttributes attribute = mediaManagerProxy.GetAttributeByDescription(attributeDescription);
                    if (attribute == null)
                    {
                        attribute = new CustomAttributes();
                        attribute.Description = attributeDescription;
                        if (!mediaManagerProxy.AddCustomAttribute(attribute))
                        {
                            setErrorMessage("Attribute " + attributeDescription + " could not be added.", "add");
                            return null;
                        }
                        attribute = mediaManagerProxy.GetAttributeByDescription(attributeDescription);
                    }
                    associatedAttributes.Add(attribute);
                }
            }

            return associatedAttributes;
        }

        private List<Person> getAssociatedPersons(List<string> mediaPersons, List<Person> associatedPersons)
        {
            foreach (string personName in mediaPersons)
            {
                Person person = mediaManagerProxy.GetPersonByName(personName);
                if (person == null)
                {
                    person = new Person();
                    person.Name = personName;
                    bool success = mediaManagerProxy.AddPerson(person);
                    if (!success)
                    {
                        setErrorMessage("Person " + personName + " could not be added.", "add");
                        return null;
                    }
                    person = mediaManagerProxy.GetPersonByName(personName);

                }
                associatedPersons.Add(person);
            }

            return associatedPersons;
        }

        private bool addEventToMedia(Media mediaToAdd, string mediaEvent)
        {
            if (mediaEvent.Any())
            {
                Event mEvent = mediaManagerProxy.GetEventByName(mediaEvent);
                if (mEvent == null)
                {
                    mEvent = new Event();
                    mEvent.Name = mediaEvent;
                    if (!mediaManagerProxy.AddEvent(mEvent))
                    {
                        setErrorMessage("The event you entered could not be added.", "add");
                        return false;
                    }
                    mEvent = mediaManagerProxy.GetEventByName(mediaEvent);

                }

                mediaToAdd.Event = mEvent;
                mediaToAdd.EventEventID = mEvent.EventID;
            }
            else
            {
                setErrorMessage("You have not entered an event.", "add");
                return false;
            }

            return true;
        }

        private bool addLocationToMedia(Media mediaToAdd, string mediaLocation)
        {
            if (mediaLocation.Any())
            {
                Location location = mediaManagerProxy.GetLocationByName(mediaLocation);
                if (location == null)
                {
                    location = new Location();
                    location.Name = mediaLocation;
                    if (!mediaManagerProxy.AddLocation(location))
                    {
                        setErrorMessage("The location you entered could not be added.", "add");
                        return false;
                    }

                    location = mediaManagerProxy.GetLocationByName(mediaLocation);
                }

                mediaToAdd.Location = location;
                mediaToAdd.LocationLocationID = location.LocationID;
            }
            else
            {
                setErrorMessage("You have not entered a location.", "add");
                return false;
            }

            return true;
        }

        private void ResetCustomAttributes()
        {
            foreach(var attribute in newAttributesList)
            {
                if (newAttributesList.IndexOf(attribute) != 0)
                {
                    this.Controls.Remove(attribute);
                    attribute.Dispose();
                }
            }

            newAttributesList.Clear();
            newAttributesList.Add(attribute1_box);

            addAttribute_btn.Location = new Point(254, 50);
            attribute1_box.Text = "";
        }

        private void setErrorMessage(string error, string type)
        {
            switch (type)
            {
                case "media":
                    mediaError_lbl.Text = error;
                    addHideErrorHandlerToControls(this);
                    break;
                case "add":
                    addError_lbl.Text = error;
                    addHideErrorHandlerToControls(this);
                    break;
            }
        }

        private void hideErrorMessage(object sender, EventArgs e)
        {
            Console.WriteLine("Event");
            mediaError_lbl.Text = "";
            removeHideErrorHandlerToControls(this);
        }

        private void addHideErrorHandlerToControls(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                c.Click += new EventHandler(hideErrorMessage);
                addHideErrorHandlerToControls(c);
            }
        }

        private void removeHideErrorHandlerToControls(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                c.Click -= new EventHandler(hideErrorMessage);
                removeHideErrorHandlerToControls(c);
            }
        }
        //////////////////////

        /////////// Second tab
        private void search_btn_Click(object sender, EventArgs e)
        {
            clearTab2();

            List<Media> searchResults = mediaManagerProxy.SearchInDB(search_txt.Text).ToList();
            Console.WriteLine("Rezultat: " + searchResults.Count);
            foreach(Media m in searchResults)
            {
                Console.WriteLine("Path: " + m.Path);
            }
            if (searchResults.Any())
            {
                initializeSearchResults((searchResults));
            }
        }

        private void clearTab2()
        {
            searchResults_cmbBox.Items.Clear();
            movie_MediaPly.Ctlcontrols.stop();
            movie_MediaPly.Visible = false;
            thumbnail_pixBox2.Visible = false;
            location2_txt.Text = "";
            event2_txt.Text = "";
            persons2_cmbBox.Items.Clear();
            attribute2_cmbBox.Items.Clear();
            this.searchResultsMap.Clear();
        }

        private void initializeSearchResults(List<Media> searchResults)
        {
            foreach (Media result in searchResults)
            {
                searchResults_cmbBox.Items.Add(result.Path);
                this.searchResultsMap.Add(result.Path, result);
            }
            if (searchResults_cmbBox.Items.Count > 0)
                searchResults_cmbBox.SelectedIndex = 0;
        }

        private void searchResults_cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Media selectedMedia = this.searchResultsMap[searchResults_cmbBox.SelectedItem.ToString()];
            location2_txt.Text = selectedMedia.Location.Name.ToString();
            event2_txt.Text = selectedMedia.Event.Name.ToString();
            persons2_cmbBox.Items.Clear();
            attribute2_cmbBox.Items.Clear();

            foreach (Person person in selectedMedia.People)
            {
                persons2_cmbBox.Items.Add(person.Name);
            }
            if(persons2_cmbBox.Items.Count > 0)
                persons2_cmbBox.SelectedIndex = 0;

            foreach (CustomAttributes attribute in selectedMedia.CustomAttributes)
            {
                attribute2_cmbBox.Items.Add(attribute.Description);
            }
            if(attribute2_cmbBox.Items.Count > 0)
                attribute2_cmbBox.SelectedIndex = 0;

            switch (selectedMedia.MediaType)
            {
                case MediaType.Photo:
                    movie_MediaPly.Visible = false;
                    movie_MediaPly.Ctlcontrols.stop();
                    thumbnail_pixBox2.Visible = true;
                    thumbnail_pixBox2.Image = Image.FromFile(selectedMedia.Path);
                    break;

                case MediaType.Video:
                    movie_MediaPly.Visible = true;
                    thumbnail_pixBox2.Visible = false;
                    movie_MediaPly.URL = selectedMedia.Path;
                    break;
            }

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            Media selectedMedia = this.searchResultsMap[searchResults_cmbBox.SelectedItem.ToString()];

            if(mediaManagerProxy.DeleteMedia(selectedMedia) == 0)
            {
                string messageText = "The media could not be deleted.";
                MessageBox.Show(messageText);
                return;
            }

            searchResultsMap.Remove(selectedMedia.Path);
            searchResults_cmbBox.Items.Remove(selectedMedia.Path);
            Dictionary<String, Media> auxSearchResultsMap = new Dictionary<string, Media>(searchResultsMap);
            clearTab2();
            searchResultsMap = new Dictionary<string, Media>(auxSearchResultsMap);
            foreach(Media media in searchResultsMap.Values)
            {
                searchResults_cmbBox.Items.Add(media.Path);
            }
            if (searchResults_cmbBox.Items.Count > 0)
                searchResults_cmbBox.SelectedIndex = 0;
            string message = "The media was deleted.";
            MessageBox.Show(message);
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    movie_MediaPly.Ctlcontrols.stop();
                    break;
                case 1:
                    moviePreview_MediaPly.Ctlcontrols.stop();
                    break;
            }
        }


        //////////////////////
    }
}
