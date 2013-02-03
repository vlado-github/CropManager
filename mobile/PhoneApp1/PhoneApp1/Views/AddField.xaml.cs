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
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using PhoneApp1.Models;

namespace PhoneApp1.Views
{
    public partial class AddField : PhoneApplicationPage
    {
        public delegate void SaveMapCallback(List<int> id);
        public delegate void SaveFieldCallback(int id);
        public delegate void SaveMapFieldCallback(List<int> ids);

        private List<int> mapIds;
        private int fieldId;

        GeoCoordinateWatcher coordinateWatcher;   
        double Latitude, Longitude;
        List<MapModel> fieldPoints = new List<MapModel>();
        public delegate void GetAllMeasuresCallback(List<MeasureModel> measures);

        public AddField()
        {
            InitializeComponent();

            MeasureModel measureModel = new MeasureModel();
            GetAllMeasuresCallback handler = new GetAllMeasuresCallback(GetAllMeasuresCompleted);
            measureModel.GetAllMeasures(new Action<List<MeasureModel>>(handler));

            Latitude = 48.3669;
            Longitude = 14.5172;
            mapMain.Center = new GeoCoordinate(Latitude, Longitude);
            mapMain.ZoomLevel = 15;
            mapMain.ZoomBarVisibility = Visibility.Visible;
            coordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            coordinateWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(coordinateWatcher_PositionChanged);
        }

        public void coordinateWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (!e.Position.Location.IsUnknown)
            {
                Latitude = e.Position.Location.Latitude;
                Longitude = e.Position.Location.Longitude;
                mapMain.Center = new GeoCoordinate(Latitude, Longitude);
            }   
        }

        private void GestureListener_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Point p = e.GetPosition(mapMain);
            GeoCoordinate geo = new GeoCoordinate();
            geo = mapMain.ViewportPointToLocation(p);
            mapMain.Center = geo;

            Pushpin pin = new Pushpin();
            pin.Background = new SolidColorBrush(Colors.Orange);
            pin.Location = geo;
            MapModel mapModel = new MapModel();
            mapModel.Latitude = geo.Latitude;
            mapModel.Longitude = geo.Longitude;
            fieldPoints.Add(mapModel);
            mapMain.Children.Add(pin);
        }

        public void GetAllMeasuresCompleted(List<MeasureModel> measures)
        {
            measurePicker.ItemsSource = measures;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //insert map - get id
            MapModel mapModel = new MapModel();
            SaveMapCallback handler = new SaveMapCallback(SaveMapCompleted);
            mapModel.SaveMap(new Action<List<int>>(handler), fieldPoints);
        }

        public void SaveMapCompleted(List<int> ids)
        {
            mapIds = ids;
            //insert field with mapid - get id
            FieldModel fieldModel = new FieldModel();
            fieldModel.Name = NameTxt.Text;
            fieldModel.Altitude = Double.Parse(altitudeValue.Text);
            fieldModel.AreaSize = Double.Parse(AreaSizeTxt.Text);
            fieldModel.AreaSizeMeasure = ((MeasureModel)measurePicker.SelectedItem).Type.ToString();
            SaveFieldCallback handler = new SaveFieldCallback(SaveFieldCompleted);
            fieldModel.SaveField(new Action<int>(handler), fieldModel);
        }

        public void SaveFieldCompleted(int id)
        {
            fieldId = id;
            //insert field-map with mapid, fieldid
            MapFieldModel mapFieldModel = new MapFieldModel();
            List<MapFieldModel> mapFieldRecords = new List<MapFieldModel>();
            foreach (int mapId in mapIds)
            {
                MapFieldModel mfm = new MapFieldModel();
                mfm.FieldId = fieldId;
                mfm.MapId = mapId;
                mapFieldRecords.Add(mfm);
            }
            SaveMapFieldCallback handler = new SaveMapFieldCallback(SaveMapFieldCompleted);
            mapFieldModel.SaveMapField(new Action<List<int>>(handler), mapFieldRecords);
        }

        public void SaveMapFieldCompleted(List<int> ids)
        {
            MessageBox.Show("Saved successfully.");
        }            

    }
}