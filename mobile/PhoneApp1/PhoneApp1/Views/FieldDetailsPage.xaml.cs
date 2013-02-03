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
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Controls.Maps.Platform;

namespace PhoneApp1.Views
{
    public partial class FieldDetailsPage : PhoneApplicationPage
    {
        public delegate void GetFieldByIdCompleted(FieldModel field);
        public delegate void GetMapidsCompleted(List<int> ids);
        public delegate void GetMapCompleted(MapModel map);

        public FieldModel fieldModel = null;
        public List<int> mapIds = null;
        public List<MapModel> mapPoints = new List<MapModel>();

        public FieldDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string fieldIdValue = NavigationContext.QueryString["parameter"];
            int fieldId = Int16.Parse(fieldIdValue);

            // Load Field data
            GetFieldByIdCompleted handler = new GetFieldByIdCompleted(LoadFieldById);
            FieldModel fieldModel = new FieldModel();
            fieldModel.GetFieldById(new Action<FieldModel>(handler), fieldId);

            // Load Maps ids
            GetMapidsCompleted mapIdsHandler = new GetMapidsCompleted(LoadMapIds);
            MapFieldModel mfModel = new MapFieldModel();
            mfModel.GetMapIds(new Action<List<int>>(mapIdsHandler), fieldId);
        }

        private void LoadFieldById(FieldModel fm)
        {
            fieldModel = fm;
        }

        private void LoadMapIds(List<int> ids)
        {
            mapIds = ids;

            GetMapCompleted handler = new GetMapCompleted(LoadMap);
            MapModel mapModel = new MapModel();
            foreach (int mapId in ids)
            {
                mapModel.GetMapById(new Action<MapModel>(handler), mapId);
            }
        }

        private void LoadMap(MapModel map)
        {
            mapPoints.Add(map);
            if (mapPoints.Count == mapIds.Count)
            {
                PreviewData();
            }
        }

        private void PreviewData()
        {
            LocationCollection locationCollection = new LocationCollection();
            foreach (MapModel mapModel in mapPoints)
            {
                GeoCoordinate geo = new GeoCoordinate(mapModel.Latitude,mapModel.Longitude);
                locationCollection.Add(geo);
            }
            
            double Latitude = mapPoints.ElementAt(0).Latitude;
            double Longitude = mapPoints.ElementAt(0).Longitude;
            mapMain.Center = new GeoCoordinate(Latitude, Longitude);
            mapMain.ZoomLevel = 15;
            mapMain.ZoomBarVisibility = Visibility.Visible;

            MapPolygon polygon = new MapPolygon();
            polygon.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Orange);
            polygon.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Yellow);
            polygon.StrokeThickness = 1;
            polygon.Opacity = 0.7;
            polygon.Locations = locationCollection;
            polygon.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(polygon_Tap);

            mapMain.Children.Add(polygon);
        }

        private void polygon_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Name: " + fieldModel.Name + 
                "; Altitude: " + fieldModel.Altitude +"[m]"+
                "; Area Size: " + fieldModel.AreaSize +
                " in " + fieldModel.AreaSizeMeasure);
        }

    }
}