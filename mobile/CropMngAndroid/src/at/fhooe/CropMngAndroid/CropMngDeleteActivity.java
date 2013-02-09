package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;
import at.fhooe.ViewModel.CropViewModel;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/9/13
 * Time: 2:50 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropMngDeleteActivity extends Activity {

    public Spinner cropSpinner = null;
    public Button deleteBtn = null;
    public Button cancelBtn = null;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngdelete);

        cropSpinner = (Spinner) findViewById(R.id.cropsSpinner);
        deleteBtn = (Button) findViewById(R.id.deleteBtn);
        cancelBtn = (Button) findViewById(R.id.cancelBtn);

        fillSpinnerData();
    }

    public void fillSpinnerData(){
        CropViewModel cropModel = new CropViewModel();
        ArrayList<CropViewModel> crops = cropModel.getAllCrops();
        ArrayAdapter<CropViewModel> adapter = new ArrayAdapter<CropViewModel>(this, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        for (int i = 0; i < crops.size(); ++i) {
            adapter.add(crops.get(i));
        }
        cropSpinner.setAdapter(adapter);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.deleteBtn:
                int id = ((CropViewModel) cropSpinner.getSelectedItem()).getId();
                CropViewModel cropModel = new CropViewModel();
                String status = cropModel.deleteCrop(id);
                if(!status.equals("200")) {
                    Toast.makeText(this, "Error - delete unsuccessful", Toast.LENGTH_SHORT).show();
                    fillSpinnerData();
                }else{
                    Toast.makeText(this, "Delete successful", Toast.LENGTH_SHORT).show();
                }
                break;
            case R.id.cancelBtn:
                Intent toCropMng = new Intent(this, CropMngActivity.class);
                startActivity(toCropMng);
                break;
        }
    }





}