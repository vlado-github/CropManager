package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.*;
import at.fhooe.ViewModel.CropViewModel;
import at.fhooe.ViewModel.FieldViewModel;
import at.fhooe.ViewModel.TimePeriodViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 3:47 PM
 * To change this template use File | Settings | File Templates.
 */
public class AddCropActivity extends Activity {

    public Spinner fieldSpinner;
    public Spinner timePeriodsSpinner;
    public Spinner wateringFreqSpinner;
    public TextView nameTxt;
    public TextView typeTxt;
    public DatePicker timeOfPlantingDate;
    public TextView photoUri;
    public SeekBar coverageSlider;
    public DatePicker harvestingTime;
    public DatePicker hillingTime;
    public DatePicker fertilizingTime;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngadd);

        fieldSpinner = (Spinner) findViewById(R.id.fieldsBox);
        timePeriodsSpinner = (Spinner) findViewById(R.id.wateringPeriod);
        wateringFreqSpinner = (Spinner) findViewById(R.id.wateringFrequency);
        nameTxt = (TextView) findViewById(R.id.nameTxt);
        typeTxt = (TextView) findViewById(R.id.typeTxt);
        timeOfPlantingDate = (DatePicker) findViewById(R.id.timeOfPlanting);
        photoUri = (TextView) findViewById(R.id.imageURI);
        coverageSlider = (SeekBar) findViewById(R.id.coverageValue);
        harvestingTime = (DatePicker) findViewById(R.id.harvestTime);
        hillingTime = (DatePicker) findViewById(R.id.hillingTime);
        fertilizingTime = (DatePicker) findViewById(R.id.fertillizingTime);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.photoBtn:
                break;
            case R.id.saveBtn:
                CropViewModel cropModel = new CropViewModel();
                cropModel.setName(nameTxt.getText().toString());
                cropModel.setCropType(typeTxt.getText().toString());
                cropModel.setTimeOfPlanting(Helpers.convertToDate(timeOfPlantingDate));
                //cropModel.setAvatearImage();
                cropModel.setWateringFreq(Integer.parseInt((String)wateringFreqSpinner.getSelectedItem()));
                cropModel.setWateringPeriod(((TimePeriodViewModel)timePeriodsSpinner.getSelectedItem()).getType());
                cropModel.setHarvestTime(Helpers.convertToDate(harvestingTime));
                cropModel.setHillingTime(Helpers.convertToDate(hillingTime));
                cropModel.setFertilizingTime(Helpers.convertToDate(fertilizingTime));
                cropModel.setFieldCoverage(coverageSlider.getProgress());

                String status = cropModel.saveCrop(cropModel);
                if(status != "200"){
                    Toast.makeText(this,"Save unsuccessful", 2);
                }else{
                    Toast.makeText(this,"Save successful", 2);
                }
                break;
            case R.id.cancelBtn:
                Intent toCropMng = new Intent(this, CropMngActivity.class);
                startActivity(toCropMng);
                break;
        }
    }

    @Override
    public void onResume()
    {
        super.onResume();
        try{
            FieldViewModel fieldModel = new FieldViewModel();
            ArrayList<FieldViewModel> fields = fieldModel.getAllFields();
            ArrayAdapter<FieldViewModel> adapter = new ArrayAdapter<FieldViewModel>(this, android.R.layout.simple_spinner_item);
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            for (int i = 0; i < fields.size(); ++i) {
                adapter.add(fields.get(i));
            }
            fieldSpinner.setAdapter(adapter);

            TimePeriodViewModel timePeriodModel = new TimePeriodViewModel();
            ArrayList<TimePeriodViewModel> timePeriods = timePeriodModel.getAllTimePeriods();
            ArrayAdapter<TimePeriodViewModel> periodAdapter = new ArrayAdapter<TimePeriodViewModel>(this, android.R.layout.simple_spinner_item);
            periodAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            for (int i = 0; i < timePeriods.size(); ++i) {
                periodAdapter.add(timePeriods.get(i));
            }
            timePeriodsSpinner.setAdapter(periodAdapter);

            ArrayList<String> wateringFreq = new ArrayList<String>();
            for(int t=1; t<20; t++){
                wateringFreq.add(String.valueOf(t));
            }
            ArrayAdapter<String> wateringFreqAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item);
            wateringFreqAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            for(int i = 0; i < wateringFreq.size(); i++){
                wateringFreqAdapter.add(wateringFreq.get(i));
            }
            wateringFreqSpinner.setAdapter(wateringFreqAdapter);
        }catch (Exception e){
            e.printStackTrace();
        }
    }

}