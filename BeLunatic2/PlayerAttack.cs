using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public int Energy = 100;
	public int hitDamage = 10;
	public float rangeAttack = 5;
	private GameObject Enemy;

	void Start () {
		Enemy = GameObject.FindGameObjectWithTag ("enemy");
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Attack ();
		}
	}

	private void Attack(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, rangeAttack)) {
			if (hit.transform.gameObject == Enemy) {
				hitEnemy ();
			}
		}


	}

	private void hitEnemy(){
		BossAttack ba = Enemy.GetComponent<BossAttack> ();
		ba.increaseEnergy (-hitDamage);
		StartCoroutine ("Blink");
		Debug.Log (ba.Energy);
		 
	}

	private IEnumerator Blink(){
		Enemy.GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		Enemy.GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds (0.1f);
		Enemy.GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		Enemy.GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds (0.1f);
		Enemy.GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		Enemy.GetComponent<Renderer> ().enabled = true;
	}


}
