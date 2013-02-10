package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import com.google.android.gms.common.GooglePlayServicesUtil;
import com.google.android.gms.maps.MapFragment;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/10/13
 * Time: 12:10 PM
 * To change this template use File | Settings | File Templates.
 */
public class AddFieldMapActivity extends Activity {
    public void onCreate(Bundle savedInstanceState) {
//        super.onCreate(savedInstanceState);
////        int googlePlayServicesAvailable = GooglePlayServicesUtil.isGooglePlayServicesAvailable(getApplicationContext());
////        int status = googlePlayServicesAvailable;
//        setContentView(R.layout.cropmngfieldmap);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngfieldmap);

        FragmentManager manager = getFragmentManager();
        FragmentTransaction transaction = manager.beginTransaction();

        transaction.add(R.id.map, MapFragment.newInstance());
        transaction.commit();
    }
}