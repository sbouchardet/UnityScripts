using UnityEngine;
using System.Collections;

public class Abduction : MonoBehaviour {

	public float AbductionVel;
	public int AbductionRay;
	public float AbductionAproximateVel;
	public float AbductionMinScale;
	public GameObject AbductionLaser;

	private Renderer r ;
	private GameObject enemyOnRay;
	private Vector3 startScale;
	private float startDistance;
	private GameObject laser = null;

	private LevelConfig lc;


	void Start () {
		lc = GetComponent<LevelConfig> ();
		r = GetComponent<Renderer> ();
		enemyOnRay = null;
	}

	void Update () {

		if (Input.GetMouseButton (0)) {
			abduction ();

		} else if(Input.GetMouseButtonUp (0)) {
			ChangeEnemyOnRay(null);
		}

		if (enemyOnRay != null)			
			ShowAbductionLaser ();
		else
			HideAbductionLaser ();


	}

	public GameObject getEnemyOnRay(){
		return enemyOnRay;
	}

	private void abduction(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, AbductionRay)) {
			StepOfAbduction (hit.transform.gameObject);

		}
	}
		
	private void ChangeEnemyOnRay(GameObject objOnRay = null){
		if (enemyOnRay != null) {
			r.material.color = new Color (r.material.color.r, r.material.color.g, r.material.color.b, 1);
			enemyOnRay.transform.localScale = startScale;

		} 
			



		SetEnemyOnRay (objOnRay);
	}
	private void StepOfAbduction (GameObject objOnRay){
		if (SameEnemyOnRay (objOnRay.transform.gameObject)) {
			startScale = Vector3.Max(startScale,objOnRay.transform.localScale);
			startDistance = Mathf.Max (startDistance, Vector3.Distance (transform.position, objOnRay.transform.position));
			ApproximateTarget (objOnRay);
			DecreseOpacity (objOnRay);
			DecreseScale (objOnRay);

		} else {
			ChangeEnemyOnRay (objOnRay);

		}
	}

	private void ApproximateTarget(GameObject obj) {
		obj.transform.position = Vector3.MoveTowards (obj.transform.position,transform.position, AbductionAproximateVel * Time.deltaTime);
	}

	private void DecreseScale (GameObject obj){
		float distance = Vector3.Distance (transform.position, obj.transform.position);
		float scale = ScaleDuringAbduction (distance);
		obj.transform.localScale = new Vector3 (scale, scale, scale);
	}

	private void DecreseOpacity(GameObject obj) {
		Renderer r = obj.GetComponentInChildren<Renderer> ();
		float alpha = r.material.color.a - AbductionVel*Time.deltaTime ;
		r.material.color= new Color(r.material.color.r, r.material.color.g, r.material.color.b,alpha);

		if (alpha < -0.5f) {
			lc.UpdateListOfDemands (obj.name);
			Destroy (obj);
			enemyOnRay = null;
		}

	}

	private bool SameEnemyOnRay(GameObject obj){
		if(enemyOnRay != null )
		if (obj == enemyOnRay)
			return true;
		return false;
	}

	private void SetEnemyOnRay (GameObject obj=null){
		enemyOnRay = obj!=null ? (obj.tag == "enemy" ? obj : null):null;
		startScale = obj == null ? new Vector3 (0, 0, 0) : obj.transform.localScale;
		startDistance = obj == null ? 0 : Vector3.Distance (transform.position, obj.transform.position);

	}

	private float ScaleDuringAbduction(float distance){
		return ((startScale.x - AbductionMinScale) / startDistance) * distance + AbductionMinScale;
	}
		
	private void ShowAbductionLaser(){
		if (laser == null) {
			Vector3 posicao = transform.position;
			float YPosition = transform.localScale.y / 4;
			posicao.y = posicao.y + YPosition;
			laser = Instantiate (AbductionLaser, posicao, Quaternion.identity) as GameObject;
			laser.transform.LookAt (enemyOnRay.transform.position);
		} else {
			Vector3 posicao = transform.position;
			float YPosition = transform.localScale.y / 4;
			posicao.y = posicao.y + YPosition;
			laser.transform.position =posicao;
			laser.transform.LookAt (enemyOnRay.transform.position);

		}
	}

	private void HideAbductionLaser(){
		Destroy (laser);
		laser = null;
	}
}
