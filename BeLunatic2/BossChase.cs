using UnityEngine;
using System.Collections;

public class BossChase : WalkOnPoints {

	public float damageRange = 10;
	public float SecondsBetweenDamages = 1;
	public int damage = 10;

	private GameObject player;
	private float seconds = 0;
	public override void StartWalk() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	public override void UpdateWalk ()  {
		Walk (false);
		if (Vector3.Distance (transform.position, player.transform.position) <= damageRange) {
			seconds += Time.deltaTime;
			if (seconds > SecondsBetweenDamages) {
				hit ();
				seconds = 0;
			}
		} else {
			seconds = 0;
		}
	}

	public void hit(){
		player.GetComponent<PlayerRunaway> ().Energy -= damage;
		Debug.Log (player.GetComponent<PlayerRunaway> ().Energy);
	}
}
