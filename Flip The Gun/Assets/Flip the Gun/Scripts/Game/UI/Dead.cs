

using StarkSDKSpace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Dead : MonoBehaviour {

	[Tooltip("Reward/Dead menu gameobject.")]
	public GameObject rewardMenu, deadMenu;
	[Tooltip("Coroutines gameobject.")]	
	public Coroutines coroutines;
	[Tooltip("High score text gameobject.")]	
	public TextMeshProUGUI highScoreTxt;
	[Tooltip("Dead score/highscore text gameobject.")]	
	public TextMeshProUGUI deadScoreTxt, deadHighScoreTxt;
	[Tooltip("Main camera object.")]	
	public Transform cameraPosition;
    private StarkAdManager starkAdManager;

    public string clickid;

    void OnTriggerEnter2D(Collider2D col)
    {
		//If gun enters bottom collider.
        if (col.tag == "GunUI")
        {
			//If score is higher than highscore.
			if((int)cameraPosition.position.y/2 > Score.highScore)
			{
				//Set new highscore.
				Score.highScore = (int)cameraPosition.position.y/2;
				PlayerPrefs.SetInt("HighScore", Score.highScore);
				highScoreTxt.text = "最高分：" + Score.highScore.ToString();
				deadHighScoreTxt.text = "最高分：" + Score.highScore.ToString();
				coroutines.AddNewHighscore(MainMenu.username, Score.highScore);
			}
			//Reset coin count(for rewards, challenges).
			Coin.coinCount=0;
			//Display score to device.
			deadScoreTxt.text = ((int)cameraPosition.position.y/2).ToString();	
			//If score is bigger than 100 then enable reward menu.
			//if((int)cameraPosition.position.y/2 >= 100)
			//	rewardMenu.SetActive(true);
			////Otherwise display dead menu.
			//else 

			deadMenu.SetActive(true);
			//Disable escape button.
			MainMenu.escape = 0;
            ShowInterstitialAd("1lcaf5895d5l1293dc",
            () => {
                Debug.LogError("--插屏广告完成--");

            },
            (it, str) => {
                Debug.LogError("Error->" + str);
            });
        }
	}
    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="errorCallBack"></param>
    /// <param name="closeCallBack"></param>
    public void ShowInterstitialAd(string adId, System.Action closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            var mInterstitialAd = starkAdManager.CreateInterstitialAd(adId, errorCallBack, closeCallBack);
            mInterstitialAd.Load();
            mInterstitialAd.Show();
        }
    }

}
