package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Toast;
import at.fhooe.ViewModel.JournalViewModel;

import java.text.SimpleDateFormat;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/10/13
 * Time: 9:31 PM
 * To change this template use File | Settings | File Templates.
 */
public class JournalWriteActivity extends Activity {

    public DatePicker journalDate = null;
    public EditText description = null;
    public int cropid;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.journalwrite);
        Intent intent = getIntent();
        cropid = intent.getExtras().getInt("cropid");
        journalDate = (DatePicker) findViewById(R.id.journalDate);
        description = (EditText) findViewById(R.id.descriptionJournal);
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.saveJournalBtn:
                JournalViewModel journalModel = new JournalViewModel();
                journalModel.setCropid(cropid);
                journalModel.setJournalDate(Helpers.convertToDate(journalDate));
                journalModel.setDesc(description.getText().toString());
                String status = journalModel.saveJournal(journalModel);
                if(!status.equals("200")){
                    Toast.makeText(this, "Error - Save unsuccessful", Toast.LENGTH_SHORT).show();
                }else{
                    Toast.makeText(this,"Save successful", Toast.LENGTH_SHORT).show();
                }
                break;
            case R.id.canceJournalBtn:
                Intent toJournalMain = new Intent(this, JournalActivity.class);
                startActivity(toJournalMain);
                break;
        }
    }
}