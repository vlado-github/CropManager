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
using PhoneApp1.CropServiceReference;

namespace PhoneApp1.ServiceRepository
{
    public class CropRepository
    {
        Crop crop = null;

        public void getCropDataById(int id)
        {
            CropServiceClient cropSvc = new CropServiceClient();
            cropSvc.SelectCropByIdAsync(id);
            cropSvc.SelectCropByIdCompleted += new EventHandler
            <SelectCropByIdCompletedEventArgs>(cropSvc_SelectCropByIdCompleted);
  
        }

        private void cropSvc_SelectCropByIdCompleted(object sender, SelectCropByIdCompletedEventArgs e)
        {
            crop = e.Result;
        }
        
    }
}
