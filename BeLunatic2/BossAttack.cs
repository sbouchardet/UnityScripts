using UnityEngine;
using System.Collections;

public class BossAttack : EnemyAttack {
	public int Energy = 100;

	protected override void  hit(){
		PlayerAttack pa = player.GetComponent<PlayerAttack> ();
		pa.Energy -= damage;
		Debug.Log (pa.Energy);
	}

	protected override void hitAnimation(){
		
	}

	public void increaseEnergy(int c){
		this.Energy += c;
		if (this.Energy <= 0) {
			Dead ();
		}
	}

	private void Dead(){
		Debug.Log ("BossDead. YouWin");
	}




}
