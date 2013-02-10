package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 2:33 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropMngActivity extends Activity {
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmng);
    }

    @Override
    public void onBackPressed() {
        Intent toMain = new Intent(this, MainActivity.class);
        startActivity(toMain);
    }

    public void btnHandler(View v){
        switch (v.getId()){
            case R.id.addCropBtn:
                Intent toAddCrop = new Intent(this, AddCropActivity.class);
                startActivity(toAddCrop);
                break;
            case R.id.cropDetailsBtn:
                Intent toCropDetails = new Intent(this, CropMngDetailsActivity.class);
                startActivity(toCropDetails);
                break;
            case R.id.removeCropBtn:
                Intent toCropDelete = new Intent(this, CropMngDeleteActivity.class);
                startActivity(toCropDelete);
                break;
            case R.id.addFieldBtn:
                Intent toAddField = new Intent(this, AddFieldActivity.class);
                startActivity(toAddField);
                break;
            case R.id.fieldDetailsBtn:
                break;
        }
    }
}