package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.CropMngAndroid.Helpers;
import at.fhooe.ViewModel.CropViewModel;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONObject;
import org.json.JSONStringer;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.nio.IntBuffer;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 5:58 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropServiceRepository extends AsyncTask<Object, Void, String>{
    private static final String CropSvcUri = "http://10.0.2.2:81/CropService.svc/web";
    private String result;

    @Override
    protected String doInBackground(Object... objects) {
        String action = (String)objects[0];

        if(action.contains("InsertCropData"))
        {
            CropViewModel cropModel = (CropViewModel) objects[1];
            return saveCropServiceRepository(action, cropModel);
        }else if(action.contains("DeleteCropData")) {
            int id = (Integer) objects[1];
            return deleteCropServiceRepository(action,id);
        }else if(action.contains("SelectCrops")){
            return getAllCrops(action);
        }else if(action.contains("SelectCropById")){
            return getCropById(action);
        }else{
            return null;
        }
    }

    protected String saveCropServiceRepository(String action, CropViewModel cropModel){
        int statusCode = 400;
        try{
            // POST request to <service>/SaveCrop
            HttpPost request = new HttpPost(CropSvcUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

             byte[] b = new byte[0];
            // Build JSON string
            JSONStringer crop = new JSONStringer()
                    .object()
                    .key("crop")
                    .object()
                    .key("cropid").value(0)
                    .key("name").value(cropModel.getName())
                    .key("croptype").value(cropModel.getCropType())
                    .key("timeofplanting").value("/Date("+cropModel.getTimeOfPlanting().getTime()+")/")
                    .key("avatarimage").value(null)
                    .key("wateringfrequency").value(cropModel.getWateringFreq())
                    .key("wateringperiod").value(cropModel.getWateringPeriod())
                    .key("harvesttime").value("/Date("+cropModel.getHarvestTime().getTime()+")/")
                    .key("hillingtime").value("/Date("+cropModel.getHillingTime().getTime()+")/")
                    .key("fertilizingtime").value("/Date("+cropModel.getFertilizingTime().getTime()+")/")
                    .key("fieldcoverage").value(cropModel.getFieldCoverage())
                    .key("fieldid").value(cropModel.getFieldId())
                    .endObject()
                    .endObject();
            StringEntity entity = new StringEntity(crop.toString());

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

    protected String deleteCropServiceRepository(String action, int id){
        int statusCode = 400;
        try{
            // POST request to <service>/DeleteCrop
            HttpPost request = new HttpPost(CropSvcUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

            // Build JSON string
            JSONStringer idParam = new JSONStringer()
                    .object()
                    .key("crop_id").value(id)
                    .endObject();
            StringEntity entity = new StringEntity(idParam.toString());

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

    protected String getAllCrops(String action){
        String result = "";
        try{
            HttpGet request = new HttpGet(CropSvcUri+ action);
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

    protected String getCropById(String action){
        String result = "";
        try{
            HttpGet request = new HttpGet(CropSvcUri + action);
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

    private int[] toIntArray(byte[] barr) {
        //Pad the size to multiple of 4
        int size = (barr.length / 4) + ((barr.length % 4 == 0) ? 0 : 1);

        ByteBuffer bb = ByteBuffer.allocate(size *4);
        bb.put(barr);

        //Java uses Big Endian. Network program uses Little Endian.
        bb.order(ByteOrder.LITTLE_ENDIAN);
        bb.rewind();
        IntBuffer ib =  bb.asIntBuffer();
        int [] result = new int [size];
        ib.get(result);


        return result;
    }
}
