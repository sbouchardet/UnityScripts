using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class Enemy : MonoBehaviour {
	public float WalkVel;
	public float RotateVel;
	public List<GameObject> PointsToWalk;
	public int ActionRange;

	protected GameObject player;
	private GameObject objTarget;
	protected CharacterController cc;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		objTarget = PointsToWalk [0];
		cc = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsActionTime ()) {

			Action ();
		} else {
			Walk ();
	}
	}

	public void Walk (){
		if (Vector3.Distance (objTarget.transform.position, transform.position)<=4) {
			int PointsLength = PointsToWalk.Count;
			int TargetIndex = PointsToWalk.IndexOf (objTarget);
			int NewTargetIndex = PointsLength == TargetIndex + 1 ? 0 : TargetIndex + 1;
			objTarget = PointsToWalk [NewTargetIndex];

		} else {
			Vector3 targetDir = objTarget.transform.position - transform.position;
			Vector3 newDir = Vector3.RotateTowards(transform.forward,
				targetDir, RotateVel*Time.deltaTime, 0.0f);
			newDir.y = 0;
			transform.rotation = Quaternion.LookRotation(newDir);

			cc.SimpleMove (transform.forward*WalkVel*Time.deltaTime);

		}	

	}




	public abstract bool IsActionTime();

	public abstract void Action ();


}
