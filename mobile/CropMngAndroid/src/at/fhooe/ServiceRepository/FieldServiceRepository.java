package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import at.fhooe.ViewModel.FieldViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONStringer;

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
public class FieldServiceRepository extends AsyncTask<Object, Void, String> {

    private static final String GetFieldsSVCUri = "http://10.0.2.2:81/FieldService.svc/web";
    private String result;

    @Override
    protected String doInBackground(Object... objs) {
        String action = (String) objs[0];
        if(action.contains("SelectFields")){
            return getAllFields(action);
        }else if(action.contains("SelectFieldById")){
            return getFieldById(action);
        }else if(action.contains("InsertField")){
            FieldViewModel fieldModel = (FieldViewModel) objs[1];
            return saveField(action, fieldModel);
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

    protected String saveField(String action, FieldViewModel fieldModel){
        String returnVal = null;
        try{
            // POST request to <service>/SaveCrop
            HttpPost request = new HttpPost(GetFieldsSVCUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

            // Build JSON string
            JSONStringer crop = new JSONStringer()
                    .object()
                    .key("field")
                    .object()
                    .key("Id").value(0)
                    .key("Name").value(fieldModel.name)
                    .key("Altitude").value(fieldModel.altitude)
                    .key("AreaSize").value(fieldModel.areaSize)
                    .key("AreaSizeMeasure").value(fieldModel.areaSizeMeasure)
                    .key("Map_fk").value(fieldModel.map_fk)
                    .key("Crop_fk").value(fieldModel.crop_fk)
                    .endObject()
                    .endObject();
            StringEntity entity = new StringEntity(crop.toString());

            request.setEntity(entity);

            // Send request to WCF service
            DefaultHttpClient httpClient = new DefaultHttpClient();
            HttpResponse response = httpClient.execute(request);
            HttpEntity httpEntity = response.getEntity();
            returnVal = EntityUtils.toString(httpEntity);
        }catch(Exception e){
            e.printStackTrace();
        }
        return returnVal;
    }

    @Override
    protected void onPostExecute(String result) {
        this.result = result;
    }

}
