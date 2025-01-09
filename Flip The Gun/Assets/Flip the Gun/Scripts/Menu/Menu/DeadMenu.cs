using UnityEngine;
using System.Collections;
using TTSDK.UNBridgeLib.LitJson;
using TTSDK;
using StarkSDKSpace;
using System.Collections.Generic;
using UnityEngine.Analytics;
using System;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {

	[Tooltip("Fade in animation when restarting scene.")]
	public Animation fade;

	[Tooltip("Coroutines gameobject in MainCamera.")]
	public Coroutines coroutines;
    public string clickid;
    private StarkAdManager starkAdManager;
    public static Action Respawned;
    void Start()
	{
		//Fade in animation when player is dead.
		gameObject.GetComponent<Animation>().Play("FadeIn");
	}
    public void Continue()
    {
        ShowVideoAd("1anf98b6oddo4222f4",
            (bol) => {
                if (bol)
                {

                    transform.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    Respawned();


                    clickid = "";
                    getClickid();
                    apiSend("game_addiction", clickid);
                    apiSend("lt_roi", clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });

    }
    public void Restart()
	{

        //Fade in animation to restart game.
        //fade.Play("FadeIn");
        //Start restart coroutine.
        //coroutines.StartCoroutine("RestartScene");
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        SceneManager.LoadScene("FlipTheGun");
        GunCollider.boosterUsed = false;
        //SceneManager.LoadScene("FlipTheGun");

    }
    public void getClickid()
    {
        var launchOpt = StarkSDK.API.GetLaunchOptionsSync();
        if (launchOpt.Query != null)
        {
            foreach (KeyValuePair<string, string> kv in launchOpt.Query)
                if (kv.Value != null)
                {
                    Debug.Log(kv.Key + "<-参数-> " + kv.Value);
                    if (kv.Key.ToString() == "clickid")
                    {
                        clickid = kv.Value.ToString();
                    }
                }
                else
                {
                    Debug.Log(kv.Key + "<-参数-> " + "null ");
                }
        }
    }

    public void apiSend(string eventname, string clickid)
    {
        TTRequest.InnerOptions options = new TTRequest.InnerOptions();
        options.Header["content-type"] = "application/json";
        options.Method = "POST";

        JsonData data1 = new JsonData();

        data1["event_type"] = eventname;
        data1["context"] = new JsonData();
        data1["context"]["ad"] = new JsonData();
        data1["context"]["ad"]["callback"] = clickid;

        Debug.Log("<-data1-> " + data1.ToJson());

        options.Data = data1.ToJson();

        TT.Request("https://analytics.oceanengine.com/api/v2/conversion", options,
           response => { Debug.Log(response); },
           response => { Debug.Log(response); });
    }


    /// <summary>
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="closeCallBack"></param>
    /// <param name="errorCallBack"></param>
    public void ShowVideoAd(string adId, System.Action<bool> closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            starkAdManager.ShowVideoAdWithId(adId, closeCallBack, errorCallBack);
        }
    }
}
