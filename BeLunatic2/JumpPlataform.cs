using UnityEngine;
using System.Collections;

public class JumpPlataform : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.transform.gameObject.name == "plataforma") {
			this.transform.parent = hit.transform;
			Debug.Log ("Temos um jogo");
		} else {
			this.transform.parent = null;

		}
	}
}
