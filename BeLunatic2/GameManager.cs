using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private float f_now =10;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		f_now += Time.deltaTime;
		if (f_now >= 10f) {
			Application.LoadLevel("chao_de_cubos");

		}
		Debug.Log ("TESTE");
	}
}
