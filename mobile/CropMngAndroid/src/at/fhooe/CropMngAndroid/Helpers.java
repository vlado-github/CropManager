package at.fhooe.CropMngAndroid;

import android.widget.DatePicker;

import java.util.Calendar;
import java.util.Date;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/7/13
 * Time: 5:36 PM
 * To change this template use File | Settings | File Templates.
 */
public class Helpers {
    public static Date convertToDate(DatePicker datePicker){
        int day = datePicker.getDayOfMonth();
        int month = datePicker.getMonth();
        int year =  datePicker.getYear();
        Calendar cal = Calendar.getInstance();
        cal.set(year, month, day);
        return cal.getTime();
    }
}
