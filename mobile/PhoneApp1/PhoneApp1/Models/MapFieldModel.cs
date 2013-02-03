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
    public class MapFieldModel
    {
        public delegate void SaveMapFieldCallback(List<int> id);
        public delegate void LoadMapIdsCallback(List<int> ids);
        Action<List<int>> ViewSaveCallback = null;
        Action<List<int>> ViewLoadMapIdsCallback = null;

        public int MapFieldId { get; set; }
        public int FieldId { get; set; }
        public int MapId { get; set; }

        public void SaveMapField(Action<List<int>> callback, List<MapFieldModel> mapFields)
        {
            MapFieldRepository mapFieldRep = new MapFieldRepository();
            ViewSaveCallback = callback;
            SaveMapFieldCallback handler = new SaveMapFieldCallback(SaveMapFieldCompleted);
            mapFieldRep.SaveMapField(new Action<List<int>>(handler), mapFields);
        }

        public void GetMapIds(Action<List<int>> callback, int fieldId)
        {
            MapFieldRepository mapFieldRep = new MapFieldRepository();
            ViewLoadMapIdsCallback = callback;
            LoadMapIdsCallback handler = new LoadMapIdsCallback(LoadMapIdsCompleted);
            mapFieldRep.GetMapIds(new Action<List<int>>(handler), fieldId);
        }

        public void SaveMapFieldCompleted(List<int> ids)
        {
            ViewSaveCallback(ids);
        }

        public void LoadMapIdsCompleted(List<int> ids)
        {
            ViewLoadMapIdsCallback(ids);
        }
    }
}
