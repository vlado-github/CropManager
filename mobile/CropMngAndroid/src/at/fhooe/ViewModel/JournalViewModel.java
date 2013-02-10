package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.CropServiceRepository;
import at.fhooe.ServiceRepository.JournalServiceRepository;
import com.google.gson.Gson;
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
public class JournalViewModel {
    private int journalid;
    private Date journalDate;
    private String desc;
    private byte[] photo;
    private int cropid;

    public String saveJournal(JournalViewModel journal){
        String status = null;
        try{
            JournalServiceRepository journalRep = new JournalServiceRepository();
            status = journalRep.execute("/InsertJournal", journal).get();
        }catch(Exception e){
            e.printStackTrace();
        }
        return status;
    }

    public ArrayList<JournalViewModel> getJournal(int cropid){
        String jsonResult = null;
        ArrayList<JournalViewModel> journals = null;
        try{
            JournalServiceRepository journalRep = new JournalServiceRepository();
            jsonResult = journalRep.execute("/SelectJournalByCropId?crop_id="+cropid).get();
            JSONArray jsonArray = new JSONArray(jsonResult);
            journals = new ArrayList<JournalViewModel>();
            for(int i=0; i<jsonArray.length(); i++){
                JSONObject jsonObj = jsonArray.getJSONObject(i);
                JournalViewModel journalModel = new JournalViewModel();
                journalModel.setJournalid(jsonObj.getInt("journalid"));
                journalModel.setDesc(jsonObj.getString("description"));
                journalModel.setJournalDate(new Date(ModelHelper.parseJsonDate(jsonObj.getString("dateentered"))));
                //journalModel.setPhoto();
                journalModel.setCropid(jsonObj.getInt("cropid"));

                journals.add(journalModel);
            }
        }catch(Exception e){
            e.printStackTrace();
        }
        return journals;
    }

    public int getJournalid() {
        return journalid;
    }

    public void setJournalid(int journalid) {
        this.journalid = journalid;
    }

    public Date getJournalDate() {
        return journalDate;
    }

    public void setJournalDate(Date journalDate) {
        this.journalDate = journalDate;
    }

    public String getDesc() {
        return desc;
    }

    public void setDesc(String desc) {
        this.desc = desc;
    }

    public int getCropid() {
        return cropid;
    }

    public void setCropid(int cropid) {
        this.cropid = cropid;
    }

    public byte[] getPhoto(){
        return photo;
    }

    public void setPhoto(byte[] photo){
        this.photo = photo;
    }
}
