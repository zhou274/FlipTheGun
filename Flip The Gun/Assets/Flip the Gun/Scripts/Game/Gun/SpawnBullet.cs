/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

public class SpawnBullet : MonoBehaviour {

	//If gun need first bullet and gun is in camera range then spawn bullet.
	public void BulletSpawn()
	{
		if(transform.GetChild(0).gameObject.activeSelf)
			Instantiate(Data.firstBullet);
	}
	//If gun need second bullet and gun is in camera range then spawn bullet.
	public void SecondBulletSpawn()
	{
		if(transform.GetChild(0).gameObject.activeSelf)
			Instantiate(Data.secondBullet);
	}	
	//If gun need third bullet and gun is in camera range then spawn bullet.
	public void ThirdBulletSpawn()
	{
		if(transform.GetChild(0).gameObject.activeSelf)
			Instantiate(Data.thirdBullet);
	}	
	//If gun need laser and gun is in camera range then spawn laser.
	public void LaserSpawn()
	{
		if(transform.GetChild(0).gameObject.activeSelf)
			Instantiate(Data.laser);		
	}
	//If gun need rocket and gun is in camera range then spawn rocket.
	public void RocketSpawn()
	{
		if(transform.GetChild(0).gameObject.activeSelf)
			Instantiate(Data.rocket);		
	}	

	//If gun need bullet shell and gun is in camera range then spawn bullet shell.
	public void BulletShellSpawn()
	{
		if(transform.GetChild(1).gameObject.activeSelf)
			Instantiate(Data.bulletShell);	
	}	
}
