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
    public partial class Weather : PhoneApplicationPage
    {
        public delegate void GetWeatherForcastCallback(List<WeatherModel> weather);
        public Weather()
        {
            InitializeComponent();
        }

        private void loadWeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            String location = locationTxt.Text;
            WeatherModel weatherModel = new WeatherModel();
            GetWeatherForcastCallback handler = new GetWeatherForcastCallback(GetWeatherForcastCompleted);
            weatherModel.GetWeatherForcast(new Action<List<WeatherModel>>(handler),location, "Austria");
        }

        public void GetWeatherForcastCompleted(List<WeatherModel> weather)
        {
            weatherListBox.ItemsSource = weather;
        }
    }
}