package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.MapServiceRepository;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 10:29 PM
 * To change this template use File | Settings | File Templates.
 */
public class MapViewModel {

    private int mapId;
    private double longitude;
    private double latitude;
    private int fieldId;

    public MapViewModel getMapById(int id){
        MapViewModel map = new MapViewModel();
        try{
            MapServiceRepository mapRep = new MapServiceRepository();
            String jsonResult = mapRep.execute("/SelectMapById?map_id="+id).get();
            JSONObject jsonObj = new JSONObject(jsonResult);
            map.setFieldId(jsonObj.getInt("field_fk"));
            map.setLatitude(jsonObj.getDouble("latitude"));
            map.setLongitude(jsonObj.getDouble("longitude"));
            map.setMapId(jsonObj.getInt("mapid"));
        }catch(Exception e){
            e.printStackTrace();
        }
        return map;
    }

    public int getMapId() {
        return mapId;
    }

    public void setMapId(int mapId) {
        this.mapId = mapId;
    }

    public double getLongitude() {
        return longitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public double getLatitude() {
        return latitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public int getFieldId() {
        return fieldId;
    }

    public void setFieldId(int fieldId) {
        this.fieldId = fieldId;
    }

}
