/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	[Tooltip("Main Menu button fly in and fly out animation.")]
	public Animation mainMenu;
	[Tooltip("User name gameobject.")]
	public TextMeshProUGUI usernameTxt;

	public void Start()
	{
		//Disable main menu.
		mainMenu.Play("MainMenuButtonFlyOut");
	}

	//If player choose name.
	public void ChooseName()
	{
		//Save username to player prefs.
		PlayerPrefs.SetString("Username", usernameTxt.text);
		MainMenu.username = usernameTxt.text;
		//Enable main menu.
		mainMenu.Play("MainMenuButtonFlyIn");
	}
}
