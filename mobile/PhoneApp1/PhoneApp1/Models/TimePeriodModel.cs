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
    public class TimePeriodModel
    {
        public delegate void GetAllTimePeriodsCallback(List<TimePeriodModel> tpms);
        Action<List<TimePeriodModel>> ViewCallback = null;

        public int TimePeriodId { get; set; }
        public String Type { get; set; }

        public void GetAllTimePeriods(Action<List<TimePeriodModel>> callback)
        {
            TimePeriodsRepository timePeriodsRepository = new TimePeriodsRepository();
            ViewCallback = callback;
            GetAllTimePeriodsCallback handler = new GetAllTimePeriodsCallback(GetAllTimePeriodsCompleted);
            timePeriodsRepository.getAllTimePeriodTypes(new Action<List<TimePeriodModel>>(handler));
        }

        public void GetAllTimePeriodsCompleted(List<TimePeriodModel> tpms)
        {
            ViewCallback(tpms);
        }

        public override String ToString()
        {
            return Type;
        }
    }
}
