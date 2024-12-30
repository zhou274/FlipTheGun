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

public class BulletFly : MonoBehaviour {

	//Used to get position where bullet should be spawned.
	private Transform bulletPlace;

	void Start()
	{
		//Find bullet spawn position gameobject.
		bulletPlace = GameObject.FindGameObjectWithTag("BulletPlace").transform;
		//Setup bullet spawn position and rotation.
		transform.parent.position = bulletPlace.position;
		transform.parent.rotation = bulletPlace.rotation;

	}

	public void BulletDestroy()
	{
		//When animation ends destroy bullet gameobject.
		Destroy(transform.parent.gameObject);
	}
}
