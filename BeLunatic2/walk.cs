using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {
	public float velocidade;

	private CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetKey (KeyCode.W))
			cc.SimpleMove (transform.forward * velocidade);
		if (Input.GetKey (KeyCode.S))
			cc.SimpleMove (-transform.forward * velocidade);
		if(Input.GetKey(KeyCode.A))
			cc.SimpleMove (-transform.right * velocidade);
		if(Input.GetKey(KeyCode.D))
			cc.SimpleMove (transform.right * velocidade);
}

}