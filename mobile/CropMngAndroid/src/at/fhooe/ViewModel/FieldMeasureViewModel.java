package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.FieldMeasureServiceRepository;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/9/13
 * Time: 10:04 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldMeasureViewModel {

    private int id;
    private String type;

    public ArrayList<FieldMeasureViewModel> getAllFieldMeasures(){
        ArrayList<FieldMeasureViewModel> fieldMeasures = null;
        try{
            FieldMeasureServiceRepository fieldMeasureRep = new FieldMeasureServiceRepository();
            String jsonResult = fieldMeasureRep.execute("/GetAllMeasures").get();
            JSONArray jsonArray = new JSONArray(jsonResult);
            fieldMeasures = new ArrayList<FieldMeasureViewModel>();
            for(int i=0; i<jsonArray.length(); i++){
                JSONObject jsonObj = jsonArray.getJSONObject(i);
                FieldMeasureViewModel fieldMeasure = new FieldMeasureViewModel();
                fieldMeasure.setId(jsonObj.getInt("measureid"));
                fieldMeasure.setType(jsonObj.getString("type"));
                fieldMeasures.add(fieldMeasure);
            }
        }catch(Exception e){
            e.printStackTrace();
        }
        return fieldMeasures;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
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
