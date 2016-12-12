using UnityEngine;
using System.Collections;

public class PlayerRunaway : MonoBehaviour {

	public GameObject EndPoint;
	public float Distance = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (EndPoint.transform.position, transform.position) < Distance) {
			GameManager gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
			gm.loadNextLevel ();
		}
	}
}
