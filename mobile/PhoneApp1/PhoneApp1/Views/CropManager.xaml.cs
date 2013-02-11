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
using System.ComponentModel;

namespace PhoneApp1.Views
{
    public partial class CropManager : PhoneApplicationPage
    {
        public CropManager()
        {
            InitializeComponent();
            BackKeyPress += OnBackKeyPressed;
        }

        public void OnBackKeyPressed(object sender, CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}