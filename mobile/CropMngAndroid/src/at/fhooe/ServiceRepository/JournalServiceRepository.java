package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.ViewModel.FieldViewModel;
import at.fhooe.ViewModel.JournalViewModel;
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
 * Date: 2/10/13
 * Time: 9:45 PM
 * To change this template use File | Settings | File Templates.
 */
public class JournalServiceRepository extends AsyncTask<Object, Void, String> {

    private static final String GetJournalSVCUri = "http://10.0.2.2:81//JournalService.svc/web";
    private String result;

    @Override
    protected String doInBackground(Object... objects) {
        String action = (String) objects[0];
        if(action.contains("InsertJournal")){
            JournalViewModel journal = (JournalViewModel) objects[1];
            return saveJournal(action, journal);
        }else if(action.contains("SelectJournalByCropId")){
            return getJournal(action);
        }else{
            return null;
        }
    }

    public String saveJournal(String action, JournalViewModel journal){
        int statusCode = 400;
        try{
            // POST request to <service>/SaveCrop
            HttpPost request = new HttpPost(GetJournalSVCUri + action);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");

            // Build JSON string
            JSONStringer crop = new JSONStringer()
                    .object()
                    .key("journal")
                    .object()
                    .key("dateentered").value("/Date("+journal.getJournalDate().getTime()+")/")
                    .key("description").value(journal.getDesc())
                    .key("journalimage").value(null)
                    .key("cropid").value(journal.getCropid())
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

    protected String getJournal(String action){
        String result = "";
        try{
            HttpGet request = new HttpGet(GetJournalSVCUri + action);
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
