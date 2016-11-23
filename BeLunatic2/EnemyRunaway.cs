using UnityEngine;
using System.Collections;

public class EnemyRunaway : Enemy {
	public float dashRotate = 1f;
	public float dashVel = 500f;

	public override bool IsActionTime(){
		if (Vector3.Distance (player.transform.position, transform.position) <= ActionRange)
			return true;
		else
			return false;
	}

	public override void Action(){
		Vector3 targetDir = transform.position - player.transform.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward,
			targetDir, dashRotate*Time.deltaTime, 0.0f);
		newDir.y = 0;
		transform.rotation = Quaternion.LookRotation(newDir);

		cc.SimpleMove (transform.forward*dashVel*Time.deltaTime);
	}

}
