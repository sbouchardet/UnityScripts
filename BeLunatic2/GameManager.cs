using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{

    public Canvas CanvasGameOver;
    public Canvas CanvasPause;

    public int StartLives;
    public int StartCoins;


    private List<string> nameOfLevels = new List<string>();
    private int i;

    private int Life;
    private int Coins;
    private bool pause;
    private bool mute;

    void Start()
    {
        mute = false;
        pause = false;
        setLife(StartLives);
        setCoins(StartCoins);
      

        i = 0;
        DontDestroyOnLoad(gameObject);

        nameOfLevels.Add("Fase 1 Grupo 1");
        nameOfLevels.Add("Fase 2 Grupo 1");
        nameOfLevels.Add("Fase 3 Grupo 1");

        nameOfLevels.Add("Fase 1 Grupo 2");
        nameOfLevels.Add("Fase 2 Grupo 2");
        nameOfLevels.Add("Fase 3 Grupo 2");

        nameOfLevels.Add("Fase 1 Grupo 3");
        nameOfLevels.Add("Fase 2 Grupo 3");
        nameOfLevels.Add("Fase 3 Grupo 3");

    }

    void Update()
    {
        
        pause = GameObject.FindGameObjectWithTag("Player")!=null?GameObject.FindGameObjectWithTag("Player").GetComponent<LevelConfig>().getPauseState():true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                InstantiatePause();
                GameObject.FindGameObjectWithTag("Player").GetComponent<LevelConfig>().pauseTheGame();

            }
            else {
                DestroyPause();
                GameObject.FindGameObjectWithTag("Player").GetComponent<LevelConfig>().unpauseTheGame();

            }
        }

    }

    public void loadNextLevel()
    {
        i += 1;
        Application.LoadLevel(nameOfLevels[i]);
    }

	public void loadFirstLevel()
	{
		i = 0;
		Application.LoadLevel(nameOfLevels[i]);
	}

    private void includeActions()
    {
        Button bSim = GameObject.Find("Sim").GetComponent<Button>();
        Button bNao = GameObject.Find("Não").GetComponent<Button>();

        bSim.onClick.AddListener(() => backToTheGame());
        bNao.onClick.AddListener(() => endGame());


    }

    public void ShowGameOver()
    {

        if (GameObject.Find("GameOver(Clone)") == null)
        {
            Time.timeScale = 0.0f;
            Instantiate(CanvasGameOver);
            includeActions();
        }
    }

    public void endGame()
    {
        Debug.Log("NAO");

        Application.Quit();
    }
    public void backToTheGame()
    {
        DestroyGameOver();
        Life = StartLives;
        Coins = StartCoins;
		loadFirstLevel ();        


    }

    public void setLife(int l)
    {
        this.Life = l;
    }
    public void setCoins(int c)
    {
        this.Coins = c;
    }

    public int getCoins()
    {
        return Coins;
    }

    public int getLife()
    {
        return Life;
    }

    public void InstantiatePause()
    {
        Instantiate(CanvasPause);
        pauseTheGame();
        Button bContinuar = GameObject.Find("Continuar").GetComponent<Button>();
        Button bSair = GameObject.Find("Sair").GetComponent<Button>();
        Button bDesativarSom = GameObject.Find("Desativar Som").GetComponent<Button>();

        bContinuar.onClick.AddListener(() => DestroyPause());
        bSair.onClick.AddListener(() => endGame());
        bDesativarSom.onClick.AddListener(() => Mute());



    }

    public void DestroyPause()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.Find(CanvasPause.name+"(Clone)"));
    }

    public void DestroyGameOver()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.Find(CanvasGameOver.name+"(Clone)"));
    }

    public void Mute()
    {
        Debug.Log("MUTE");
        if (!mute)
            AudioListener.pause = true;
        else
            AudioListener.pause = false;

        mute = !mute;

    }

    public void pauseTheGame()
    {
        Time.timeScale = 0.0f;
    }


}