package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;
import at.fhooe.ServiceRepository.JournalServiceRepository;
import at.fhooe.ViewModel.JournalViewModel;

import java.text.SimpleDateFormat;
import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/10/13
 * Time: 11:01 PM
 * To change this template use File | Settings | File Templates.
 */
public class JournalReadActivity extends Activity {
    public int cropid;
    public LinearLayout layout;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.journalread);
        Intent intent = getIntent();
        cropid = intent.getExtras().getInt("cropid");
        layout = (LinearLayout) findViewById(R.id.readJournalLayout);

        fillData();
    }

    public void fillData(){
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        JournalViewModel journalModel = new JournalViewModel();
        ArrayList<JournalViewModel> journals = journalModel.getJournal(cropid);

        for(JournalViewModel jm : journals){
            LinearLayout.LayoutParams lparams = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.WRAP_CONTENT);
            TextView tvDate = new TextView(this);
            tvDate.setLayoutParams(lparams);
            tvDate.setText(sdf.format(jm.getJournalDate()));
            this.layout.addView(tvDate);

            TextView tvDesc = new TextView(this);
            tvDesc.setLayoutParams(lparams);
            tvDesc.setText(jm.getDesc());
            this.layout.addView(tvDesc);
        }
        Button btnCancel = new Button(this);
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent toJournal = new Intent();
                toJournal.setClassName("at.fhooe.CropMngAndroid","at.fhooe.CropMngAndroid.JournalActivity");
                startActivity(toJournal);
            }
        });
        btnCancel.setText("Cancel");
        this.layout.addView(btnCancel);
    }



}