package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.CropServiceRepository;
import at.fhooe.ServiceRepository.FieldServiceRepository;
import at.fhooe.ServiceRepository.TimePeriodsServiceRepository;
import com.google.gson.Gson;
import com.google.gson.JsonArray;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Date;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 5:56 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropViewModel {

    public int id;
    public String name;
    public String cropType;
    public Date timeOfPlanting;
    public byte[] avatearImage;
    public int wateringFreq;
    public String wateringPeriod;
    public Date harvestTime;
    public Date hillingTime;
    public Date fertilizingTime;
    public double fieldCoverage;
    public int fieldId;

    public String saveCrop(CropViewModel cropModel){
        String status = null;
        try{
            CropServiceRepository cropRep = new CropServiceRepository();
            status = cropRep.execute("/InsertCropData", cropModel).get();
        }catch(Exception e){
            e.printStackTrace();
        }
        return status;
    }

    public ArrayList<CropViewModel> getAllCrops(){
        String jsonResult = null;
        ArrayList<CropViewModel> crops = null;
        try{
            CropServiceRepository cropRep = new CropServiceRepository();
            jsonResult = cropRep.execute("/SelectCrops").get();
            JSONArray jsonArray = new JSONArray(jsonResult);
            crops = new ArrayList<CropViewModel>();
            for(int i=0; i<jsonArray.length(); i++){
                JSONObject jsonObj = jsonArray.getJSONObject(i);
                CropViewModel cropModel = new CropViewModel();
                cropModel.setCropType(jsonObj.getString("croptype"));
                cropModel.setFertilizingTime(new Date(ModelHelper.parseJsonDate(jsonObj.getString("fertilizingtime"))));
                cropModel.setHarvestTime(new Date(ModelHelper.parseJsonDate(jsonObj.getString("harvesttime"))));
                cropModel.setHillingTime(new Date(ModelHelper.parseJsonDate(jsonObj.getString("hillingtime"))));
                cropModel.setId(jsonObj.getInt("cropid"));
                cropModel.setName(jsonObj.getString("name"));
                cropModel.setTimeOfPlanting(new Date(ModelHelper.parseJsonDate(jsonObj.getString("timeofplanting"))));
                crops.add(cropModel);
            }
        }catch(Exception e){
            e.printStackTrace();
        }
        return crops;
    }

    public CropViewModel getCropById(int id){
        String jsonResult = null;
        CropViewModel cropModel = null;
        try{
            CropServiceRepository cropRep = new CropServiceRepository();
            jsonResult = cropRep.execute("/SelectCropById?crop_id="+id).get();
            JSONObject jsonCropObj = new JSONObject(jsonResult);
            cropModel = new CropViewModel();

            Gson gson = new Gson();
            byte[] avatarImage = gson.fromJson(jsonCropObj.getString("avatarimage"), byte[].class);

            cropModel.setAvatearImage(avatarImage);
            cropModel.setCropType(jsonCropObj.getString("croptype"));
            cropModel.setFertilizingTime(new Date(ModelHelper.parseJsonDate(jsonCropObj.getString("fertilizingtime"))));
            cropModel.setFieldCoverage(jsonCropObj.getDouble("fieldcoverage"));
            cropModel.setFieldId(jsonCropObj.getInt("fieldid"));
            cropModel.setHarvestTime(new Date(ModelHelper.parseJsonDate(jsonCropObj.getString("harvesttime"))));
            cropModel.setHillingTime(new Date(ModelHelper.parseJsonDate(jsonCropObj.getString("hillingtime"))));
            cropModel.setId(jsonCropObj.getInt("cropid"));
            cropModel.setName(jsonCropObj.getString("name"));
            cropModel.setTimeOfPlanting(new Date(ModelHelper.parseJsonDate(jsonCropObj.getString("timeofplanting"))));
            cropModel.setWateringFreq(jsonCropObj.getInt("wateringfrequency"));
            cropModel.setWateringPeriod(jsonCropObj.getString("wateringperiod"));



        }catch(Exception e){
            e.printStackTrace();
        }
        return cropModel;
    }

    public String deleteCrop(int id){
        String status = null;
        try{
            CropServiceRepository cropRep = new CropServiceRepository();
            status = cropRep.execute("/DeleteCropData", id).get();
        }catch(Exception e){
            e.printStackTrace();
        }
        return status;
    }


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCropType() {
        return cropType;
    }

    public void setCropType(String cropType) {
        this.cropType = cropType;
    }

    public Date getTimeOfPlanting() {
        return timeOfPlanting;
    }

    public void setTimeOfPlanting(Date timeOfPlanting) {
        this.timeOfPlanting = timeOfPlanting;
    }

    public byte[] getAvatearImage() {
        return avatearImage;
    }

    public void setAvatearImage(byte[] avatearImage) {
        this.avatearImage = avatearImage;
    }

    public int getWateringFreq() {
        return wateringFreq;
    }

    public void setWateringFreq(int wateringFreq) {
        this.wateringFreq = wateringFreq;
    }

    public String getWateringPeriod() {
        return wateringPeriod;
    }

    public void setWateringPeriod(String wateringPeriod) {
        this.wateringPeriod = wateringPeriod;
    }

    public Date getHarvestTime() {
        return harvestTime;
    }

    public void setHarvestTime(Date harvestTime) {
        this.harvestTime = harvestTime;
    }

    public Date getHillingTime() {
        return hillingTime;
    }

    public void setHillingTime(Date hillingTime) {
        this.hillingTime = hillingTime;
    }

    public Date getFertilizingTime() {
        return fertilizingTime;
    }

    public void setFertilizingTime(Date fertilizingTime) {
        this.fertilizingTime = fertilizingTime;
    }

    public double getFieldCoverage() {
        return fieldCoverage;
    }

    public void setFieldCoverage(double fieldCoverage) {
        this.fieldCoverage = fieldCoverage;
    }

    public int getFieldId() {
        return fieldId;
    }

    public void setFieldId(int fieldId) {
        this.fieldId = fieldId;
    }

    @Override
    public String toString(){
        return getName();
    }



}
