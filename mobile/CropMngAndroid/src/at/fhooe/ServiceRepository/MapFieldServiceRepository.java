package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.ViewModel.CropViewModel;
import at.fhooe.ViewModel.MapFieldViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
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
public class MapFieldServiceRepository extends AsyncTask<Object, Void, String>{
    public static final String svcUri = "http://10.0.2.2:81/MapFieldService.svc/web";
    public String result;

    @Override
    protected String doInBackground(Object... objs) {
        String action = (String) objs[0];
        if(action.contains("SelectMapRecordsByFieldId")){
            return getAllMapRecordsByFieldId(action);
        }else if(action.contains("InsertMapField")){
            return saveMapField(action, (MapFieldViewModel) objs[1]);
        }else{
            return null;
        }
    }

    public String getAllMapRecordsByFieldId(String action){
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

    protected String saveMapField(String action, MapFieldViewModel mapFieldModel){
        int statusCode = 400;
        try{
            // POST request to <service>/SaveCrop
            HttpPost request = new HttpPost(svcUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

            // Build JSON string
            JSONStringer mapFieldModelJson = new JSONStringer()
                    .object()
                    .key("mapField")
                    .object()
                    .key("mapfieldid").value(0)
                    .key("fieldid").value(mapFieldModel.getFieldId())
                    .key("mapid").value(mapFieldModel.getMapId())
                    .endObject()
                    .endObject();
            StringEntity entity = new StringEntity(mapFieldModelJson.toString());

            request.setEntity(entity);

            // Send request to WCF service
            DefaultHttpClient httpClient = new DefaultHttpClient();
            HttpResponse response = httpClient.execute(request);

            statusCode = response.getStatusLine().getStatusCode();

        }catch(Exception e){
            e.printStackTrace();
        }
        return String.valueOf(statusCode);
    }

    @Override
    protected void onPostExecute(String result) {
        this.result = result;
    }

}
