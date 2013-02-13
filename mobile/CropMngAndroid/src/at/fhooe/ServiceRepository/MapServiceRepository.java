package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.ViewModel.MapViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONStringer;

import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 9:12 PM
 * To change this template use File | Settings | File Templates.
 */
public class MapServiceRepository extends AsyncTask<Object, Void, String> {
    public static final String svcUri = "http://10.0.2.2:81/MapService.svc/web";
    public String result;

    @Override
    protected String doInBackground(Object... objs) {
        String action = (String) objs[0];
        if(action.contains("SelectMapById")){
            return getAllMapRecordsById(action);
        }else if(action.contains("InsertMap")){
            return saveMap(action, (MapViewModel) objs[1]);
        }else{
            return null;
        }
    }

    public String getAllMapRecordsById(String action){
        try{
            HttpGet request = new HttpGet(svcUri+ action);
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

    public String saveMap(String action, MapViewModel map){
        String returnVal = null;
        try{
            // POST request to <service>/SaveCrop
            String s = svcUri + action;
            HttpPost request = new HttpPost(svcUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");
            request.setHeader("User-Agent", "Fiddler");

            // Build JSON string
            JSONStringer mapJson = new JSONStringer()
                    .object()
                    .key("map")
                    .object()
                    .key("mapid").value(0)
                    .key("longitude").value(map.getLongitude())
                    .key("latitude").value(map.getLatitude())
                    .key("field_fk").value(map.getFieldId())
                    .endObject()
                    .endObject();
            StringEntity entity = new StringEntity(mapJson.toString());

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
