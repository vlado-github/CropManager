﻿using System;
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
using System.Device.Location;

namespace PhoneApp1.Models
{
    public class FieldModel
    {
        public delegate void GetAllFieldsCallback(List<FieldModel> fields);
        public delegate void GetFieldByIdCallback(FieldModel field);
        public delegate void SaveFieldCallback(int id);
        Action<List<FieldModel>> ViewCallback = null;
        Action<FieldModel> ViewFieldByIdCallback = null;
        Action<int> ViewSaveFieldCallback = null;
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

        public void GetFieldById(Action<FieldModel> callback, int id)
        {
            FieldRepository fieldRepository = new FieldRepository();
            ViewFieldByIdCallback = callback;
            GetFieldByIdCallback handler = new GetFieldByIdCallback(GetFieldByIdCompleted);
            fieldRepository.getFieldById(new Action<FieldModel>(handler),id);
        }

        public void SaveField(Action<int> callback, FieldModel fieldModel)
        {
            FieldRepository fieldRepository = new FieldRepository();
            ViewSaveFieldCallback = callback;
            SaveFieldCallback handler = new SaveFieldCallback(SaveFieldCompleted);
            fieldRepository.saveField(new Action<int>(handler), fieldModel);
        }

        public void GetAllFieldsCompleted(List<FieldModel> fields)
        {
            allFields = fields;
            ViewCallback(fields);
        }

        public void GetFieldByIdCompleted(FieldModel fm)
        {
            ViewFieldByIdCallback(fm);
        }

        public void SaveFieldCompleted(int id)
        {
            ViewSaveFieldCallback(id);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
