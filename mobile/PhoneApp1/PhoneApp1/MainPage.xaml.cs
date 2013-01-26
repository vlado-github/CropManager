﻿using System;
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
using PhoneApp1.ServiceRepository;
using PhoneApp1.CropServiceReference;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void getCropData_Click(object sender, RoutedEventArgs e)
        {
            CropServiceClient cropSvc = new CropServiceClient();
            cropSvc.SelectCropByIdAsync(1);
            cropSvc.SelectCropByIdCompleted += new EventHandler
            <SelectCropByIdCompletedEventArgs>(cropSvc_SelectCropByIdCompleted);
        }

        private void cropSvc_SelectCropByIdCompleted(object sender, SelectCropByIdCompletedEventArgs e)
        {
            Crop crop = e.Result;
            textBox1.Text = crop.name + " " + crop.croptype + " " + crop.timeofplanting;
        }
    }
}