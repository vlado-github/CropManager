package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import at.fhooe.ViewModel.CropViewModel;
import at.fhooe.ViewModel.FieldViewModel;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 8:37 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldDetailsActivity extends Activity {
    public Spinner fieldSpinner;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fielddetails);
        fieldSpinner = (Spinner) findViewById(R.id.fieldDetailsSpinner);
        fillData();
    }

    private void fillData(){
        FieldViewModel fieldViewModel = new FieldViewModel();
        ArrayList<FieldViewModel> fields = fieldViewModel.getAllFields();

        ArrayAdapter<FieldViewModel> adapter = new ArrayAdapter<FieldViewModel>(this, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        for (int i = 0; i < fields.size(); ++i) {
            adapter.add(fields.get(i));
        }
        fieldSpinner.setAdapter(adapter);
    }

    public void btnHandler(View v){
        switch (v.getId()){
            case R.id.loadFieldMap:
                Intent toMap = new Intent(this, FieldDetailsMapActivity.class);
                toMap.putExtra("fieldid",((FieldViewModel)fieldSpinner.getSelectedItem()).getId());
                startActivity(toMap);
                break;
            case R.id.cancelBtn:
                Intent i = new Intent(this, CropMngActivity.class);
                startActivity(i);
                break;
        }
    }

}