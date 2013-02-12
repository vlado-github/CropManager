package at.fhooe.CropMngAndroid;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Canvas;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import at.fhooe.ViewModel.FieldViewModel;
import at.fhooe.ViewModel.MapFieldViewModel;
import at.fhooe.ViewModel.MapViewModel;
import org.osmdroid.tileprovider.tilesource.TileSourceFactory;
import org.osmdroid.util.GeoPoint;
import org.osmdroid.views.MapController;
import org.osmdroid.views.MapView;
import org.osmdroid.views.overlay.PathOverlay;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 8:53 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldDetailsMapActivity extends Activity {
    public MapView mapView;
    private MapController mapController;
    private FieldViewModel fm;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fielddetailsmap);
        mapView = (MapView)findViewById(R.id.mapview);
        mapView.setTileSource(TileSourceFactory.MAPNIK);
        mapView.setBuiltInZoomControls(true);
        mapView.getOverlays().clear();

        Intent intent = getIntent();
        int id =  intent.getExtras().getInt("fieldid");
        getFieldData(id);
    }

    public void getFieldData(int id){
        FieldViewModel fieldViewModel = new FieldViewModel();
        fm = fieldViewModel.getFieldById(id);

        MapFieldViewModel mapFieldViewModel = new MapFieldViewModel();
        int[] mapIds = mapFieldViewModel.getAllMapIdsByFieldId(id);

        ArrayList<MapViewModel> maps = new ArrayList<MapViewModel>();
        MapViewModel mapModel = new MapViewModel();
        for(int mapid : mapIds){
            MapViewModel map = mapModel.getMapById(mapid);
            maps.add(map);
        }

        drawFieldGeoPoints(maps);
    }

    private void drawFieldGeoPoints(ArrayList<MapViewModel> maps){
        if(!maps.isEmpty()) {
            ArrayList<FieldMarkerItem> overlayItems = new ArrayList<FieldMarkerItem>();
            GeoPoint zoomPoint = new GeoPoint(maps.get(0).getLatitude(),maps.get(0).getLongitude());
            PathOverlay fieldPath = new PathOverlay(Color.RED, this);
            for(MapViewModel map : maps){
                FieldMarkerItem fieldMarker = new FieldMarkerItem(getApplicationContext());
                GeoPoint geo = new GeoPoint(map.getLatitude(),map.getLongitude());
                fieldMarker.setLocation(geo);
                fieldPath.addPoint(geo);
                fieldMarker.draw(new Canvas(), mapView, false);
                overlayItems.add(fieldMarker);
            }
            fieldPath.addPoint(zoomPoint);

            mapView.getOverlays().addAll(0, overlayItems);
            mapView.getOverlays().add(fieldPath);
            overlayItems.clear();

            mapController = mapView.getController();
            mapController.setZoom(15);
            mapController.setCenter(zoomPoint);
        }
    }

    public void btnHandler(View v){
        switch (v.getId()){
            case R.id.showDetailsBtn:
                AlertDialog ad = new AlertDialog.Builder(this).create();
                ad.setCancelable(true);
                ad.setMessage("Name:"+fm.getName()+"; Size:"+fm.getAreaSize()+" in "+fm.getAreaSizeMeasure()+"; Altitude: "+fm.getAltitude()+"[m]");
                ad.show();
                break;
        }
    }
}