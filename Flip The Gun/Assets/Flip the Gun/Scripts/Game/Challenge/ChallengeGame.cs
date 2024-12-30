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
using System.Collections;

public class ChallengeGame : MonoBehaviour {

	//Custom gold color.
	private Color32 gold;	

	void OnEnable()
	{
		//Setting up gold color.
		gold.r = 255; gold.g = 215; gold.b = 0; gold.a = 255;
		//Show challenge when gameobject is enabled.
		StartCoroutine(ShowStars());
	}

	IEnumerator ShowStars()
	{
		//Wait for animation to stop.
		yield return new WaitForSeconds(0.1f);
		//First Challenge
		if(Challenges.challengeNumber == 0)
			transform.GetChild(0).GetComponent<Text>().text = "Gain 25/50/100 points";		
		//Second Challenge
		else if(Challenges.challengeNumber == 1)
			transform.GetChild(0).GetComponent<Text>().text = "Shoot 30/60/100 times";
		//Third Challenge
		else if(Challenges.challengeNumber == 2)
			transform.GetChild(0).GetComponent<Text>().text = "Use booster 5/15/25 times";	
		//Fourth Challenge
		else if(Challenges.challengeNumber == 3)
			transform.GetChild(0).GetComponent<Text>().text = "Collect 25/50/100 coins";	
		//Fifth Challenge
		else if(Challenges.challengeNumber == 4)
			transform.GetChild(0).GetComponent<Text>().text = "Fly 25/50/100 meters without boosters";	
		//Sixth Challenge
		else if(Challenges.challengeNumber == 5)
			transform.GetChild(0).GetComponent<Text>().text = "Collect 5/15/25 bullets";

		//If player completed first challenge then show one golden star.
		if(PlayerPrefs.GetInt("Challenge" + Challenges.gunNumber + Challenges.challengeNumber) == 1)
		{
			transform.GetChild(1).GetComponent<Image>().color = gold;			
		}
		//If player completed second challenge then show two golden stars.
		else if(PlayerPrefs.GetInt("Challenge" + Challenges.gunNumber + Challenges.challengeNumber) == 2)
		{
			transform.GetChild(1).GetComponent<Image>().color = gold;
			transform.GetChild(2).GetComponent<Image>().color = gold;			
		}
		//If player completed third challenge then show three golden star.
		else if(PlayerPrefs.GetInt("Challenge" + Challenges.gunNumber + Challenges.challengeNumber) == 3)
		{
			transform.GetChild(1).GetComponent<Image>().color = gold;
			transform.GetChild(2).GetComponent<Image>().color = gold;			
			transform.GetChild(3).GetComponent<Image>().color = gold;
		}
		//Start fading in animation.
		gameObject.GetComponent<Animation>().Play("ChallengeGameFadeIn");
		yield return new WaitForSeconds(3);
		//Start fading out animation and disable gameobject.
		gameObject.GetComponent<Animation>().Play("ChallengeGameFadeOut");
		yield return new WaitForSeconds(0.17f);
		gameObject.SetActive(false);
	}
}
