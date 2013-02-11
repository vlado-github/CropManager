package at.fhooe.ServiceRepository;

import android.os.AsyncTask;
import at.fhooe.ViewModel.WeatherViewModel;
import org.apache.http.*;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.CoreProtocolPNames;
import org.apache.http.params.HttpParams;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URI;
import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/11/13
 * Time: 12:05 AM
 * To change this template use File | Settings | File Templates.
 */
public class WeatherServiceRepository extends AsyncTask<String, Void, String> {
    private String result;

    @Override
    protected String doInBackground(String... strings) {
        String city = strings[0];
        String country = strings[1];
        return getWeatherInfo(city,country);
    }

    public String getWeatherInfo(String city, String country){
        String result = null;
        try{
//            String url = "http://free.worldweatheronline.com/feed/weather.ashx?" +
//                    "key=7b72960d6c230143130402&q="+city+","+country+"&num_of_days=3&format=json";
            String url = "http://free.worldweatheronline.com/feed/weather.ashx?key=7b72960d6c230143130402&q="+city+","+country+"&num_of_days=3&format=json";
            HttpPost request = new HttpPost(url);
            request.setHeader("Accept", "application/json");
            request.setHeader("Content-type", "application/json");
            HttpParams params = new BasicHttpParams();
            params.setParameter(CoreProtocolPNames.USER_AGENT, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/534.24 (KHTML, like Gecko) Chrome/11.0.696.71");
            request.setParams(params);
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

    protected void onPostExecute(String result) {
        this.result = result;
    }
}
