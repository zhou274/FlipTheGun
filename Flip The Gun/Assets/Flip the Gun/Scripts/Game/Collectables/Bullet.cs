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

public class Bullet : MonoBehaviour {
	
    void OnTriggerEnter2D(Collider2D col)
    {
		//If gun touched bullet.
        if (col.tag == "GunUI")
        {
			StartCoroutine(BulletDestroy());
		}
	}

	IEnumerator BulletDestroy()
	{
		//Start bullet destroy animation.
		transform.parent.GetComponent<Animation>().Play("BulletDestroy");
		//Wait when animation ends.
		yield return new WaitForSeconds(0.7f);
		//Destroy bullet gameobject.
		Destroy(transform.parent.gameObject);
	}
}
