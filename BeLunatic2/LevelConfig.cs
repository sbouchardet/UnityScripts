using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


[System.Serializable]
public class LevelDemand : IEquatable<LevelDemand> {

	public int cont;
	public GameObject type;


	public LevelDemand(GameObject t, int c){
		this.cont = c;
		this.type = t;
	}

	public bool Equals(LevelDemand other)
	{	
		if (this.type==null || other.type == null)
			return false;
		if (!type.name.Equals(other.type.name) )return false;
		
		return true;
	}

	public override string ToString ()
	{
		return string.Format (this.type.name+" - "+cont.ToString());
	}
}

public class LevelConfig : MonoBehaviour {

	public List<LevelDemand> Demands = new List<LevelDemand>();
	public Font NumberFont;
	public Color ColorNumber = new Color(1,1,1,1);
	public Font LetterFont;
	public Color ColorLetter = new Color(1,1,1,1);
	public int FontSize = 20;

	private GUIStyle guiStyle = new GUIStyle(); 

	private List<LevelDemand> InitialEnemys = new List<LevelDemand>();


	// Use this for initialization
	void Start () {

		GameObject[] allEnemys = GameObject.FindGameObjectsWithTag ("enemy");
		foreach (GameObject i in allEnemys) {
			if (InitialEnemys.Contains (new LevelDemand (i, 0))) {
				InitialEnemys [InitialEnemys.IndexOf (new LevelDemand (i, 0))].cont += 1;
			} else {
				InitialEnemys.Add (new LevelDemand (i, 1));
			}
		}
	
		}
	
	// Update is called once per frame
	void Update () {
		UpdateEnemyInfo ();
	}

	void OnGUI()
	{

		guiStyle.fontSize = FontSize;
		foreach (LevelDemand a in Demands){	
			GUI.skin.font = LetterFont;
			GUI.color = ColorLetter;
			GUI.Label(new Rect((Screen.width)*(3f/4f), 10, Screen.width*(3.75f/4f), 40), a.type.name+":",guiStyle);
			GUI.skin.font = NumberFont;
			GUI.color = ColorNumber;
			GUI.Label(new Rect((Screen.width)*(3.75f/4f), 10, Screen.width, 40), a.cont.ToString(),guiStyle);
		}


	}

	void UpdateEnemyInfo(){

		List <LevelDemand> localGO = new List<LevelDemand> ();
		GameObject[] allEnemys = GameObject.FindGameObjectsWithTag ("enemy");

		foreach (GameObject i in allEnemys) {
			if (localGO.Contains (new LevelDemand (i, 0))) {
				localGO [localGO.IndexOf (new LevelDemand (i, 0))].cont += 1;
			} else {
				localGO.Add (new LevelDemand (i, 1));
			}
		}

		 //Falta arrumar a exibição da contagem de abduções
		foreach (LevelDemand i in Demands) {
			i.cont = i.cont -  
				(InitialEnemys [InitialEnemys.IndexOf (i)].cont - 
					localGO [localGO.IndexOf (i)].cont);

			Debug.Log (InitialEnemys [InitialEnemys.IndexOf (i)].cont);
				Debug.Log (localGO [localGO.IndexOf (i)].cont);
		}

	}


}