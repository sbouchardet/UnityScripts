using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Death ();
	}

	void Death (){
		LevelConfig lc = player.GetComponent<LevelConfig> ();
		PlayerStatus ps = player.GetComponent<PlayerStatus> ();
		ps.increaseLife (-1);
		ps.setCoins (0);
		lc.respawn ();
	}


}
	
