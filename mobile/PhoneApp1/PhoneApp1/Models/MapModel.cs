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
        public delegate void GetMapCallback(MapModel mapModel);
        Action<List<int>> ViewSaveCallback = null;
        Action<MapModel> ViewLoadMapCallback = null;

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

        public void GetMapById(Action<MapModel> callback, int mapId)
        {
            MapRepository mapRepository = new MapRepository();
            ViewLoadMapCallback = callback;
            GetMapCallback handler = new GetMapCallback(GetMapCompleted);
            mapRepository.GetMap(new Action<MapModel>(handler), mapId);
        }

        public void SaveMapCompleted(List<int> id)
        {
            ViewSaveCallback(id);
        }

        public void GetMapCompleted(MapModel mapModel)
        {
            ViewLoadMapCallback(mapModel);
        }
    }
}
