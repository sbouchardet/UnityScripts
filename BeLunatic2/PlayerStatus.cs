using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStatus : MonoBehaviour {

	public int StartLife = -1;
	public GameObject CountLife;
	public int StartCoins = -1;
	public GameObject CountCoins;

	public int AmountCoinsToNewLife = 100;

	private int Life;
	private int Coins;

	private GameObject gom;
	GameManager gm;

	void Start(){
		gom = GameObject.FindGameObjectWithTag ("GameManager");
		gm = gom.GetComponent<GameManager> ();
		if (StartLife == -1)
			setLife (gm.getLife());
		else
			setLife (StartLife);
		if (StartCoins == -1)
			setCoins (gm.getCoins());
		else
			setCoins (StartCoins);
	}

	public int getLife(){
		return this.Life;
	}

	public void setLife(int l){
		CountLife.GetComponent<Text> ().text = l.ToString();
		gm.setLife(getLife());

		this.Life = l;
	}

	public void increaseLife(int l){
		this.setLife(this.Life+l);
	}

	public int getCoins(){
		return this.Coins;
	}

	public void setCoins(int c){
		CountCoins.GetComponent<Text> ().text = c.ToString();
		gm.setCoins(getCoins ());
		this.Coins = c;

	}

	public void increaseCoins(int c){
		this.setCoins(this.Coins + c);
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
