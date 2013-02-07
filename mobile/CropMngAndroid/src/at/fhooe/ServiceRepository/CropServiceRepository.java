package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.ViewModel.CropViewModel;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONStringer;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/6/13
 * Time: 5:58 PM
 * To change this template use File | Settings | File Templates.
 */
public class CropServiceRepository extends AsyncTask<Object, Void, String>{
    private static final String SaveCropSvcUri = "http://10.0.2.2:81/CropService/web";
    private String result;

    @Override
    protected String doInBackground(Object... objects) {
        String action = (String)objects[0];
        CropViewModel cropModel = (CropViewModel) objects[1];

        if(action.equals("InsertCropData"))
        {
            return saveCropServiceRepository(action, cropModel);
        }else{
            return null;
        }
    }

    protected String saveCropServiceRepository(String action, CropViewModel cropModel){
        int statusCode = 400;
        try{
            // POST request to <service>/SaveCrop
            HttpPost request = new HttpPost(SaveCropSvcUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

            // Build JSON string
            JSONStringer crop = new JSONStringer()
                    .object()
                    .key("crop")
                    .object()
                    .key("name").value(cropModel.name)
                    .key("croptype").value(cropModel.cropType)
                    .key("timeofplanting").value(cropModel.timeOfPlanting)
                    .key("avatarimage").value(cropModel.avatearImage)
                    .key("wateringfrequency").value(cropModel.wateringFreq)
                    .key("wateringperiod").value(cropModel.wateringPeriod)
                    .key("harvesttime").value(cropModel.harvestTime)
                    .key("hillingtime").value(cropModel.hillingTime)
                    .key("fertilizingtime").value(cropModel.fertilizingTime)
                    .key("fieldcoverage").value(cropModel.fieldCoverage)
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

    @Override
    protected void onPostExecute(String result) {
        this.result = result;
    }


}
