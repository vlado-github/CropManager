package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/9/13
 * Time: 4:05 PM
 * To change this template use File | Settings | File Templates.
 */
public class AddFieldActivity extends Activity {
    public EditText fieldName = null;
    public SeekBar altitudeBar = null;
    public TextView altitudeVal = null;
    public TextView areaSize = null;
    public Spinner measures = null;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngaddfield);

        fieldName = (EditText) findViewById(R.id.nameTxt);
        altitudeBar = (SeekBar) findViewById(R.id.seekBar);
        altitudeVal = (TextView) findViewById(R.id.altitudeValue);
        areaSize = (TextView) findViewById(R.id.areaSizeVal);
        measures = (Spinner) findViewById(R.id.measureSpinner);

        fillData();
    }

    public void fillData(){

    }
}