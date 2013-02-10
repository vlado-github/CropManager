package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.*;
import at.fhooe.ViewModel.CropViewModel;
import at.fhooe.ViewModel.FieldMeasureViewModel;

import java.util.ArrayList;

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
    public EditText areaSize = null;
    public Spinner measures = null;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngaddfield);

        fieldName = (EditText) findViewById(R.id.nameTxt);
        altitudeBar = (SeekBar) findViewById(R.id.seekBar);
        altitudeVal = (TextView) findViewById(R.id.altitudeValue);
        areaSize = (EditText) findViewById(R.id.areaSizeVal);
        measures = (Spinner) findViewById(R.id.measureSpinner);
        altitudeBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                altitudeVal.setText(seekBar.getProgress()+"[m]");
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                //To change body of implemented methods use File | Settings | File Templates.
            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                //To change body of implemented methods use File | Settings | File Templates.
            }
        });
        fillData();
    }

    public void fillData(){
        FieldMeasureViewModel fieldMeasureModel = new FieldMeasureViewModel();
        ArrayList<FieldMeasureViewModel> fieldMeasures = fieldMeasureModel.getAllFieldMeasures();
        ArrayAdapter<FieldMeasureViewModel> adapter = new ArrayAdapter<FieldMeasureViewModel>(this, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        for (int i = 0; i < fieldMeasures.size(); ++i) {
            adapter.add(fieldMeasures.get(i));
        }
        measures.setAdapter(adapter);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.nextBtn:
                Intent toFieldMap = new Intent(this, AddFieldMapActivity.class);
                startActivity(toFieldMap);
                break;
            case R.id.cancelBtn:
                Intent toCropMng = new Intent(this, CropMngActivity.class);
                startActivity(toCropMng);
                break;
        }
    }
}