package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
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

    public void btnHandler(View v){
        switch (v.getId()){
            case R.id.addCropBtn:
                Intent toAddCrop = new Intent(this, AddCropActivity.class);
                startActivity(toAddCrop);
                break;
        }
    }
}