using UnityEngine;
using admob;

public class admobdemo : MonoBehaviour
{
    public bool isTesting = false;
    Admob ad;
    //string appID="";
    string bannerID = "ca-app-pub-1310604487353159/3693111151";
    string interstitialID = "ca-app-pub-1310604487353159/9875376121";
    string videoID = "ca-app-pub-1310604487353159/9159760480";
    string nativeBannerID = "";
    private Hopper hopperScript;

    void Awake()
    {
        Debug.Log("Awake is called!----------");
        initAdmob();
        UTIL.appPurchased = PlayerPrefs.GetInt(UTIL.adRemoved , 0);
    }

    void Start()
    {
        Debug.Log("start unity demo-------------");
        GameObject.FindGameObjectWithTag("Google_Ad").GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(KeyCode.Escape + "-----------------");
        }
    }

    void initAdmob()
    {
        if(!isTesting){

#if UNITY_IOS
        		// appID="ca-app-pub-3940256099942544~1458002511";
				 bannerID="ca-app-pub-3940256099942544/2934735716";
				 interstitialID="ca-app-pub-1310604487353159/9931313533";
				 videoID="ca-app-pub-1310604487353159/9310767949";
				 nativeBannerID = "ca-app-pub-3940256099942544/3986624511";
#elif UNITY_ANDROID
        		 //appID="ca-app-pub-3940256099942544~3347511713";
				 bannerID= "ca-app-pub-1310604487353159/6871236007"; 
                 interstitialID = "ca-app-pub-1310604487353159/2740419304";
				 videoID= "ca-app-pub-1310604487353159/8888677644";
				 nativeBannerID = "ca-app-pub-1310604487353159/5085164008";
#endif
        }
        AdProperties adProperties = new AdProperties();
        adProperties.isTesting(false);
        adProperties.isAppMuted(true);
        adProperties.isUnderAgeOfConsent(false);
        adProperties.appVolume(100);
        adProperties.maxAdContentRating(AdProperties.maxAdContentRating_G);
        string[] keywords = { "diagram", "league", "brambling" };
        adProperties.keyworks(keywords);

        ad = Admob.Instance();
        ad.bannerEventHandler += onBannerEvent;
        ad.interstitialEventHandler += onInterstitialEvent;
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.nativeBannerEventHandler += onNativeBannerEvent;
        ad.initSDK(adProperties);//reqired,adProperties can been null

        ShowRewardVideo(true);
        ShowBanner();
    }

    public void ShowRewardVideo(bool wait = false)
    {
         if(UTIL.appPurchased == 1)
            return;
        
        Debug.Log("touch video button -------------");
        if (ad.isRewardedVideoReady())
        {
            /*show ad randomly when come back to main menu*/
            int rand = Random.Range(0, 20);
            if (!wait || rand > 16)
                ad.showRewardedVideo();
        }
        else
        {
            ad.loadRewardedVideo(videoID);
        }
    }

    public void ShowInterstitial()
    {
        return;

        Debug.Log("touch inst button -------------");
        if (ad.isInterstitialReady())
        {
            ad.showInterstitial();
        }
        else
        {
            ad.loadInterstitial(interstitialID);
        }
    }

    public void ShowBanner()
    {
        if(UTIL.appPurchased == 1)
            return;

        int rand = Random.Range(0, 20);
        if (rand > 8)
            Admob.Instance().showBannerRelative(bannerID, AdSize.SMART_BANNER, AdPosition.BOTTOM_CENTER);
    }

    public void HideBanner()
    {
        Admob.Instance().removeBanner();
        Admob.Instance().removeBanner("mybanner");
    }

    void OnGUI()
    {
        return;
        if (GUI.Button(new Rect(120, 0, 100, 60), "showInterstitial"))
        {
            Debug.Log("touch inst button -------------");
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial(interstitialID);
            }
        }
        if (GUI.Button(new Rect(0, 0, 100, 60), "showRewardVideo"))
        {
            Debug.Log("touch video button -------------");
            if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
                ad.loadRewardedVideo(videoID);
            }
        }
        if (GUI.Button(new Rect(0, 100, 100, 60), "showbanner"))
        {
            Admob.Instance().showBannerRelative(bannerID, AdSize.SMART_BANNER, AdPosition.BOTTOM_CENTER);
        }
        if (GUI.Button(new Rect(120, 100, 100, 60), "showbannerABS"))
        {
            Admob.Instance().showBannerAbsolute(bannerID, AdSize.BANNER, 20, 220, "mybanner");
        }
        if (GUI.Button(new Rect(240, 100, 100, 60), "removebanner"))
        {
            Admob.Instance().removeBanner();
            Admob.Instance().removeBanner("mybanner");
        }

        if (GUI.Button(new Rect(0, 200, 100, 60), "showNative"))
        {
            Admob.Instance().showNativeBannerRelative(nativeBannerID, new AdSize(320, 280), AdPosition.BOTTOM_CENTER);
        }
        if (GUI.Button(new Rect(120, 200, 100, 60), "showNativeABS"))
        {
            Admob.Instance().showNativeBannerAbsolute(nativeBannerID, new AdSize(-1, 132), 0, 300);
        }
        if (GUI.Button(new Rect(240, 200, 100, 60), "removeNative"))
        {
            Admob.Instance().removeNativeBanner();
        }
    }

    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
        else if (eventName == AdmobEvent.onAdClosed)
        {
           
        }

    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);

        if (eventName == AdmobEvent.onAdLoaded)
        {

        }
        else if (eventName == AdmobEvent.onRewarded)
        {

        }
        else if (eventName == AdmobEvent.onAdClosed)
        {
            int rand = Random.Range(0, 25);
            if (rand > 8)
                ad.loadInterstitial(interstitialID);
            ad.loadRewardedVideo(videoID);

              HopperScriptShowPlayers();

        }
        else if (eventName == AdmobEvent.onVideoEnd || eventName == AdmobEvent.onRewardedVideoCompleted)
        {
                HopperScriptShowPlayers();
        }

    }
    void onNativeBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
    }

    void HopperScriptShowPlayers()
    {
        hopperScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Hopper>();
        if (hopperScript != null)
        {
            hopperScript.playerHolder.SetActive(true);
            hopperScript.playerHolderToHide.SetActive(false);
        }
    }
}
