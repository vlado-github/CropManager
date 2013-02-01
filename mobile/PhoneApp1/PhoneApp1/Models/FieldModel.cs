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
using System.Collections.Generic;
using PhoneApp1.SerivceRepository;

namespace PhoneApp1.Models
{
    public class FieldModel
    {
        public delegate void GetAllFieldsCallback(List<FieldModel> fields);
        Action<List<FieldModel>> ViewCallback = null;
        List<FieldModel> allFields = new List<FieldModel>();

        public int Id { get; set; }
        public String Name { get; set; }
        public double Altitude { get; set; }
        public double AreaSize { get; set; }
        public String AreaSizeMeasure { get; set; }
        public int Map_fk { get; set; }
        public int Crop_fk { get; set; }

        public void GetAllFields(Action<List<FieldModel>> callback)
        {
            FieldRepository fieldRepository = new FieldRepository();
            ViewCallback = callback;
            GetAllFieldsCallback handler = new GetAllFieldsCallback(GetAllFieldsCompleted);
            fieldRepository.getAllFields(new Action<List<FieldModel>>(handler));
        }

        public void GetAllFieldsCompleted(List<FieldModel> fields)
        {
            allFields = fields;
            ViewCallback(fields);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
