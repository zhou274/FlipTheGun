/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

public class BulletPlace : MonoBehaviour {

	[Tooltip("If gun used in menu.")]
	public bool menu;
	[Tooltip("Second gun bulletPlace gameobject.")]
	public GameObject bulletPlace;

	void OnTriggerExit2D(Collider2D col)
	{
		//If gun exits camera then enable bullet place in second gun.
		if (col.tag == "MainCamera" && !menu)
        {
			bulletPlace.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
