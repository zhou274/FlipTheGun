/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

	[Tooltip("Settings gameobjects.")]
	public GameObject vibrationOn, vibrationOff, soundsOn, soundsOff;

	//Used to check if vibration is on.
	public static int vibration;

	void Start()
	{
		//If volume pref is off.
		if(PlayerPrefs.GetInt("Volume") == 1)
		{
			//Disable all audio in game.
 			AudioListener.volume = 0;
			//Change audio on button to off.
			soundsOff.SetActive(true);
			soundsOn.SetActive(false);
		}
		//If volume pref is on.
		else
		{
			//Enable all audio in game.
 			AudioListener.volume = 1;
			//Change audio off button to on.
			soundsOn.SetActive(true);
			soundsOff.SetActive(false);			
		}

		//If vibration pref is off.
		if(PlayerPrefs.GetInt("Vibration") == 1)
		{
			//Disable vibrations in game.
 			vibration = 0;
			//Change vibration on button to off.
			vibrationOff.SetActive(true);
			vibrationOn.SetActive(false);
		}
		//If vibration pref is on.
		else
		{
			//Disable vibrations in game.
 			vibration = 1;
			//Change vibration off button to on.
			vibrationOn.SetActive(true);
			vibrationOff.SetActive(false);			
		}		
	}

	public void Sounds()
	{
		//If volume pref is on.
		if(AudioListener.volume == 1)	
		{
			//Disable volume and save change to pref.
 			AudioListener.volume = 0;
			PlayerPrefs.SetInt("Volume", 1);		
		}
		//If volume pref is off.
		else
		{
 			//Enable volume and save change to pref.
			AudioListener.volume = 1;
			PlayerPrefs.SetInt("Volume", 0);		
		}
	}

	//If vibration pref is on.
	public void Vibrations()
	{
		if(vibration == 1)
		{
			//Disable vibration and save change to pref.
			vibration = 0;
			PlayerPrefs.SetInt("Vibration", 1);
		}
		//If vibration pref is off.
		else
		{
			//Enable vibration and save change to pref.
			vibration = 1;
			PlayerPrefs.SetInt("Vibration", 0);			
		}
	}

	public void Restore()
	{
		//Restore all progress and restart game.
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("FlipTheGun");
	}
}
