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

	public List<Demand> ListOfDemands = new List<Demand> ();

	private List<Demand> EnemysAtLevel = new List<Demand> ();

	public Font NumberFont;
	public Color ColorNumber = new Color(1,1,1,1);
	public Font LetterFont;
	public Color ColorLetter = new Color(1,1,1,1);
	public int FontSize = 20;

	private GUIStyle guiStyle = new GUIStyle();

	void Start () {

		GameObject[] allEnemys = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < allEnemys.Length; i++) {
			GameObject enemy = allEnemys [i];
			if (EnemysAtLevel.Contains (new Demand (enemy.name))) {
				EnemysAtLevel [EnemysAtLevel.IndexOf (new Demand(enemy.name,1))].Amount += 1;
			} else {
				EnemysAtLevel.Add (new Demand (enemy.name, 1));
			}
		}

		}
	
	void Update () {
		string abducted = WhoWasAbducted ();
		if (abducted != "nobody") {
			UpdateListOfDemands (abducted);
		}
			
	}

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
		


	private void AdjustListDemands(List<Demand> d){
		for (int i=0;i<d.Count;i++){
			if (d[i].Amount == 0)
				d.RemoveAt (i);
		}
	}
		
	private void PrintListDemands(List<Demand> d){
		if (d.Count == 0) {
			Debug.Log (" ---ListDemand--- ");
			Debug.Log ("  ! EMPTY LIST !  ");
			Debug.Log (" ---------------- ");
			return;
		} else {

			Debug.Log (" ---ListDemand--- ");
			foreach (Demand i in d)
				Debug.Log (i.ToString ());
			Debug.Log (" ---------------- ");
		}
	}



	private string WhoWasAbducted(){
		
		List<Demand> enemyCountReduced = new List<Demand> ();
		GameObject[] enemysNow = GameObject.FindGameObjectsWithTag ("enemy");

		for (int i = 0; i < enemysNow.Length; i++) {
			GameObject enemy = enemysNow [i];
			if (enemyCountReduced.Contains (new Demand (enemy.name))) {
				enemyCountReduced [enemyCountReduced.IndexOf (new Demand(enemy.name,1))].Amount += 1;
			} else {
				enemyCountReduced.Add (new Demand (enemy.name, 1));
			}
		}
	
		if (enemyCountReduced.Count == 0) {
			EnemysAtLevel.Clear();
		}
		for (int i = 0; i < enemyCountReduced.Count; i++) {
//			Debug.Log (EnemysAtLevel [i].Enemy);
//			Debug.Log (enemyCountReduced [i].Enemy);
			Demand InfoEnemyUntilNow = EnemysAtLevel [EnemysAtLevel.IndexOf (new Demand(enemyCountReduced [i].Enemy))];
//			Debug.Log (InfoEnemyUntilNow);
			if (InfoEnemyUntilNow.Amount > enemyCountReduced [i].Amount) {
				EnemysAtLevel [EnemysAtLevel.IndexOf (enemyCountReduced [i])].Amount = enemyCountReduced [i].Amount;
				return enemyCountReduced [i].Enemy;
			}
		}

		return "nobody";
	}

	private void UpdateListOfDemands(string name){
		ListOfDemands [ListOfDemands.IndexOf (new Demand (name))].Amount -= 1;
	}

}