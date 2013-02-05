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
using PhoneApp1.Models;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace PhoneApp1.SerivceRepository
{
    public class WeatherRepository
    {
        Action<List<WeatherModel>> GetWeatherForcatsCallback;

        public void GetWeatherForcast(Action<List<WeatherModel>> callback, String location, String country)
        {
            GetWeatherForcatsCallback = callback;
            String url = string.Format("http://free.worldweatheronline.com/feed/weather.ashx?" +
                "key={0}&q={1},{2}&num_of_days=3&format=xml", "7b72960d6c230143130402", location, country);
            WebClient downloader = new WebClient();
            downloader.DownloadStringCompleted += new DownloadStringCompletedEventHandler(ForecastDownloaded); 
            downloader.DownloadStringAsync(new Uri(url));
        }

        public void ForecastDownloaded(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result == null || e.Error != null)
            {
                MessageBox.Show("Cannot load Weather Forecast!");
            }
            else
            {
                XElement XmlWeather = XElement.Parse(e.Result);
                //current
                IEnumerable<WeatherModel> currentForcast = from weather in XmlWeather.Descendants("current_condition") 
                                       select new WeatherModel
                                       {

                                           DayTime = weather.Element("observation_time").Value,
                                           TempCMax = weather.Element("temp_C").Value,
                                           TempFMax = weather.Element("temp_F").Value,
                                           Condition = weather.Element("weatherDesc").Value,
                                           Wind = weather.Element("windspeedKmph").Value + " kmph",
                                           Humidity = weather.Element("humidity").Value
                                       };


                //all three days
                IEnumerable<WeatherModel> futureForcast = from weather in XmlWeather.Descendants("weather")

                                       select new WeatherModel
                                       {
                                           DayTime = weather.Element("date").Value,
                                           TempCMax = weather.Element("tempMaxC").Value,
                                           TempCMin = weather.Element("tempMinC").Value,
                                           Condition = weather.Element("weatherDesc").Value,
                                           Wind = weather.Element("windspeedKmph").Value + " kmph > " + weather.Element("winddirection").Value
                                       };
                List<WeatherModel> currentForcastList = new List<WeatherModel>(currentForcast);
                List<WeatherModel> futureForcastList = new List<WeatherModel>(futureForcast);
                List<WeatherModel> weatherForcast = currentForcastList;
                foreach (WeatherModel wm in futureForcastList)
                {
                    weatherForcast.Add(wm);
                }

                GetWeatherForcatsCallback(weatherForcast);
            }
        }
        
    }
}
