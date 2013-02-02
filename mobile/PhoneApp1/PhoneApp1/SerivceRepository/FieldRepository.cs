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
using PhoneApp1.FieldServiceReference;
using System.Collections.Generic;
using PhoneApp1.Models;

namespace PhoneApp1.SerivceRepository
{
    public class FieldRepository
    {
        Action<List<FieldModel>> getAllFieldsCallback = null;
        Action<FieldModel> getFieldByIdCallback = null;

        public void getAllFields(Action<List<FieldModel>> callback)
        {
            getAllFieldsCallback = callback;
            FieldServiceClient fieldSvc = new FieldServiceClient();
            fieldSvc.SelectFieldsAsync();
            fieldSvc.SelectFieldsCompleted += new EventHandler
                <SelectFieldsCompletedEventArgs>(fieldSvc_SelectFieldsCompleted);
        }

        public void getFieldById(Action<FieldModel> callback, int id)
        {
            getFieldByIdCallback = callback;
            FieldServiceClient fieldSvc = new FieldServiceClient();
            fieldSvc.SelectFieldByIdAsync(id);
            fieldSvc.SelectFieldByIdCompleted += new EventHandler
                <SelectFieldByIdCompletedEventArgs>(fieldSvc_SelectFieldByIdCompleted);
        }

        private void fieldSvc_SelectFieldsCompleted(object sender, SelectFieldsCompletedEventArgs e)
        {
            IEnumerable<Field> allFields = (IEnumerable<Field>) e.Result;
            if (allFields != null)
            {
                List<Field> fields = new List<Field>(allFields);
                List<FieldModel> fieldModels = new List<FieldModel>();
                foreach (Field f in fields)
                {
                    FieldModel fm = mapFieldToFieldModel(f);
                    fieldModels.Add(fm);
                }
                getAllFieldsCallback(fieldModels);
            }
            else
            {
                getAllFieldsCallback(null);
            }
        }

        private void fieldSvc_SelectFieldByIdCompleted(object sender, SelectFieldByIdCompletedEventArgs e)
        {
            Field field = e.Result;
            FieldModel fm = mapFieldToFieldModel(field);
            getFieldByIdCallback(fm);
        }

        private FieldModel mapFieldToFieldModel(Field field)
        {
            FieldModel fieldModel = new FieldModel();
            fieldModel.Name = field.name;
            fieldModel.Id = field.field_id;
            fieldModel.Altitude = field.altitude;
            fieldModel.AreaSize = field.areasize;
            fieldModel.AreaSizeMeasure = field.areasizemeasure;
            fieldModel.Crop_fk = field.cropid;
            fieldModel.Map_fk = field.mapid;

            return fieldModel;
        }
    }
}
