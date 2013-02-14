package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import at.fhooe.ViewModel.JournalViewModel;
import at.fhooe.ViewModel.TaskViewModel;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/13/13
 * Time: 10:43 PM
 * To change this template use File | Settings | File Templates.
 */
public class TaskActivity extends Activity {
    private ArrayList<TaskViewModel> tweets = null;
    private LinearLayout layout;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tasks);
        layout = (LinearLayout)findViewById(R.id.twitterLayout);

    }

    public void btnHandler(View v){
        switch (v.getId()){
            case R.id.lookupBtn:
                if(tweets != null){
                    tweets.clear();
                }
                TaskViewModel taskModel = new TaskViewModel();
                String username = ((EditText)findViewById(R.id.twitterName)).getText().toString();
                tweets = taskModel.getMessages(username);
                clearPageContent();
                setPageContent();
                break;
        }
    }
    public void setPageContent(){
        if(tweets != null){
            for(TaskViewModel tweet : tweets){
                LinearLayout.LayoutParams lparams = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.WRAP_CONTENT);

                TextView tvUsername = new TextView(this);
                tvUsername.setLayoutParams(lparams);
                tvUsername.setText(tweet.getUsername());
                this.layout.addView(tvUsername);

                TextView tvMsg = new TextView(this);
                tvMsg.setLayoutParams(lparams);
                tvMsg.setText(tweet.getMessage());
                this.layout.addView(tvMsg);
            }
        }
    }

    public void clearPageContent(){
        if (layout != null && layout.getChildCount() > 0) {
            try {
                layout.removeAllViews();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    private Bitmap getBitmap(String bitmapUrl) {
        try {
            URL url = new URL(bitmapUrl);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setDoInput(true);
            connection.connect();
            InputStream input = connection.getInputStream();
            Bitmap myBitmap = BitmapFactory.decodeStream(input);
            return myBitmap;
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }

}