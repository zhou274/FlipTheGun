using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TTSDK.UNBridgeLib.LitJson;
using TTSDK;
using StarkSDKSpace;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour {

	[Tooltip("Fade gameobject.")]
    public GameObject fade;
	[Tooltip("Menu fade in/out Animation.")]
	public Animation fadeMenu, fadeGame;
	[Tooltip("Menu/Game canvas")]
	public GameObject menuCanvas, gameCanvas;
	[Tooltip("Scroll gameobject.")]
	public Transform scrollPanel;
	[Tooltip("Main camera gameobject.")]
	public CameraMovement cameraMov;
	[Tooltip("Challenge Window gameobject.")]
	public GameObject challengeWindow;
	[Tooltip("Start Menu gameobject.")]
	public GameObject startMenu;


	//Main Menu gameobject.
	public static Animation mainMenu;
	//Challenge gameobject.
	public static GameObject challengeGame;
	//Used to get which gun is selected.
	public static int gunNumber;
	//Used to check which escape is enabled.
	public static int escape;
	//Used to get player username.
	public static string username;
    public string clickid;
    private StarkAdManager starkAdManager;


    void Awake()
	{
		//Reset challenge mode when game starts.
		ChallengeMenu.challengeMode = false;
		//get Main menu animation.
		mainMenu = gameObject.GetComponent<Animation>();
		
		//Reset challenges.
		challengeGame = challengeWindow;
		for(int i = 0; i < 6; i++)
			ChallengeMenu.challengeActive[i] = false;

		//If game is launched NOT first time.
		if(PlayerPrefs.GetInt("StartMenu") == 1)
		{
			//Get player username and start game.
			EscapeGame();
			username = PlayerPrefs.GetString("Username");
			fade.GetComponent<Animation>().Play("FadeOut");			
		}
		//If game is launched  first time.
		else
		{
			//Enable start menu.
			BlockEscape();
			fade.GetComponent<Image>().enabled = true;
			startMenu.SetActive(true);
			PlayerPrefs.SetInt("StartMenu", 1);
		}
	}

	//Start menu fade in animation.
	public void FadeIn()
	{
		fade.GetComponent<Animation>().Play("FadeIn");
	}

	//Start menu fade out animation.
	public void FadeOut()
	{
		fade.GetComponent<Animation>().Play("FadeOut");
		EscapeGame();
	}

	//Pressed play button.
	public void Play()
	{
		//Start game.
		StartCoroutine(StartGame());
	}

	//Start button fly out animation.
	public void ButtonFlyOut()
	{
		mainMenu.Play("MainMenuButtonFlyOut");
	}

	//Start button fly in animation.
	public void ButtonFlyIn()
	{
		mainMenu.Play("MainMenuButtonFlyIn");
	}	

	public IEnumerator StartGame()
	{
		//If gun can be bought.(Buy gun)
		if(GunUI.isBuyable)
		{
			//If player has enough money to buy a selected gun.
			if(Wallet.coins >= Data.gunsMenu[gunNumber].GetComponent<GunUI>().price)
			{
				//Set to player prefs that user bought gun.
				PlayerPrefs.SetInt("GunBought" + gunNumber, 1);
				//Change button from buy to play.
				transform.GetChild(1).GetChild(0).GetComponent<Animation>().Play("BuyToPlay");
				//Remove money from user wallet.
				Wallet.removeCoins(Data.gunsMenu[gunNumber].GetComponent<GunUI>().price);
				//Disable purchase bool.
				GunUI.isBuyable = false;
			}
		}
		//If gun can not be bought.(Start game)
		else
		{
			//Enable fully shrink gun animation.
			foreach(GameObject gunUI in ScrollSnap.guns)
			{
				if(!gunUI.GetComponent<GunUI>().selected)
				{
					gunUI.GetComponent<GunUI>().ShrinkGun();
				}
			}
			//Spawn score lines.
			Instantiate(Data.scoreLines);
			//Fly our menu buttons.
			ButtonFlyOut();
			//Flip UI gun animation.
			scrollPanel.GetChild(gunNumber).GetComponent<Animation>().Play("FlipGun");
			//Spawn selected gun.
			GameObject gun = Instantiate<GameObject>(Data.gunsGame[gunNumber]);
			//Start fade in animation.
			fadeMenu.Play("FadeIn");
			yield return new WaitForSeconds(0.25f);
			//Enable game canvas.
			fadeGame.enabled = true;
			gameCanvas.SetActive(true);	
			fadeGame.Play("FadeOut");
			//Enable gun.
			gun.SetActive(true);
			Coroutines.SpawnGun();
			//Disable menu camera.
			menuCanvas.SetActive(false);
			//Enable camera movement.
			cameraMov.enabled = true;	
			//Update achievement stats.
			PlayerPrefs.SetInt("GamesPlayed", (PlayerPrefs.GetInt("GamesPlayed")+1));	
		}
	}
	
	//Lock escape button.
	public void BlockEscape()
	{
		escape = 0;
	}
	//Escape from game.
	public void EscapeGame()
	{
		escape = 1;
	}
	//Escape from menu.
	public void EscapeMenu()
	{
		escape = 2;
	}
	//Pause game.
	public void PauseGame()
	{
		escape = 3;
	}

	public void GetCoin()
	{
        ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {


                    Wallet.AddCoins(100);

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
