package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 9:12 PM
 * To change this template use File | Settings | File Templates.
 */
public class MapServiceRepository extends AsyncTask<String, Void, String> {
    public static final String svcUri = "http://10.0.2.2:81/MapService.svc/web";
    public String result;

    @Override
    protected String doInBackground(String... strings) {
        if(strings[0].contains("SelectMapById")){
            return getAllMapRecordsById(strings[0]);
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

    @Override
    protected void onPostExecute(String result) {
        this.result = result;
    }
}
