/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
#if ADMOB
using GoogleMobileAds.Api;
#endif
public class AdBanner : MonoBehaviour
{
#if ADMOB
    private string adUnitId;
    private AdRequest request;
    private static BannerView bannerView;

    public void Start()
    {
        if(PlayerPrefs.GetInt("DisableAds") == 0)
        {
            if(!Data.properties.ads.testMode)
            {
                #if UNITY_ANDROID
                    string appId = Data.properties.ads.androidAppID;
                #elif UNITY_IPHONE
                    string appId = Data.properties.ads.iphoneAppID;
                #else
                    string appId = "unexpected_platform";
                #endif

                // Initialize the Google Mobile Ads SDK.
                MobileAds.Initialize(appId);

                this.RequestBanner();            
            }
            else
            {
                #if UNITY_ANDROID
                    string appId = "ca-app-pub-3940256099942544/6300978111";
                #elif UNITY_IPHONE
                    string appId = "ca-app-pub-3940256099942544/2934735716";
                #else
                    string appId = "unexpected_platform";
                #endif            

                // Initialize the Google Mobile Ads SDK.
                MobileAds.Initialize(appId);

                this.RequestBanner();
            }
        }
    }

    private void RequestBanner()
    {
        if(!Data.properties.ads.testMode)
        {        
            #if UNITY_ANDROID
                string adUnitId = Data.properties.ads.androidUnitID;
            #elif UNITY_IPHONE
                string adUnitId = Data.properties.ads.iphoneUnitID;
            #else
                string adUnitId = "unexpected_platform";
            #endif

            // Create an empty ad request.
            request = new AdRequest.Builder().Build();

            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

            // Load the banner with the request.
            bannerView.LoadAd(request);                
        }
        else
        {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/6300978111";
            #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/2934735716";
            #else
                string adUnitId = "unexpected_platform";
            #endif

            // Create an empty ad request.
            request = new AdRequest.Builder().Build();

            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

            // Load the banner with the request.
            bannerView.LoadAd(request);    
        }    
    }

    public static void DestroyBanner()
    {
        bannerView.Destroy();
        bannerView.Hide();
        Debug.Log("Ad banner was destroyed.");
    }
#endif
}
