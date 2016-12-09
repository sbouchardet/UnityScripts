using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Demand
{
    public GameObject contador;
    public string Enemy;
    public int Amount;

    public Demand(string Enm, int a = -1)
    {
        this.Enemy = Enm;
        this.Amount = a;
    }


    public override string ToString()
    {
        return string.Format("[LevelConfig]" + this.Enemy + " [ " + this.Amount + " ]");
    }

    public override bool Equals(object obj)
    {
        Demand other = obj as Demand;
        if (other.Enemy != null && this.Enemy != null)
            return this.Enemy == other.Enemy;
        return false;
    }

}




public class LevelConfig : MonoBehaviour
{

    //FIXME: need refactoring!


    public GameObject StartPoint;
    public List<Demand> ListOfDemands = new List<Demand>();
    public float timeInSeconds;
    public GameObject TimeCount;

    public Font NumberFont;
    public Color ColorNumber = new Color(1, 1, 1, 1);
    public Font LetterFont;
    public Color ColorLetter = new Color(1, 1, 1, 1);
    public int FontSize = 20;
    private float timeNow;
    private bool pause;

    void Start()
    {
        
        pause = false;
        timeNow = timeInSeconds;
        for (int i = 0; i < ListOfDemands.Count; i++)
        {
            UpdateTextCanvas(ListOfDemands[i]);
        }
    }

    void Update()
    {
        //if (!pause)
            timeNow -= Time.deltaTime;
        if (Lose())
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gm.ShowGameOver();
            

        }
        else {
            UpdateTextTime(timeNow);

        }

    }


    public void UpdateListOfDemands(string name)
    {
        Debug.Log(name);
        for (int i = 0; i < ListOfDemands.Count; i++)
            Debug.Log(ListOfDemands[i]);
        if (ListOfDemands.IndexOf(new Demand(name)) > -1)
        {
            Demand d = ListOfDemands[ListOfDemands.IndexOf(new Demand(name))];
            d.Amount -= 1;
            UpdateTextCanvas(d);


            if (Win())
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                gm.loadNextLevel();
            }
        }

    }

    public void respawn()
    {
        transform.position = new Vector3(StartPoint.transform.position.x,
            StartPoint.transform.position.y + 5,
            StartPoint.transform.position.z);
        timeNow = timeInSeconds;


    }

    private void UpdateTextCanvas(Demand d)
    {
        GameObject txtCanvas = d.contador;
        Text txt = txtCanvas.GetComponent<Text>();
        txt.text = d.Amount + "";
    }

    private void UpdateTextTime(float t)
    {
        Text txtTime = TimeCount.GetComponent<Text>();
        txtTime.text = converSeconds(t);
    }

    private string converSeconds(float t)
    {
        int min = 0;
        int sec = 0;
        float tNow = t;
        while (tNow / 60 > 1)
        {
            min += 1;
            tNow -= 60;
        }
        sec = (int)tNow;
        return min + ":" + sec;
    }

    private bool Win()
    {
        bool result = true;
        for (int i = 0; i < ListOfDemands.Count; i++)
        {
            result = result && ListOfDemands[i].Amount == 0;
        }
        return result;
    }

    private bool Lose()
    {
        PlayerStatus ps = GetComponent<PlayerStatus>();
        return timeNow <= 0 || ps.getLife() <= 0;

    }

    public void pauseTheGame()
    {
        this.pause = true;
    }
    public void unpauseTheGame()
    {
        this.pause = false;
    }

    public bool getPauseState()
    {
        return this.pause;
    }
}