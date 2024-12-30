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

public class Wallet : MonoBehaviour {

	//Used to count and display coins in menu and game.
	public static int coins;
	//Used to set how many coins was before game.
	public static int startCoins;
	//Used for coin blast animation.
	public static Animation coinAnim;
	//Used to play coin sound when player get coins.
	public static AudioSource coinSound;
	
	//Used to display coin amount in menu and game.
	private static Text coinsText;

	void Start () 
	{
		//Attach all components.
		coinAnim = this.GetComponent<Animation>();
		coinSound = this.GetComponent<AudioSource>();
		coinsText = gameObject.GetComponent<Text>();
		//Get from playeprefs how many coins player has. 
		coins = PlayerPrefs.GetInt("Coins");
		//Set coin amount before game.
		startCoins = coins;
		//Update wallet.
		WalletUpdate();
	}

	//Coin destroy
	public static void CoinBlast()
	{
		//Start coin blast animation.
		coinAnim.Play("CoinBlast");
		//Play coin get sound.
		coinSound.Play();
	}
	
	//Update player wallet.
	public static void WalletUpdate () 
	{
		//Update menu and game text.
		coinsText.text = coins.ToString();
	}

	//Add coins to wallet.
	public static void AddCoins(int amount)
	{
		//Add specific amount of coins to playerprefs.
		PlayerPrefs.SetInt("Coins", Wallet.coins+=amount);
		//Update wallet.
		Wallet.WalletUpdate();		
	}

	//Remove coins from wallet.
	public static void removeCoins(int amount)
	{
		//Remove specific amount of coins from playerprefs.
		PlayerPrefs.SetInt("Coins", Wallet.coins-=amount);
		//Update coin amount before game.
		startCoins = coins;
		//Update wallet.
		Wallet.WalletUpdate();		
	}
}
