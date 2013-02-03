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
using System.Collections.Generic;
using PhoneApp1.MeasureServiceReference;

namespace PhoneApp1.SerivceRepository
{
    public class MeasureRepository
    {
        Action<List<MeasureModel>> getAllMeasuresCallback = null;

        public void getAllMeasures(Action<List<MeasureModel>> callback)
        {
            getAllMeasuresCallback = callback;
            FieldMeasureServiceClient measureSvc = new FieldMeasureServiceClient();
            measureSvc.GetAllMeasuresAsync();
            measureSvc.GetAllMeasuresCompleted += new EventHandler
                <GetAllMeasuresCompletedEventArgs>(measureSvc_GetAllMeasuresCompleted);
        }

        public void measureSvc_GetAllMeasuresCompleted(object sender, GetAllMeasuresCompletedEventArgs e)
        {
            IEnumerable<Measure> measures = (IEnumerable<Measure>) e.Result;
            List<Measure> measureList = new List<Measure>(measures);
            List<MeasureModel> measureModels = new List<MeasureModel>();
            foreach (Measure m in measureList)
            {
                MeasureModel mm = mapMeasureToMeasureModel(m);
                measureModels.Add(mm);
            }
            getAllMeasuresCallback(measureModels);
        }

        private MeasureModel mapMeasureToMeasureModel(Measure measure)
        {
            MeasureModel measureModel = new MeasureModel();
            measureModel.MeasureId = measure.measureid;
            measureModel.Type = measure.type;
            return measureModel;
        }
    }
}
