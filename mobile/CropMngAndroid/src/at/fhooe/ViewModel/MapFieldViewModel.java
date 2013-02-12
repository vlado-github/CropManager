package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.MapFieldServiceRepository;
import org.json.JSONArray;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 10:03 PM
 * To change this template use File | Settings | File Templates.
 */
public class MapFieldViewModel {
    private int mapFieldId;
    private int fieldId;
    private int mapId;

    public int[] getAllMapIdsByFieldId(int id){
        int[] mapIds = null;
        try{
            MapFieldServiceRepository mapFieldRep = new MapFieldServiceRepository();
            String stringIds = mapFieldRep.execute("/SelectMapRecordsByFieldId?field_id="+id).get();
            JSONArray jsonArray = new JSONArray(stringIds);
            mapIds = new int[jsonArray.length()];
            for(int i=0; i<jsonArray.length(); i++){
                mapIds[i] = jsonArray.getInt(i);
            }
        }catch(Exception e){
            e.printStackTrace();
        }
        return mapIds;
    }

    public int getMapId() {
        return mapId;
    }

    public void setMapId(int mapId) {
        this.mapId = mapId;
    }

    public int getFieldId() {
        return fieldId;
    }

    public void setFieldId(int fieldId) {
        this.fieldId = fieldId;
    }

    public int getMapFieldId() {
        return mapFieldId;
    }

    public void setMapFieldId(int mapFieldId) {
        this.mapFieldId = mapFieldId;
    }



}
