package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TableLayout;
import at.fhooe.ViewModel.WeatherViewModel;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 2:36 PM
 * To change this template use File | Settings | File Templates.
 */
public class WeatherActivity extends Activity {
    public TableLayout layout;
    public EditText cityTxt;
    public EditText countryTxt;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.weather);

        layout = (TableLayout) findViewById(R.id.weatherLayout);
        cityTxt = (EditText) findViewById(R.id.cityTxt);
        countryTxt = (EditText) findViewById(R.id.countryTxt);
    }

    public void loadData(String city, String country){
        WeatherViewModel weatherModel = new WeatherViewModel();
        ArrayList<WeatherViewModel> weatherInfo = weatherModel.getWeatherInfo(city,country);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.ldBtn:
                String city = cityTxt.getText().toString();
                String country = countryTxt.getText().toString();
                loadData(city, country);
                break;
        }
    }

}