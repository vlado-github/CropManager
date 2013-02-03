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
    public class MeasureModel
    {
        public delegate void GetAllMeasuresCallback(List<MeasureModel> measures);
        Action<List<MeasureModel>> ViewCallback = null;

        public int MeasureId { get; set; }
        public String Type { get; set; }

        public void GetAllMeasures(Action<List<MeasureModel>> callback)
        {
            MeasureRepository measureRepository = new MeasureRepository();
            ViewCallback = callback;
            GetAllMeasuresCallback handler = new GetAllMeasuresCallback(GetAllMeasuresCompleted);
            measureRepository.getAllMeasures(new Action<List<MeasureModel>>(handler));
        }

        public void GetAllMeasuresCompleted(List<MeasureModel> measures)
        {
            ViewCallback(measures);
        }

        public override string ToString()
        {
            return Type;
        }
    }
}
