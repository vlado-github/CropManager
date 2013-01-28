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

namespace PhoneApp1.SerivceRepository
{
    public class FieldRepository
    {
        List<Field> fields = null;

        public void getAllFields()
        {
            FieldServiceClient fieldSvc = new FieldServiceClient();
            fieldSvc.SelectFieldsAsync();
            fieldSvc.SelectFieldsCompleted += new EventHandler
                <SelectFieldsCompletedEventArgs>(fieldSvc_SelectFieldsCompleted);
        }

        private void fieldSvc_SelectFieldsCompleted(object sender, SelectFieldsCompletedEventArgs e)
        {
            IEnumerable<Field> allFields = e.Result;
            fields = (List<Field>) allFields;
        }
    }
}
