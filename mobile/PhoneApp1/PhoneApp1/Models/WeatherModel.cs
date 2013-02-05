using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PhoneApp1.SerivceRepository;
using System.Collections.Generic;

namespace PhoneApp1.Models
{
    public class WeatherModel
    {
        public delegate void GetWeatherForcastCallback(List<WeatherModel> weather);
        Action<List<WeatherModel>> ViewCallback;

        public String City { get; set; }
        public String DayTime { get; set; }
        public String Condition { get; set; }
        public String TempFMin { get; set; }
        public String TempFMax { get; set; }
        public String TempCMin { get; set; }
        public String TempCMax { get; set; }
        public String Humidity { get; set; }
        public String Wind { get; set; }

        public void GetWeatherForcast(Action<List<WeatherModel>> callback, String location, String country)
        {
            ViewCallback = callback;
            WeatherRepository weatherRep = new WeatherRepository();
            GetWeatherForcastCallback handler = new GetWeatherForcastCallback(GetWeatherForcastCompleted);
            weatherRep.GetWeatherForcast(new Action<List<WeatherModel>>(handler), location, country);
        }

        public void GetWeatherForcastCompleted(List<WeatherModel> weather)
        {
            ViewCallback(weather);
        }

    }
}
