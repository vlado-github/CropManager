package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
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

import java.io.*;
import java.net.URL;
import java.net.URLConnection;
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
    public TextView coverageValue;
    public SeekBar coverageSlider;
    public DatePicker harvestingTime;
    public DatePicker hillingTime;
    public DatePicker fertilizingTime;
    public Uri imageUri;
    public byte[] imageBytes = null;

    final int TAKE_PICTURE = 115;


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
        coverageValue = (TextView) findViewById(R.id.coverageValueLbl);
        coverageSlider = (SeekBar) findViewById(R.id.coverageValue);
        coverageSlider.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                coverageValue.setText(seekBar.getProgress()+"%");
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
        harvestingTime = (DatePicker) findViewById(R.id.harvestTime);
        hillingTime = (DatePicker) findViewById(R.id.hillingTime);
        fertilizingTime = (DatePicker) findViewById(R.id.fertillizingTime);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.photoBtn:
                Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                File photoFile = new File(Environment.getExternalStorageDirectory(),  "Photo"+new Date().getTime()+".jpg");
                intent.putExtra(MediaStore.EXTRA_OUTPUT,
                        Uri.fromFile(photoFile));
                imageUri = Uri.fromFile(photoFile);
                startActivityForResult(intent, TAKE_PICTURE);
                break;
            case R.id.saveBtn:
                CropViewModel cropModel = new CropViewModel();
                cropModel.setName(nameTxt.getText().toString());
                cropModel.setCropType(typeTxt.getText().toString());
                cropModel.setTimeOfPlanting(Helpers.convertToDate(timeOfPlantingDate));
                cropModel.setAvatearImage(imageBytes);
                cropModel.setWateringFreq(Integer.parseInt((String)wateringFreqSpinner.getSelectedItem()));
                cropModel.setWateringPeriod(String.valueOf(((TimePeriodViewModel)timePeriodsSpinner.getSelectedItem()).getId()));
                cropModel.setHarvestTime(Helpers.convertToDate(harvestingTime));
                cropModel.setHillingTime(Helpers.convertToDate(hillingTime));
                cropModel.setFertilizingTime(Helpers.convertToDate(fertilizingTime));
                cropModel.setFieldCoverage(coverageSlider.getProgress());
                cropModel.setFieldId(((FieldViewModel) fieldSpinner.getSelectedItem()).getId());

                String status = cropModel.saveCrop(cropModel);
                if(status != "200"){
                    Toast.makeText(this,"Error - Save unsuccessful", 2).show();
                }else{
                    Toast.makeText(this,"Save successful", 2).show();
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


    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        switch (requestCode) {
            case TAKE_PICTURE:
                if (resultCode == Activity.RESULT_OK) {
                    Uri selectedImageUri = imageUri;
                    photoUri.setText(selectedImageUri.toString());
                    Uri imageUri = data.getData();
                    Bitmap bitmap = null;
                    try {
                        bitmap = MediaStore.Images.Media.getBitmap(this.getContentResolver(), imageUri);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }

                    ByteArrayOutputStream stream = new ByteArrayOutputStream();
                    bitmap.compress(Bitmap.CompressFormat.JPEG, 70, stream);
                    imageBytes = stream.toByteArray();
                }
        }
    }

}