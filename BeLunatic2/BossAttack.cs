using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossAttack : EnemyAttack {
	public int Energy = 100;
	public Text CountEnergy;

	protected override void  hit(){
		PlayerAttack pa = player.GetComponent<PlayerAttack> ();
		if(pa.Energy>0)pa.setEnergy (pa.Energy - damage);
	}

	protected override void hitAnimation(){
		
	}

	public void increaseEnergy(int c){
		this.setEnergy (this.Energy + c);
	}

	private void setEnergy(int e){
		if(e>=0)
		CountEnergy.text = e.ToString ();
		if (e <= 0) {
			Dead ();
			CountEnergy.text = "0";

		}
		this.Energy = e;
	}

	private void Dead(){
		Debug.Log ("BossDead. YouWin");
		GameManager gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		gm.loadNextLevel ();

	}




}
