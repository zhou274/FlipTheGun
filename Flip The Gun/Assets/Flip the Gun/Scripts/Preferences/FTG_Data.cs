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
using System.Collections.Generic;


//[CreateAssetMenu(fileName = "Data", menuName = "Flip The Gun/Data")]
public class FTG_Data : ScriptableObject 
{
    public Ads ads = new Ads();
    public Leaderboards lead = new Leaderboards();
    public IAPurchase iap = new IAPurchase();
}

[System.Serializable]
public class Ads
{
    public bool testMode;
    public string androidAppID;
    public string iphoneAppID;
    public string androidUnitID;
    public string iphoneUnitID;
}

[System.Serializable]
public class Leaderboards
{
    public string privateCode;
	public string publicCode;
}

[System.Serializable]
public class IAPurchase
{
    public float removeAdsPrice = 3.99f;
	public float pileOfCoinsPrice = 5.99f;
	public float sniperPackPrice = 2.99f;
	public float rocketPackPrice = 3.99f;
}
