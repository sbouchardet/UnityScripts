using UnityEngine;
using System.Collections;

public class BossChase : WalkOnPoints {

	public float damageRange = 10;

	private GameObject player;
	private GameObject gm;

	private float seconds = 0;
	public override void StartWalk() {
		player = GameObject.FindGameObjectWithTag ("Player");
		gm = GameObject.FindGameObjectWithTag ("GameManager");

	}
	
	// Update is called once per frame
	public override void UpdateWalk ()  {
		Walk (false);
		if (Vector3.Distance (transform.position, player.transform.position) <= damageRange) {
				hit ();

		} 
	}

	public void hit(){
		gm.GetComponent<GameManager> ().ShowGameOver ();
	}
}
