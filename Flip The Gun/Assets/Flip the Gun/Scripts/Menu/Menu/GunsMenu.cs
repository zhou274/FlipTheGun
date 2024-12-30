/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class GunsMenu : MonoBehaviour {

	[Tooltip("menu/game fade animation.")]
	public Animation fadeMenu, fadeGame;
	[Tooltip("Gun gameobject.")]	
	public GameObject Gun;
	[Tooltip("Menu/Game menu")]	
	public GameObject menuCanvas, gameCanvas;
	[Tooltip("Main camera gameobject.")]	
	public CameraMovement cameraMov;

	//If player pressed to start game.
	public IEnumerator StartGame()
	{
		//Fade in animation.
		fadeMenu.Play("FadeIn");
		yield return new WaitForSeconds(0.25f);
		//Enable gun.
		Gun.SetActive(true);
		//Disable menu.
		menuCanvas.SetActive(false);
		//Start fade out animation.
		fadeGame.enabled = true;
		//Enable game canvas.
		gameCanvas.SetActive(true);
		fadeGame.Play("FadeOut");
	}
}
