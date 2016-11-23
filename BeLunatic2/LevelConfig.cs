using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Demand{
	public string Enemy;
	public int Amount;

	public Demand (string Enm, int a = -1){
		this.Enemy = Enm;
		this.Amount = a;
	}
		

	public override string ToString () {
		return string.Format ("[LevelConfig]"+this.Enemy+" [ "+this.Amount+" ]");
	}

	public override bool Equals (object obj)
	{
		Demand other = obj as Demand;
		if (other.Enemy != null && this.Enemy != null)
			return this.Enemy == other.Enemy;
		return false;
	}
		
}




public class LevelConfig : MonoBehaviour {

	//FIXME: need refactoring!


	public GameObject StartPoint;
	public List<Demand> ListOfDemands = new List<Demand> ();

	public Font NumberFont;
	public Color ColorNumber = new Color(1,1,1,1);
	public Font LetterFont;
	public Color ColorLetter = new Color(1,1,1,1);
	public int FontSize = 20;

	private GUIStyle guiStyle = new GUIStyle();


			


	void OnGUI(){

		guiStyle.fontSize = FontSize;
		foreach (Demand a in ListOfDemands){	
			GUI.skin.font = LetterFont;
			GUI.color = ColorLetter;
			GUI.Label(new Rect((Screen.width)*(3f/4f), 10, Screen.width*(3.75f/4f), 40), a.Enemy+":",guiStyle);
			GUI.skin.font = NumberFont;
			GUI.color = ColorNumber;
			GUI.Label(new Rect((Screen.width)*(3.75f/4f), 10, Screen.width, 40), a.Amount.ToString(),guiStyle);

		}

	}
		
	public void UpdateListOfDemands(string name){
		ListOfDemands [ListOfDemands.IndexOf (new Demand (name))].Amount -= 1;
	}

	public void respawn(){
		transform.position =new Vector3(StartPoint.transform.position.x,
			StartPoint.transform.position.y+5,
			StartPoint.transform.position.z);

	}


}