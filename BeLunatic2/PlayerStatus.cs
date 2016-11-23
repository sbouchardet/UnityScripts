using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public int StartLife;
	public int StartCoins;
	public int AmountCoinsToNewLife = 100;

	private int Life;
	private int Coins;

	void Start(){
		Life = StartLife;
		Coins = StartCoins;
	}

	public int getLife(){
		return this.Life;
	}

	public void setLife(int l){
		this.Life = l;
	}

	public void increaseLife(int l){
		Debug.Log ("Life:" + this.Life);
		this.Life += l;
	}

	public int getCoins(){
		return this.Coins;
	}

	public void setCoins(int c){
		this.Coins = c;
	}

	public void increaseCoins(int c){
		this.Coins += c;
		if (c>0 && Coins == AmountCoinsToNewLife) {
			this.increaseLife (1);
			this.setCoins (0);
		}
		if (c < 0 && Coins <= 0) {
			this.increaseLife (-1);
			this.setCoins (0);
		}
	}
		
}
