package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import at.fhooe.ViewModel.CropViewModel;
import at.fhooe.ViewModel.FieldViewModel;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/8/13
 * Time: 8:39 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropMngDetailsActivity extends Activity {
    public static final String TO_CROPMNGDETAILSPAGE = "tocropmngdeatils";

    public Spinner cropSpinner = null;
    public Button loadDetailsBtn = null;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngdetails);

        CropViewModel cropModel = new CropViewModel();
        ArrayList<CropViewModel> crops = cropModel.getAllCrops();

        cropSpinner = (Spinner)findViewById(R.id.cropsSpinner);
        loadDetailsBtn = (Button)findViewById(R.id.loadDetailsBtn);

        ArrayAdapter<CropViewModel> adapter = new ArrayAdapter<CropViewModel>(this, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        for (int i = 0; i < crops.size(); ++i) {
            adapter.add(crops.get(i));
        }
        cropSpinner.setAdapter(adapter);
    }

    public void btnHandler(View v){
        switch (v.getId()){
            case R.id.loadDetailsBtn:
                Intent toCropDetailsPage = new Intent(this, CropMngDetailsPageActivity.class);
                CropViewModel cropModel = (CropViewModel)cropSpinner.getSelectedItem();
                int cropId = cropModel.getId();
                toCropDetailsPage.putExtra(TO_CROPMNGDETAILSPAGE,cropId);
                startActivity(toCropDetailsPage);
                break;
            case R.id.cancelBtn:
                Intent toCropMng = new Intent(this, CropMngActivity.class);
                startActivity(toCropMng);
                break;
        }
    }
}