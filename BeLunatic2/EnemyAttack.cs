using UnityEngine;
using System.Collections;

public class EnemyAttack : Enemy {
	public float dashVel = 500f;
	public float dashRotate = 1f;
	public float SecondsBetweenDamages = 1f;
	public int damageCoins = 10;	

	public float rangeStartAttack = 10f;
	public float damageRange = 2f;

	private float seconds=0;

	public override bool IsActionTime(){
		if (Vector3.Distance (player.transform.position, transform.position) <= ActionRange)
			return true;
		else
			return false;
	}


	public override void Action(){
		
		Vector3 targetDir = player.transform.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward,
			targetDir, dashRotate*Time.deltaTime, 0.0f);
		newDir.y = 0;
		transform.rotation = Quaternion.LookRotation(newDir);

		cc.SimpleMove (transform.forward*dashVel*Time.deltaTime);

		if (Vector3.Distance (player.transform.position, transform.position) <= damageRange) {
			seconds += Time.deltaTime;
			if (seconds > SecondsBetweenDamages ) {
				PlayerStatus ps = player.GetComponent<PlayerStatus> ();
				ps.increaseCoins (-damageCoins);
				seconds = 0;
				Debug.Log (ps.getCoins ());
			}
		} else {
			seconds = 0;
		}

	}




}
