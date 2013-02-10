package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import at.fhooe.ViewModel.CropViewModel;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 2:34 PM
 * To change this template use File | Settings | File Templates.
 */
public class JournalActivity extends Activity {

    public Spinner cropSpinner = null;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.journal);

        cropSpinner = (Spinner) findViewById(R.id.cropSpinner);
        fillData();
    }

    public void fillData(){
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
        switch (v.getId()){
            case R.id.writeBtn:
                Intent toWrite = new Intent(this, JournalWriteActivity.class);
                toWrite.putExtra("cropid", ((CropViewModel) cropSpinner.getSelectedItem()).getId());
                startActivity(toWrite);
                break;
            case R.id.readBtn:
                Intent toRead = new Intent(this, JournalReadActivity.class);
                toRead.putExtra("cropid", ((CropViewModel) cropSpinner.getSelectedItem()).getId());
                startActivity(toRead);
                break;
            case R.id.cancelBtn:
                Intent toMainView = new Intent(this, MainActivity.class);
                startActivity(toMainView);
                break;
        }
    }
}