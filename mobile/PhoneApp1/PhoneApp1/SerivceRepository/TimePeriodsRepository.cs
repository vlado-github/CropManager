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
using PhoneApp1.TimePeriodsServiceReference;
using PhoneApp1.Models;

namespace PhoneApp1.SerivceRepository
{
    public class TimePeriodsRepository
    {
        Func<List<TimePeriod>, List<TimePeriod>> timePeriodsCallback; 

        public void getAllTimePeriodTypes(Func<List<TimePeriod>,List<TimePeriod>> callback)
        {
            timePeriodsCallback = callback;
            TimePeriodsServiceClient timePeriodSvc = new TimePeriodsServiceClient();
            timePeriodSvc.SelectAllTimePeriodsAsync();
            timePeriodSvc.SelectAllTimePeriodsCompleted += new EventHandler
                <SelectAllTimePeriodsCompletedEventArgs>(timePeriod_SelectAllTimePeriodsCompleted);
        }

        private void timePeriod_SelectAllTimePeriodsCompleted(object sender, SelectAllTimePeriodsCompletedEventArgs e)
        {
            IEnumerable<TimePeriod> timePeriods = e.Result;
            List<TimePeriod> tps = (List<TimePeriod>) timePeriods;
            List<TimePeriodModel> tpms = new List<TimePeriodModel>();
            foreach (TimePeriod tp in tps)
            {
                TimePeriodModel tpm = mapTimePeriodToTimePeriodModel(tp);
                tpms.Add(tpm);
            }
            //timePeriodsCallback.
        }

        private TimePeriodModel mapTimePeriodToTimePeriodModel(TimePeriod timePeriod)
        {
            TimePeriodModel tpm = new TimePeriodModel();
            tpm.TimePeriodId = timePeriod.timeperiodid;
            tpm.Type = timePeriod.type;

            return tpm;
        }
    }
}
