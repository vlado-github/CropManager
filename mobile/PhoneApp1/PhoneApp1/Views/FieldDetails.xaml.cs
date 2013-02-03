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
using PhoneApp1.Models;

namespace PhoneApp1.Views
{
    public partial class FieldDetails : PhoneApplicationPage
    {
        public delegate void LoadFieldCallback(List<FieldModel> fields);

        public FieldDetails()
        {
            InitializeComponent();
            FieldModel fieldModel = new FieldModel();
            LoadFieldCallback handler = new LoadFieldCallback(LoadFieldList);
            fieldModel.GetAllFields(new Action<List<FieldModel>>(handler));
        }

        public void LoadFieldList(List<FieldModel> fields)
        {
            fieldPicker.ItemsSource = fields;
        }

        private void showDetails_Click(object sender, RoutedEventArgs e)
        {
            int selectedFieldId = ((FieldModel)fieldPicker.SelectedItem).Id;
            NavigationService.Navigate(new Uri("/Views/FieldDetailsPage.xaml?parameter=" + selectedFieldId, UriKind.Relative));
        }
    }
}