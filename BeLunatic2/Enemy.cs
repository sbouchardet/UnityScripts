using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class Enemy : WalkOnPoints {

	public int ActionRange;

	protected GameObject player;

	public override void StartWalk(){
		player = GameObject.FindGameObjectWithTag ("Player");

	}
		
	public override void UpdateWalk () {
		if (IsActionTime ()) {

			Action ();
		} else {
			Walk ();
	}
	}
		

	public abstract bool IsActionTime();

	public abstract void Action ();


}
