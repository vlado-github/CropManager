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
        Action<List<int>> ViewSaveCallback = null;

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

        public void SaveMapFieldCompleted(List<int> ids)
        {
            ViewSaveCallback(ids);
        }
    }
}
