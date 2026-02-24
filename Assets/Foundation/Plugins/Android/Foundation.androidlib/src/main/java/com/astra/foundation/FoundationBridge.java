package com.astra.foundation;
import android.content.Context;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.os.Build;

public class FoundationBridge {
    private static Context m_context;
    public static void start(Context context)
    {
        m_context = context;
    }
    
    // private static Context getContext() 
    // {
    //     try 
    //     {
    //         Class<?> unityPlayer = Class.forName("com.unity3d.player.UnityPlayer");
    //         return (Context) unityPlayer.getField("currentActivity").get(null);
    //     } catch (Exception e) {
    //         e.printStackTrace();
    //         return null;
    //     }
    // }
    public static String getVersionCode()
    {
        try
        {
            PackageManager pm = m_context.getPackageManager();
            String packageName = m_context.getPackageName();
            PackageInfo pi = pm.getPackageInfo(packageName, 0);
            long versionCode;
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.P)
            {
                // Android 9 (API 28) 及以上
                versionCode = pi.getLongVersionCode();
            } else
            {
                // API < 28
                versionCode = pi.versionCode;
            }

            return String.valueOf(versionCode);
        }
        catch (PackageManager.NameNotFoundException e)
        {
            e.printStackTrace();
            return "-1";
        }
    }

}