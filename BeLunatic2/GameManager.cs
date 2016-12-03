using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;




public class GameManager : MonoBehaviour {

	public Canvas CanvasGameOver;
	public Canvas CanvasPause;

	public int StartLifes;
	public int StartCoins;


	private List<string> nameOfLevels = new List<string> ();
	private int i;

	private int Life;
	private int Coins;
	private bool pause;
	private bool mute;
	void Start () {
		mute = false;
		pause = false;
		Life = StartLifes;
		Coins = StartCoins;
		i=0;
		DontDestroyOnLoad (gameObject);

		nameOfLevels.Add ("abducao");
		nameOfLevels.Add ("chao_de_cubos");

	}
	
	void Update () {
		
		pause = GameObject.FindGameObjectWithTag ("Player").GetComponent<LevelConfig> ().getPauseState ();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!pause) {
				InstantiatePause ();
			} else {
				DestroyPause ();
			}
		}

	}

	public void loadNextLevel(){
		i += 1;
		Application.LoadLevel(nameOfLevels[i]);
	}

	private void includeActions(){
		Button bSim = GameObject.Find ("Sim").GetComponent<Button> ();
		Button bNao = GameObject.Find ("Não").GetComponent<Button> ();

		bSim.onClick.AddListener (() => backToTheGame ());
		bNao.onClick.AddListener (() => endGame ());

	}

	public void ShowGameOver(){

		if (GameObject.Find ("GameOver") == null) {
			Instantiate (CanvasGameOver);
			includeActions ();
		}
	}

	public void endGame(){
		Debug.Log ("NAO");

		Application.Quit ();
	}
	public void backToTheGame(){
		Debug.Log ("SIM");
		i = 0;
		Life = StartLifes;
		Coins = StartCoins;
		Application.LoadLevel("MainMenu");

	}

	public void setLife(int l){
		this.Life = l;
	}
	public void setCoins(int c){
		this.Coins = c;
	}

	public int getCoins(){
		return this.Coins;
	}

	public int getLife(){
		return this.Life;
	}

	public void InstantiatePause(){
			Instantiate (CanvasPause);
			pauseTheGame ();
			Button bContinuar = GameObject.Find ("Continuar").GetComponent<Button> ();
			Button bSair = GameObject.Find ("Sair").GetComponent<Button> ();
			Button bDesativarSom = GameObject.Find ("Desativar Som").GetComponent<Button> ();

			bContinuar.onClick.AddListener (() => DestroyPause ());
			bSair.onClick.AddListener (() => endGame ());
			bDesativarSom.onClick.AddListener (() => Mute ());

		

	}

	public void DestroyPause (){
		Time.timeScale = 1.0f;        

		Debug.Log ("DESTROY");	
		LevelConfig lf = GameObject.FindGameObjectWithTag ("Player").GetComponent<LevelConfig> ();
		lf.unpauseTheGame ();
		Destroy (GameObject.Find("CanvasTelaPause(Clone)"));
	}

	public void Mute(){
		Debug.Log ("MUTE");
		if(!mute)
			AudioListener.pause = true;
		else
			AudioListener.volume = 0;

		mute = !mute;

	}

	public void pauseTheGame(){
		Time.timeScale = 0.0f;        
		LevelConfig lf = GameObject.FindGameObjectWithTag ("Player").GetComponent<LevelConfig> ();
		lf.pauseTheGame ();
	}

		
}

