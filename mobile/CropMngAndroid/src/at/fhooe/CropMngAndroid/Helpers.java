package at.fhooe.CropMngAndroid;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.provider.MediaStore;
import android.widget.DatePicker;
import android.widget.ImageButton;
import android.widget.ImageView;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
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
        Date date = null;
        try{
            int day = datePicker.getDayOfMonth();
            int month = datePicker.getMonth();
            int year =  datePicker.getYear();
            Calendar cal = Calendar.getInstance();
            cal.set(year, month, day);
            long calLong = cal.getTime().getTime();
            date = new Date(calLong);
        }catch(Exception e){
            e.printStackTrace();
        }
        return date;
    }

    public static Bitmap convertBytesToBitmap(byte[] bytes){
        byte[] blob = bytes;
        Bitmap bmp= BitmapFactory.decodeByteArray(blob, 0, blob.length);
        return bmp;
    }

    public static long parseJsonDate(String jsonDate){
        String[] result = jsonDate.split("[(]");
        String[] resultTwo = result[1].split("[+]");
        return Long.parseLong(resultTwo[0]);
    }
}
