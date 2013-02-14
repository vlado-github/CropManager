package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.ViewModel.TaskViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/13/13
 * Time: 10:24 PM
 * To change this template use File | Settings | File Templates.
 */
public class TaskServiceRepository extends AsyncTask<String, Void, String> {
    private static final String messageUrl="https://api.twitter.com/1/statuses/user_timeline.json?screen_name=";
    private String result;

    @Override
    protected String doInBackground(String... strings) {
        String username = strings[0];
        return getMessages(username);
    }

    public String getMessages(String username){
        String result = null;
        try{
            HttpGet request = new HttpGet(messageUrl + username + "&count=5");
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

            DefaultHttpClient httpClient = new DefaultHttpClient();
            HttpResponse response = httpClient.execute(request);

            HttpEntity responseEntity = response.getEntity();

            // Read response data into buffer
            char[] buffer = new char[(int)responseEntity.getContentLength()];
            InputStream stream = responseEntity.getContent();
            InputStreamReader reader = new InputStreamReader(stream);
            reader.read(buffer);
            stream.close();

            result = new String(buffer);
        }catch(Exception e){
            e.printStackTrace();
        }
        return result;
    }

    @Override
    protected void onPostExecute(String result) {
        this.result = result;
    }
}
