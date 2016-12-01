using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
	public void LoadTheLevel(string LevelName){
		Application.LoadLevel(LevelName);
	}
}
