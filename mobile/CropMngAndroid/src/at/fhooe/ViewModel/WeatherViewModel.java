package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.WeatherServiceRepository;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 5:57 PM
 * To change this template use File | Settings | File Templates.
 */
public class WeatherViewModel {
    public String City;
    public String DayTime;
    public String Condition;
    public String TempFMin;
    public String TempFMax;
    public String TempCMin;
    public String TempCMax;
    public String Humidity;
    public String Wind;

    public ArrayList<WeatherViewModel> getWeatherInfo(String city, String country){
        ArrayList<WeatherViewModel> weatherInfo = null;
        String weatherJson = null;
        try{
            WeatherServiceRepository weatherRep = new WeatherServiceRepository();
            weatherJson = (String) weatherRep.execute(new String[]{city, country}).get();
            weatherInfo = parseWeatherJson(weatherJson);
        }catch(Exception e){
            e.printStackTrace();
        }
        return weatherInfo;
    }

    public ArrayList<WeatherViewModel> parseWeatherJson(String json){
        ArrayList<WeatherViewModel> weatherInfo = null;
        try{
            JSONObject jsonObj = new JSONObject(json);
            JSONArray currentWeather = jsonObj.getJSONObject("data").getJSONArray("current_condition");
            JSONArray futureWeather = jsonObj.getJSONObject("data").getJSONArray("weather");
            WeatherViewModel currentWeatherModel = new WeatherViewModel();
            String weatherCurDesc = currentWeather.getJSONObject(0).getJSONArray("weatherDesc").getJSONObject(0).getString("value");
            String dayTime = currentWeather.getJSONObject(0).getString("observation_time");
            String temp = currentWeather.getJSONObject(0).getString("temp_C");
            String windCurDir = currentWeather.getJSONObject(0).getString("winddir16Point");
            String windCurSpeed = currentWeather.getJSONObject(0).getString("windspeedKmph");

            currentWeatherModel.setCondition(weatherCurDesc);
            currentWeatherModel.setDayTime(dayTime);
            currentWeatherModel.setTempCMin(temp);
            currentWeatherModel.setTempCMax("");
            currentWeatherModel.setWind(">"+windCurDir+" "+windCurSpeed+"kmph");

            weatherInfo = new ArrayList<WeatherViewModel>();
            weatherInfo.add(currentWeatherModel);


            for(int i=0; i<futureWeather.length(); i++){
                WeatherViewModel weatherDailyData = new WeatherViewModel();
                String date = futureWeather.getJSONObject(i).getString("date");
                String weatherDesc = futureWeather.getJSONObject(i).getJSONArray("weatherDesc").getJSONObject(0).getString("value");
                String tempMin = futureWeather.getJSONObject(i).getString("tempMinC");
                String tempMax = futureWeather.getJSONObject(i).getString("tempMaxC");
                String windDir = futureWeather.getJSONObject(i).getString("winddir16Point");
                String windSpeed = futureWeather.getJSONObject(i).getString("windspeedKmph");
                weatherDailyData.setDayTime(date);
                weatherDailyData.setCondition(weatherDesc);
                weatherDailyData.setTempCMin(tempMin);
                weatherDailyData.setTempCMax(tempMax);
                weatherDailyData.setWind(">"+windDir+" "+windSpeed+"kmph");
                weatherInfo.add(weatherDailyData);
            }

        }catch(Exception e){
            e.printStackTrace();
        }
        return weatherInfo;
    }

    public String getDayTime() {
        return DayTime;
    }

    public void setDayTime(String dayTime) {
        DayTime = dayTime;
    }

    public String getCondition() {
        return Condition;
    }

    public void setCondition(String condition) {
        Condition = condition;
    }

    public String getTempFMin() {
        return TempFMin;
    }

    public void setTempFMin(String tempFMin) {
        TempFMin = tempFMin;
    }

    public String getTempFMax() {
        return TempFMax;
    }

    public void setTempFMax(String tempFMax) {
        TempFMax = tempFMax;
    }

    public String getTempCMin() {
        return TempCMin;
    }

    public void setTempCMin(String tempCMin) {
        TempCMin = tempCMin;
    }

    public String getTempCMax() {
        return TempCMax;
    }

    public void setTempCMax(String tempCMax) {
        TempCMax = tempCMax;
    }

    public String getHumidity() {
        return Humidity;
    }

    public void setHumidity(String humidity) {
        Humidity = humidity;
    }

    public String getWind() {
        return Wind;
    }

    public void setWind(String wind) {
        Wind = wind;
    }

    public String getCity() {
        return City;
    }

    public void setCity(String city) {
        City = city;
    }
}
