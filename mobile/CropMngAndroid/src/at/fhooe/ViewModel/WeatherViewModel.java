package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.WeatherServiceRepository;

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
        try{
            WeatherServiceRepository weatherRep = new WeatherServiceRepository();
            weatherInfo = (ArrayList<WeatherViewModel>) weatherRep.execute(new String[]{city, country}).get();
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
