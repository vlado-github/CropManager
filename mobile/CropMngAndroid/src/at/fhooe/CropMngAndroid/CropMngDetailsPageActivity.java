package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.DatePicker;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;
import at.fhooe.ViewModel.CropViewModel;
import at.fhooe.ViewModel.FieldViewModel;

import java.text.SimpleDateFormat;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/8/13
 * Time: 8:51 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropMngDetailsPageActivity extends Activity {
    public TextView nameTxt = null;
    public TextView fieldTxt = null;
    public TextView timePeriodsTxt = null;
    public TextView wateringFreqTxt = null;
    public TextView typeTxt = null;
    public TextView timeOfPlantingDate = null;
    public TextView coverageValue = null;
    public TextView harvestingTime = null;
    public TextView hillingTime = null;
    public TextView fertilizingTime = null;

    public CropViewModel crop = null;
    public FieldViewModel field = null;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngdetailspage);

        Intent intent = getIntent();
        int cropId = intent.getIntExtra(CropMngDetailsActivity.TO_CROPMNGDETAILSPAGE, 0);

        CropViewModel cropModel = new CropViewModel();
        crop = cropModel.getCropById(cropId);
        FieldViewModel fieldModel = new FieldViewModel();
        field = fieldModel.getFieldById(crop.getFieldId());

        fieldTxt = (TextView) findViewById(R.id.fieldsBox);
        timePeriodsTxt = (TextView) findViewById(R.id.wateringPeriod);
        wateringFreqTxt = (TextView) findViewById(R.id.wateringFrequency);
        nameTxt = (TextView) findViewById(R.id.nameTxt);
        typeTxt = (TextView) findViewById(R.id.typeTxt);
        timeOfPlantingDate = (TextView) findViewById(R.id.timeOfPlanting);
        coverageValue = (TextView) findViewById(R.id.coverageValue);
        harvestingTime = (TextView) findViewById(R.id.harvestTime);
        hillingTime = (TextView) findViewById(R.id.hillingTime);
        fertilizingTime = (TextView) findViewById(R.id.fertillizingTime);

        fillCropData();
    }

    public void fillCropData(){
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        if(crop != null){
            fieldTxt.setText(field.getName());
            timePeriodsTxt.setText(crop.getWateringPeriod());
            wateringFreqTxt.setText(crop.getWateringFreq());
            nameTxt.setText(crop.getName());
            typeTxt.setText(crop.getCropType());
            timeOfPlantingDate.setText(sdf.format(crop.getTimeOfPlanting()));
            coverageValue.setText(String.valueOf(crop.getFieldCoverage()));
            harvestingTime.setText(sdf.format(crop.getHarvestTime()));
            hillingTime.setText(sdf.format(crop.getHillingTime()));
            fertilizingTime.setText(sdf.format(crop.getFertilizingTime()));
        }
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.cancelBtn:
                Intent toCropDetails = new Intent(this, CropMngDetailsActivity.class);
                startActivity(toCropDetails);
                break;
        }
    }


}