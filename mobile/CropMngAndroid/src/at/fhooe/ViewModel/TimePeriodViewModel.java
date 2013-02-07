package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.FieldServiceRepository;
import at.fhooe.ServiceRepository.TimePeriodsServiceRepository;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/7/13
 * Time: 3:07 PM
 * To change this template use File | Settings | File Templates.
 */
public class TimePeriodViewModel {
    public int Id;
    public String type;

    public ArrayList<TimePeriodViewModel> getAllTimePeriods(){
        ArrayList<TimePeriodViewModel> timePeriods = null;
        String jsonResult;
        try{
            TimePeriodsServiceRepository timePeriodSvc = new TimePeriodsServiceRepository();
            jsonResult = timePeriodSvc.execute("/SelectAllTimePeriods").get();
            JSONArray jsonArray = new JSONArray(jsonResult);
            timePeriods = new ArrayList<TimePeriodViewModel>();
            for(int i=0; i<jsonArray.length(); i++){
                JSONObject jsonObj = jsonArray.getJSONObject(i);
                TimePeriodViewModel timePeriod = new TimePeriodViewModel();
                timePeriod.setId(jsonObj.getInt("timeperiodid"));
                timePeriod.setType(jsonObj.getString("type"));
                timePeriods.add(timePeriod);
            }
        }catch(Exception e){
            e.printStackTrace();
        }
        return timePeriods;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    @Override
    public String toString(){
        return getType();
    }

}
