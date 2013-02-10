package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.provider.CalendarContract;
import android.support.v4.app.FragmentActivity;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;


/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/10/13
 * Time: 12:10 PM
 * To change this template use File | Settings | File Templates.
 */
public class AddFieldMapActivity extends FragmentActivity{
    private GoogleMap map;
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngfieldmap);

        FragmentManager manager = getFragmentManager();
        FragmentTransaction transaction = manager.beginTransaction();
        MapFragment mapFragment = MapFragment.newInstance();
        map = mapFragment.getMap();
        transaction.add(R.id.map, mapFragment);
        transaction.commit();

//        map.addMarker(new MarkerOptions()
//                .position(new LatLng(48.355336, 14.516373))
//                .title("Hello world"));
    }
}