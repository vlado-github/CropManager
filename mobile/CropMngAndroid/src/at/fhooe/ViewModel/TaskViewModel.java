package at.fhooe.ViewModel;

import at.fhooe.ServiceRepository.TaskServiceRepository;
import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/13/13
 * Time: 10:33 PM
 * To change this template use File | Settings | File Templates.
 */
public class TaskViewModel {
    private String username;
    private String message;
    private String imageUrl;

    public ArrayList<TaskViewModel> getMessages(String username){
        ArrayList<TaskViewModel> tweets = null;
        try{
            TaskServiceRepository taskRep = new TaskServiceRepository();
            String msgs = taskRep.execute(username).get();
            tweets = getTasksFromJson(msgs);
        }catch(Exception e){
            e.printStackTrace();
        }
        return tweets;
    }

    private ArrayList<TaskViewModel> getTasksFromJson(String json){
        ArrayList<TaskViewModel> tasks = new ArrayList<TaskViewModel>();
        try{
            JSONArray jsonArray = new JSONArray(json);
            for(int i=0; i<jsonArray.length(); i++){
                TaskViewModel taskModel = new TaskViewModel();
                JSONObject jsonObj = jsonArray.getJSONObject(i);
                taskModel.setUsername(jsonObj.getJSONObject("user").getString("name"));
                taskModel.setMessage(jsonObj.getString("text"));
                taskModel.setImageUrl(jsonObj.getJSONObject("user").getString("profile_image_url"));
                tasks.add(taskModel);
            }
        }catch(Exception e){
            e.printStackTrace();
        }
        return tasks;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getImageUrl() {
        return imageUrl;
    }

    public void setImageUrl(String imageUrl) {
        this.imageUrl = imageUrl;
    }
}
