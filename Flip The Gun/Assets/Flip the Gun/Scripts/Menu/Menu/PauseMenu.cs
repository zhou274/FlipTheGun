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

public class PauseMenu : MonoBehaviour {

	[Tooltip("Main Camera gameobject.")]
	public CameraMovement cameraMovement;
 	[Tooltip("Fading gameobject.")]
    public Animation fade, fadeRestart;
	
	//Used to disable gun when game is paused.
	private GameObject gun;

	//If game paused.
	public void Pause()
	{
		//Find gun
        gun = GameObject.FindWithTag("Gun");
		//Pause gun.
		Gun.Pause();		
		//Disable gun physics.
		gun.GetComponent<Gun>().enabled = false;
		//Disable camera movement.
		cameraMovement.enabled = false;
		//Start fade in animation.
		fade.Play("FadeIn");
		//Enable pause menu.
		gameObject.SetActive(true);
	}

	//If game resumed.
	public void Resume () 
	{
		//Fade out
		fade.Play("FadeOut");
		//Enable camera movement.
		cameraMovement.enabled = true;
		//Enable gun physics.
		cameraMovement.GetComponent<Coroutines>().EnableCoroutine("EnableGunPhysics");
		//Disable pause menu.
		gameObject.SetActive(false);
	}

	//If go to menu button pressed.
	public void Menu()
	{
		//Fade in pause menu.
		fadeRestart.Play("FadeIn");
		//Restart game.
		cameraMovement.GetComponent<Coroutines>().EnableCoroutine("RestartScene");
	}
}
