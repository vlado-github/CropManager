package at.fhooe.ViewModel;

/**
 * Created with IntelliJ IDEA.
 * User: Vladimir
 * Date: 2/9/13
 * Time: 1:12 PM
 * To change this template use File | Settings | File Templates.
 */
public class ModelHelper {

    public static long parseJsonDate(String jsonDate){
        String[] result = jsonDate.split("[(]");
        String[] resultTwo = result[1].split("[+]");
        return Long.parseLong(resultTwo[0]);
    }
}
