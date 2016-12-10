using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public int Energy = 100;
	public Text CountEnergy;

	public int hitDamage = 10;
	public float rangeAttack = 5;

	private GameObject Enemy;
	private bool isAlive;

	void Start () {
		isAlive = true;
		Enemy = GameObject.FindGameObjectWithTag ("enemy");
		this.setEnergy (Energy);
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
				if(Enemy.GetComponent<BossAttack>().Energy>0)hitEnemy ();
			}
		}


	}

	private void hitEnemy(){
		BossAttack ba = Enemy.GetComponent<BossAttack> ();
		ba.increaseEnergy (-hitDamage);
		Debug.Log(ba.Energy);
		 
	}

	public void setEnergy(int e){
		if(e>0)
			CountEnergy.text = e.ToString ();
		if (e <= 0) {
			CountEnergy.text = "0";
			Dead ();
		}
		this.Energy = e;
	}

	private void Dead(){
		Debug.Log ("YOU LOSE");
		GameManager gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		gm.ShowGameOver ();
	}
		
}
