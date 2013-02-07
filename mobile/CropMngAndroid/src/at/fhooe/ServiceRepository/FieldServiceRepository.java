package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import at.fhooe.ViewModel.FieldViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 5:59 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldServiceRepository extends AsyncTask<String, Void, String> {

    private static final String GetFieldsSVCUri = "http://10.0.2.2:81/FieldService.svc/web";
    private String result;

    @Override
    protected String doInBackground(String... string) {
        if(string[0].contains("SelectFields")){
            return getAllFields(string[0]);
        }else if(string[0].contains("SelectFieldById")){
            return getFieldById(string[0]);
        }else{
            return null;
        }
    }

    // Gets all field records
    protected String getAllFields(String action){
        String result = "";
        try{
            HttpGet request = new HttpGet(GetFieldsSVCUri+ action);
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

    protected String getFieldById(String action){
        String result = "";
        try{
            HttpGet request = new HttpGet(GetFieldsSVCUri + action);
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
