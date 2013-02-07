package at.fhooe.ViewModel;

import android.widget.Toast;
import at.fhooe.ServiceRepository.FieldServiceRepository;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 5:58 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldViewModel {
    public int id;
    public String name;
    public double altitude;
    public double areaSize;
    public String areaSizeMeasure;
    public int map_fk;
    public int crop_fk;

    String jsonResult;

    //Get all fields
    public ArrayList<FieldViewModel> getAllFields(){
        ArrayList<FieldViewModel> fields = null;
        try{
            FieldServiceRepository fieldsSvc = new FieldServiceRepository();
            jsonResult = fieldsSvc.execute("/SelectFields").get();
            JSONArray jsonArray = new JSONArray(jsonResult);
            fields = new ArrayList<FieldViewModel>();
            for(int i=0; i<jsonArray.length(); i++){
                JSONObject jsonObj = jsonArray.getJSONObject(i);
                FieldViewModel field = new FieldViewModel();
                field.setAltitude(jsonObj.getDouble("Altitude"));
                field.setAreaSize(jsonObj.getDouble("AreaSize"));
                field.setAreaSizeMeasure(jsonObj.getString("AreaSizeMeasure"));
                field.setName(jsonObj.getString("Name"));
                field.setMap_fk(jsonObj.getInt("Map_fk"));
                field.setCrop_fk(jsonObj.getInt("Crop_fk"));
                field.setId(jsonObj.getInt("Id"));
                fields.add(field);
            }
        }catch (Exception e){
            e.printStackTrace();
        }

        return fields;
    }

    //Get field by id
    public FieldViewModel getFieldById(int id){
        FieldViewModel field = null;
        try{
            FieldServiceRepository fieldsSvc = new FieldServiceRepository();
            jsonResult = fieldsSvc.execute("/SelectFieldById?field_id="+id).get();
            JSONObject jsonObj = new JSONObject(jsonResult);
            field = new FieldViewModel();
            field.setAltitude(jsonObj.getInt("Altitude"));
            field.setAreaSize(jsonObj.getDouble("AreaSize"));
            field.setAreaSizeMeasure(jsonObj.getString("AreaSizeMeasure"));
            field.setName(jsonObj.getString("Name"));
            field.setCrop_fk(jsonObj.getInt("Crop_fk"));
            field.setMap_fk(jsonObj.getInt("Map_fk"));
        }catch(Exception e){
            e.printStackTrace();
        }

        return field;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getCrop_fk() {
        return crop_fk;
    }

    public void setCrop_fk(int crop_fk) {
        this.crop_fk = crop_fk;
    }

    public int getMap_fk() {
        return map_fk;
    }

    public void setMap_fk(int map_fk) {
        this.map_fk = map_fk;
    }

    public String getAreaSizeMeasure() {
        return areaSizeMeasure;
    }

    public void setAreaSizeMeasure(String areaSizeMeasure) {
        this.areaSizeMeasure = areaSizeMeasure;
    }

    public double getAreaSize() {
        return areaSize;
    }

    public void setAreaSize(double areaSize) {
        this.areaSize = areaSize;
    }

    public double getAltitude() {
        return altitude;
    }

    public void setAltitude(double altitude) {
        this.altitude = altitude;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }


    @Override
    public String toString() {
        return getName();
    }
}
