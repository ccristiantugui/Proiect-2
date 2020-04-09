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
        //private Dictionary<string, Media> searchResultsMap = new Dictionary<string, Media>();
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
                        return;
                    }

                    location = mediaManagerProxy.GetLocationByName(mediaLocation);
                }

                mediaToAdd.Location = location;
                mediaToAdd.LocationLocationID = location.LocationID;
            }
            else
            {
                setErrorMessage("You have not entered a location.", "add");
                return;
            }

            if (mediaEvent.Any())
            {
                Event mEvent = mediaManagerProxy.GetEventByName(mediaEvent);
                if (mEvent == null)
                {
                    mEvent = new Event();
                    mEvent.Name = mediaEvent;
                    if (!mediaManagerProxy.AddEvent(mEvent))
                    {
                        setErrorMessage("The event youy entered could not be added.", "add");
                        return;
                    }
                    mEvent = mediaManagerProxy.GetEventByName(mediaEvent);

                }

                mediaToAdd.Event = mEvent;
                mediaToAdd.EventEventID = mEvent.EventID;
            }
            else
            {
                setErrorMessage("You have not entered an event.", "add");
                return;
            }

            List<Person> associatedPersons = new List<Person>();
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
                        return;
                    }
                    person = mediaManagerProxy.GetPersonByName(personName);

                }
                associatedPersons.Add(person);
            }

            List<CustomAttributes> associatedAttributes = new List<CustomAttributes>();
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
                            return;
                        }
                        attribute = mediaManagerProxy.GetAttributeByDescription(attributeDescription);
                    }
                    associatedAttributes.Add(attribute);
                }
            }


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

            path_CmbCox.Items.Remove(mediaPath);
            location_txt.Text = "";
            event_txt.Text = "";
            persons_cmbBox.Items.Clear();
            moviePreview_MediaPly.Visible = false;
            thumbnail_picBox.Visible = false;
            ResetCustomAttributes();
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
            //List<Media> searchResults = API.searchInDB(search_txt.Text);
            //if (!searchResults.Any())
            //{
            //    initializeSearchResults((searchResults));
            //}
        }

        private void initializeSearchResults(List<int> searchResults)
        {
            //foreach(Media result in searchResults)
            //{
            //    searchResults_cmbBox.Items.Add(result.Path);
            //    this.searchResultsMap.Add(result.Path, result);
            //}
        }

        private void searchResults_cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Media selectedMedia = this.searchResultsMap[searchResults_cmbBox.SelectedItem.ToString()];
            //location2_txt.Text = selectedMedia.Location.ToString();
            //event2_txt.Text = selectedMedia.Event.ToString();
            //List<string> personsList = API.getPersonsFromMedia(selectedMedia);
            //foreach(string person in personsList)
            //{
            //    persons2_cmbBox.Items.Add(person);
            //}

            //List<string> customAttributes = API.getCustomAttributesFromMedia(selectedMedia);
            //foreach(string attribute in customAttributes)
            //{
            //    extra_cmbBox.Items.Add(attribute);
            //}

            //if(selectedMedia.MediaType == MediaType.Photo)
            //{
            //    movie_MediaPly.Visible = false;
            //}
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            //movie_MediaPly.Visible = true;
            //movie_MediaPly.URL = searchResults_cmbBox.SelectedItem.ToString();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

        }


        //////////////////////
    }
}
