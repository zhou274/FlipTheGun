/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

public class VerticalShot : MonoBehaviour {

	//Used to get one of three vertical shot texts in this gameobject.
	private static Transform childs;

	void Start()
	{
		//Attach transfrom.
		childs = this.transform;
	}

	//Start vertical shot animation.
	public static void EnableAnimation()
	{
		//Play random animation.
		childs.GetChild(Random.Range(0,3)).GetComponent<Animation>().Play("VerticalShot");
	}
}
