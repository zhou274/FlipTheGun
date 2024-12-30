/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.UI;

public class Challenges : MonoBehaviour {

	//Both values will be used when selecting challenges(which gun and which challenge).
	public static int gunNumber;
	public static int challengeNumber;


	//Custom gold color.
	private static Color32 gold;	

	void Start() 
	{
		//Setting up gold color.
		gold.r = 255; gold.g = 215; gold.b = 0; gold.a = 255;
		//Changing star colors to black.
		transform.GetChild(1).GetComponent<Image>().color = Color.black;
		transform.GetChild(2).GetComponent<Image>().color = Color.black;
		transform.GetChild(3).GetComponent<Image>().color = Color.black;
		

		//If player completed first challenge then show one golden stars.
		if(PlayerPrefs.GetInt("Challenge" + transform.parent.parent.name + transform.GetSiblingIndex()) == 1)
		{
			transform.GetChild(1).GetComponent<Image>().color = gold;
		}
		//If player completed second challenge then show two golden stars.
		else if(PlayerPrefs.GetInt("Challenge" + transform.parent.parent.name + transform.GetSiblingIndex()) == 2)
		{
			transform.GetChild(1).GetComponent<Image>().color = gold;
			transform.GetChild(2).GetComponent<Image>().color = gold;
		}
		//If player completed third challenge then show three golden stars.
		else if(PlayerPrefs.GetInt("Challenge" + transform.parent.parent.name + transform.GetSiblingIndex()) == 3)
		{
			transform.GetChild(1).GetComponent<Image>().color = gold;
			transform.GetChild(2).GetComponent<Image>().color = gold;
			transform.GetChild(3).GetComponent<Image>().color = gold;
		}		
	}
	
	public void setNumber()
	{
		//Which gun has been chosen.
		gunNumber = int.Parse(transform.parent.parent.name);
	}
}
