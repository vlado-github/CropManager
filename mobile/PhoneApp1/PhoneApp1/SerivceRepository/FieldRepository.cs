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
//using PhoneApp1.FieldServiceReference;
using System.Collections.Generic;
using PhoneApp1.Models;
using PhoneApp1.MapServiceReference;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using PhoneApp1.FieldServiceReference;

namespace PhoneApp1.SerivceRepository
{
    public class FieldRepository
    {
        Action<List<FieldModel>> getAllFieldsCallback = null;
        Action<FieldModel> getFieldByIdCallback = null;
        Action<int> saveFieldCallback = null;

        public void getAllFields(Action<List<FieldModel>> callback)
        {
            getAllFieldsCallback = callback;
            FieldServiceClient fieldSvc = new FieldServiceClient();
            fieldSvc.SelectFieldsCompleted += new EventHandler
                <SelectFieldsCompletedEventArgs>(fieldSvc_SelectFieldsCompleted);
            fieldSvc.SelectFieldsAsync();
        }

        public void getFieldById(Action<FieldModel> callback, int id)
        {
            getFieldByIdCallback = callback;
            FieldServiceClient fieldSvc = new FieldServiceClient();
            fieldSvc.SelectFieldByIdCompleted += new EventHandler<SelectFieldByIdCompletedEventArgs>
                (fieldSvc_SelectFieldByIdCompleted);
            fieldSvc.SelectFieldByIdAsync(id);
        }

        private void fieldSvc_SelectFieldByIdCompleted(object sender, SelectFieldByIdCompletedEventArgs e)
        {
            Field field = e.Result;
            FieldModel fm = mapFieldToFieldModel(field);
            getFieldByIdCallback(fm);
        }

        public void saveField(Action<int> callback, FieldModel fieldModel)
        {
            saveFieldCallback = callback;
            Field field = mapFieldModelToField(fieldModel);
            FieldServiceClient fieldSvc = new FieldServiceClient();
            fieldSvc.InsertFieldCompleted += new EventHandler
                <InsertFieldCompletedEventArgs>(fieldSvc_InsertFieldCompleted);
            fieldSvc.InsertFieldAsync(field);
        }

        void fieldSvc_InsertFieldCompleted(object sender, InsertFieldCompletedEventArgs e)
        {
            int id = e.Result;
            saveFieldCallback(id);
        }

        private void fieldSvc_SelectFieldsCompleted(object sender, SelectFieldsCompletedEventArgs e)
        {
            IEnumerable<Field> allFields = (IEnumerable<Field>)e.Result;
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

        private FieldModel mapFieldToFieldModel(Field field)
        {
            FieldModel fieldModel = new FieldModel();
            fieldModel.Name = field.Name;
            fieldModel.Id = field.Id;
            fieldModel.Altitude = field.Altitude;
            fieldModel.AreaSize = field.AreaSize;
            fieldModel.AreaSizeMeasure = field.AreaSizeMeasure;
            fieldModel.Crop_fk = field.Crop_fk;
            fieldModel.Map_fk = field.Map_fk;

            return fieldModel;
        }

        private Field mapFieldModelToField(FieldModel fieldModel)
        {
            Field field = new Field();
            field.Name = fieldModel.Name;
            field.Altitude = fieldModel.Altitude;
            field.AreaSize = fieldModel.AreaSize;
            field.AreaSizeMeasure = fieldModel.AreaSizeMeasure;
            field.Crop_fk = fieldModel.Crop_fk;
            field.Map_fk = fieldModel.Map_fk;

            return field;
        }
    }
}
