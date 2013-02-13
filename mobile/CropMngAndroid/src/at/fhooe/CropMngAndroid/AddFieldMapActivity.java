package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Canvas;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.provider.CalendarContract;
import android.support.v4.app.FragmentActivity;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Toast;
import at.fhooe.ViewModel.FieldViewModel;
import at.fhooe.ViewModel.MapFieldViewModel;
import at.fhooe.ViewModel.MapViewModel;
import org.osmdroid.DefaultResourceProxyImpl;
import org.osmdroid.events.MapListener;
import org.osmdroid.events.ScrollEvent;
import org.osmdroid.events.ZoomEvent;
import org.osmdroid.tileprovider.tilesource.TileSourceFactory;
import org.osmdroid.util.GeoPoint;
import org.osmdroid.views.MapController;
import org.osmdroid.views.MapView;
import org.osmdroid.views.overlay.Overlay;
import org.osmdroid.views.overlay.OverlayItem;
import org.osmdroid.views.overlay.OverlayManager;

import java.util.ArrayList;


/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/10/13
 * Time: 12:10 PM
 * To change this template use File | Settings | File Templates.
 */
public class AddFieldMapActivity extends Activity implements View.OnTouchListener{
    public MapView mapView;
    private ArrayList<GeoPoint> geoPoints = new ArrayList<GeoPoint>();
    private MapController mapController;
    private String measure;
    private String name;
    private double altitude;
    private double areaSize;


    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cropmngfieldmap);

        Intent intent = getIntent();
        name = intent.getExtras().getString("name");
        altitude = Double.parseDouble(intent.getExtras().getString("altitude"));
        areaSize = Double.parseDouble(intent.getExtras().getString("areasize"));
        measure = intent.getExtras().getString("measure");

        mapView = (MapView) findViewById(R.id.mapview);
        mapView.setTileSource(TileSourceFactory.MAPNIK);
        mapView.getOverlays().clear();
        mapController = mapView.getController();
        mapController.setZoom(15);
        Location loc = getCurrentLocation();
        GeoPoint point = null;
        if(loc != null){
            point = new GeoPoint(loc.getLatitude(),loc.getLongitude());
        }
        point = new GeoPoint(48.3669, 14.5172);
        mapController.setCenter(point);

        mapView.setOnTouchListener(this);

    }

    public Location getCurrentLocation(){
        Location gpslocation = getLocationByProvider(LocationManager.GPS_PROVIDER);
        Location networkLocation = getLocationByProvider(LocationManager.NETWORK_PROVIDER);

        if (gpslocation == null) {
            Toast.makeText(this, "No GPS Location available.", Toast.LENGTH_SHORT) .show();
            return networkLocation;
        }
        if (networkLocation == null) {
            Toast.makeText(this, "No Network Location available.", Toast.LENGTH_SHORT) .show();
            return gpslocation;
        }
        return null;
    }

    public boolean onTouch(View v, MotionEvent e) {
        if (e.getAction() == MotionEvent.ACTION_DOWN){
            FieldMarkerItem fieldMarker = new FieldMarkerItem(getApplicationContext());
            GeoPoint gp = (GeoPoint)mapView.getProjection().fromPixels(e.getX(), e.getY());
            geoPoints.add(gp);
            fieldMarker.setLocation(gp);
            fieldMarker.draw(new Canvas(), mapView, false);
            mapView.getOverlays().add(fieldMarker);
        }
        return false;
    }

    private Location getLocationByProvider(String provider) {
        Location location = null;

        LocationManager locationManager = (LocationManager) getApplicationContext()
                .getSystemService(Context.LOCATION_SERVICE);

        try {
            if (locationManager.isProviderEnabled(provider)) {

                location = locationManager.getLastKnownLocation(provider);

            }
        } catch (IllegalArgumentException e) {
            e.printStackTrace();
        }
        return location;
    }

    protected boolean isRouteDisplayed() {
        // TODO Auto-generated method stub
        return false;
    }

    public void saveField(){
        ArrayList<Integer> mapIds = new ArrayList<Integer>();
        int fieldId = 0;

        for(GeoPoint gp : geoPoints){
            MapViewModel mapModel = new MapViewModel();
            mapModel.setLatitude(gp.getLatitudeE6()/1E6);
            mapModel.setLongitude(gp.getLongitudeE6()/1E6);
            mapModel.setFieldId(0);
            String returnValId = mapModel.saveMap(mapModel);
            if(returnValId != null){
                mapIds.add(Integer.parseInt(returnValId));
            }
        }

        FieldViewModel fieldModel = new FieldViewModel();
        fieldModel.setAltitude(altitude);
        fieldModel.setAreaSize(areaSize);
        fieldModel.setAreaSizeMeasure(measure);
        fieldModel.setName(name);
        String returnValFieldId = fieldModel.saveField(fieldModel);
        if(returnValFieldId != null){
            fieldId = Integer.parseInt(returnValFieldId);
        }

        for(Integer id : mapIds){
            MapFieldViewModel mapFieldModel = new MapFieldViewModel();
            mapFieldModel.setFieldId(fieldId);
            mapFieldModel.setMapId(id);
            String saveStatus = mapFieldModel.saveMapField(mapFieldModel);
            if(!saveStatus.equals("200")){
                Toast.makeText(this, "Error - save unsuccessful.", Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(this, CropMngActivity.class);
                startActivity(intent);
            }else{
                Toast.makeText(this, "Save successful.", Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(this, CropMngActivity.class);
                startActivity(intent);
            }
        }
    }

    public void btnHandler(View v){
        switch(v.getId()){
            case R.id.saveFieldBtn:
                saveField();
                break;
        }
    }
}