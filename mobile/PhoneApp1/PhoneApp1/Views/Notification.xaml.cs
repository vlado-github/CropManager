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
using System.Xml.Linq;
using PhoneApp1.Models;

namespace PhoneApp1.Views
{
    public partial class Notification : PhoneApplicationPage
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WebClient twitterClient = new WebClient();
            twitterClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitterClient_DownloadStringCompleted);
            twitterClient.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + twitterName.Text.ToString()));
        }

        void twitterClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;
            XElement xmlTweets = XElement.Parse(e.Result);
            tweetsList.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                     select new NotificationModel
                                     {
                                        ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                        Message = tweet.Element("text").Value,
                                        UserName = tweet.Element("user").Element("screen_name").Value
                                     };    
        }
    }
}