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
    public class MapModel
    {
        public delegate void SaveMapCallback(List<int> id);
        Action<List<int>> ViewSaveCallback = null;

        public int MapId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public void SaveMap(Action<List<int>> callback, List<MapModel> mapModels)
        {
            MapRepository mapRepository = new MapRepository();
            ViewSaveCallback = callback;
            SaveMapCallback handler = new SaveMapCallback(SaveMapCompleted);
            mapRepository.SaveMap(new Action<List<int>>(handler), mapModels);
        }

        public void SaveMapCompleted(List<int> id)
        {
            ViewSaveCallback(id);
        }
    }
}
