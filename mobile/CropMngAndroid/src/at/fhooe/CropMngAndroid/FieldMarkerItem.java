package at.fhooe.CropMngAndroid;

import android.content.Context;
import android.graphics.*;
import android.graphics.drawable.Drawable;
import android.view.MotionEvent;
import org.osmdroid.ResourceProxy;
import org.osmdroid.api.IMapView;
import org.osmdroid.util.GeoPoint;
import org.osmdroid.views.MapView;
import org.osmdroid.views.overlay.ItemizedOverlay;
import org.osmdroid.views.overlay.OverlayItem;
import org.osmdroid.views.overlay.SimpleLocationOverlay;

import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/12/13
 * Time: 3:21 PM
 * To change this template use File | Settings | File Templates.
 */
public class FieldMarkerItem extends SimpleLocationOverlay{


    public FieldMarkerItem(Context ctx) {
        super(ctx);    //To change body of overridden methods use File | Settings | File Templates.
    }

    public FieldMarkerItem(Context ctx, ResourceProxy pResourceProxy) {
        super(ctx, pResourceProxy);    //To change body of overridden methods use File | Settings | File Templates.
    }

    @Override
    public void setLocation(GeoPoint mp) {
        super.setLocation(mp);    //To change body of overridden methods use File | Settings | File Templates.
    }

    @Override
    public GeoPoint getMyLocation() {
        return super.getMyLocation();    //To change body of overridden methods use File | Settings | File Templates.
    }

    @Override
    public void draw(Canvas c, MapView osmv, boolean shadow) {
        Point mapCenterPoint = new Point();
        osmv.getProjection().toPixels(getMyLocation(), mapCenterPoint);
        c.drawCircle(mapCenterPoint.x, mapCenterPoint.y, 10, new Paint(Paint.ANTI_ALIAS_FLAG));
    }
}
