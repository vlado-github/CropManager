package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends Activity {
    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.cropMngBtn:
                Intent toCropMng = new Intent(this, CropMngActivity.class);
                startActivity(toCropMng);
                break;
            case R.id.journalBtn:
                Intent toJournal = new Intent(this, JournalActivity.class);
                startActivity(toJournal);
                break;
            case R.id.notificationBtn:
                break;
            case R.id.weatherBtn:
                Intent toWeather = new Intent(this, WeatherActivity.class);
                startActivity(toWeather);
                break;
        }
    }

}
