using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.IO;
using PhoneApp1.Models;
using System.Windows.Media.Imaging;

namespace PhoneApp1.Views
{
    public partial class AddJournal : PhoneApplicationPage
    {
        byte[] image = null;
        int cropId;

        public delegate void SaveJournalCallback(int id);

        public AddJournal()
        {
            InitializeComponent();
        }

        private void photoBtn_Click(object sender, RoutedEventArgs e)
        {
            var task = new CameraCaptureTask();
            task.Completed += new EventHandler<PhotoResult>(photo_ChooserTaskCompleted);
            task.Show();
        }

        private void photo_ChooserTaskCompleted(object sender, PhotoResult e)
        {
            Stream photoStream = e.ChosenPhoto;
            photoName.Text = e.OriginalFileName;
            var memoryStream = new MemoryStream();
            photoStream.CopyTo(memoryStream);
            image = memoryStream.ToArray();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string cropIdValue = NavigationContext.QueryString["parameter"];
            cropId = Int16.Parse(cropIdValue);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            JournalModel journalModel = new JournalModel();
            journalModel.CropId = cropId;
            journalModel.DateEntered = (DateTime) dateOfJournal.Value;
            journalModel.Description = descTxt.Text;
            journalModel.Photo = image;

            SaveJournalCallback handler = new SaveJournalCallback(SaveJournalCompleted);
            journalModel.SaveJournal(new Action<int>(handler), journalModel);
        }

        private void SaveJournalCompleted(int id)
        {
            if (id != 0)
            {
                MessageBox.Show("Saved successfully.");
            }
        }
    }
}