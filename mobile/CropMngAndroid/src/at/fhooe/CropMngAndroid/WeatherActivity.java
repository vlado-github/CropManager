package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
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
        for(int i=0; i<weatherInfo.size(); i++){
            TableRow tr = new TableRow(this);
            tr.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,
                    TableRow.LayoutParams.WRAP_CONTENT));
            addToView(weatherInfo.get(i).getDayTime(), tr);
            addToView(weatherInfo.get(i).getCondition(), tr);
            addToView(weatherInfo.get(i).getTempCMin(), tr);
            addToView(weatherInfo.get(i).getTempCMax(), tr);
            addToView(weatherInfo.get(i).getWind(), tr);
            layout.addView(tr, new TableLayout.LayoutParams(TableLayout.LayoutParams.WRAP_CONTENT,
                    TableLayout.LayoutParams.WRAP_CONTENT));
        }
    }

    private void addToView(String value, TableRow tr){
        TextView tv = new TextView(this);
        tv.setText(value);
        tv.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,
                TableRow.LayoutParams.WRAP_CONTENT));
        tr.addView(tv);
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