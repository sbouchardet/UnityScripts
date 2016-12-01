using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;



public class GameManager : MonoBehaviour {

	public int Lifes;
	public int Coins;


	private List<string> nameOfLevels = new List<string> ();
	private int i;

//	private float f_now =10;
	// Use this for initialization
	void Start () {
		i=0;
		DontDestroyOnLoad (gameObject);
		nameOfLevels.Add ("abducao");
		nameOfLevels.Add ("chao_de_cubos");

	}
	
	// Update is called once per frame
	void Update () {



//		f_now += Time.deltaTime;
//		if (f_now >= 10f) {
//			Application.LoadLevel("chao_de_cubos");
//
//		}
//		Debug.Log ("TESTE");


	}

	public void loadNextLevel(){
		i += 1;
		Application.LoadLevel(nameOfLevels[i]);
	}
}
