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

namespace PhoneApp1.Views
{
    public partial class AddJournal : PhoneApplicationPage
    {
        byte[] image = null;

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

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}