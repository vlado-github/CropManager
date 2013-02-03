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
using PhoneApp1.MapServiceReference;
using System.Collections.Generic;

namespace PhoneApp1.SerivceRepository
{
    public class MapRepository
    {
        private int listSize = 0;
        private int insertCount = 0;
        private List<int> ids = new List<int>();

        public Action<List<int>> SaveCallback;
        public Action<MapModel> GetMapCallback;

        public void SaveMap(Action<List<int>> callback, List<MapModel> mapModels)
        {
            MapServiceClient mapSvc = new MapServiceClient();
            SaveCallback = callback;
            listSize = mapModels.Count;
            mapSvc.InsertMapCompleted += new EventHandler
                <InsertMapCompletedEventArgs>(mapSvc_InsertMapCompleted);
            foreach (MapModel mm in mapModels)
            {
                Map map =MappingMapModelToMap(mm);
                mapSvc.InsertMapAsync(map);
            }
        }

        public void GetMap(Action<MapModel> callback, int mapId)
        {
            MapServiceClient mapSvc = new MapServiceClient();
            GetMapCallback = callback;
            mapSvc.SelectMapByIdAsync(mapId);
            mapSvc.SelectMapByIdCompleted += new EventHandler
                <SelectMapByIdCompletedEventArgs>(mapSvc_SelectMapByIdCompleted);
        }

        public void mapSvc_SelectMapByIdCompleted(object sender, SelectMapByIdCompletedEventArgs e)
        {
            Map map = e.Result;
            MapModel mapModel = MappingMapToMapModel(map);
            GetMapCallback(mapModel);
        }

        public void mapSvc_InsertMapCompleted(object sender, InsertMapCompletedEventArgs e)
        {
            ids.Add(e.Result);
            insertCount++;
            
            if (insertCount == listSize)
            {
                SaveCallback(ids);
            }
        }

        private Map MappingMapModelToMap(MapModel mapModel)
        {
            Map map = new Map();
            map.longitude = mapModel.Longitude;
            map.latitude = mapModel.Latitude;

            return map;
        }

        private MapModel MappingMapToMapModel(Map map)
        {
            MapModel mapModel = new MapModel();
            mapModel.MapId = map.mapid;
            mapModel.Latitude = map.latitude;
            mapModel.Longitude = map.longitude;

            return mapModel;
        }
    }
}
