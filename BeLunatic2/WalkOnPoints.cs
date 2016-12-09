using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class WalkOnPoints: MonoBehaviour {

	public float WalkVel = 10;
	public float RotateVel = 0.7f;
	public List<GameObject> PointsToWalk;
    public float precisionPoint = 3.0f;

	protected GameObject objTarget;
	protected CharacterController cc;

	void Start () {
		objTarget = PointsToWalk [0];
		cc = GetComponent<CharacterController> ();
		StartWalk ();
	}

	void Update(){
		UpdateWalk ();
	}

	public void Walk (bool loop = true){
		if (objTarget != null) 
		if (Vector3.Distance (objTarget.transform.position, transform.position)<= precisionPoint) {
			int PointsLength = PointsToWalk.Count;
			int TargetIndex = PointsToWalk.IndexOf (objTarget);
			int NewTargetIndex = PointsLength == TargetIndex + 1 && loop ? 0 : TargetIndex + 1;
			objTarget = NewTargetIndex >=PointsLength ? null:PointsToWalk [NewTargetIndex];
		} else {
				Vector3 targetDir = objTarget.transform.position - transform.position;
				Vector3 newDir = Vector3.RotateTowards (transform.forward,
					                targetDir, RotateVel * Time.deltaTime, 0.0f);
				newDir.y = 0;
				transform.rotation = Quaternion.LookRotation (newDir);

				cc.SimpleMove (transform.forward * WalkVel * Time.deltaTime);


		}	

	}

	public abstract void StartWalk();
	public abstract void UpdateWalk ();

	 
}
