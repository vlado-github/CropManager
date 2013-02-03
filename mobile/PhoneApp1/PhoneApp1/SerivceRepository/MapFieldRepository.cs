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
using PhoneApp1.MapFieldServiceReference;
using PhoneApp1.Models;
using System.Collections.Generic;

namespace PhoneApp1.SerivceRepository
{
    public class MapFieldRepository
    {
        Action<List<int>> SaveCallback = null;
        Action<List<int>> LoadMapIdsCallback = null;
        List<int> ids = new List<int>();
        int listSize = 0;

        public void SaveMapField(Action<List<int>> callback, List<MapFieldModel> mapFieldModels)
        {
            MapFieldServiceClient mapFieldSvc = new MapFieldServiceClient();
            SaveCallback = callback;
            listSize = mapFieldModels.Count;
            mapFieldSvc.InsertMapFieldCompleted += new EventHandler
                 <InsertMapFieldCompletedEventArgs>(mapFieldSvc_InsertMapFieldCompleted);
            foreach (MapFieldModel mfm in mapFieldModels)
            {
                MapField mapField = MappingMapFieldModelToMapField(mfm);
                mapFieldSvc.InsertMapFieldAsync(mapField);
            }
        }

        public void GetMapIds(Action<List<int>> callback, int fieldId)
        {
            MapFieldServiceClient mapFieldSvc = new MapFieldServiceClient();
            LoadMapIdsCallback = callback;
            mapFieldSvc.SelectMapRecordsByFieldIdAsync(fieldId);
            mapFieldSvc.SelectMapRecordsByFieldIdCompleted += new EventHandler
                <SelectMapRecordsByFieldIdCompletedEventArgs>(mapFieldSvc_SelectMapRecordsByFieldIdCompleted);
        }

        public void  mapFieldSvc_InsertMapFieldCompleted(object sender, InsertMapFieldCompletedEventArgs e)
        {
 	        ids.Add(e.Result);
            if (ids.Count == listSize)
            {
                SaveCallback(ids);
            }
        }

        public void mapFieldSvc_SelectMapRecordsByFieldIdCompleted(object sender, SelectMapRecordsByFieldIdCompletedEventArgs e)
        {
            IEnumerable<int> ids = (IEnumerable<int>)e.Result;
            List<int> idsList = new List<int>(ids);
            LoadMapIdsCallback(idsList);
        }

        private MapField MappingMapFieldModelToMapField(MapFieldModel mfm)
        {
            MapField mapField = new MapField();
            mapField.FieldId = mfm.FieldId;
            mapField.MapId = mfm.MapId;

            return mapField;
        }
    }
}
