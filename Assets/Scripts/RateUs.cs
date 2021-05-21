using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUs : MonoBehaviour
{
    // Update is called once per frame
    
    public string pkgName = "com.FourtyFourty.Covid20";
    void Start()
    {
        Debug.Log("App id = " + pkgName);
    }
    public void Rate()
    {

        #if UNITY_ANDROID
            Application.OpenURL("market://details?id="+pkgName);
        #elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/id"+pkgName);
        #endif
    }

    public void RateLater()
    {
       Destroy(gameObject);
    }


}
