using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TimerAndScore : MonoBehaviour {
    public Text timerText;
    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Update score & Timer
        UpdateTimerUI();
        UpdateScoreText();

        //Update Highscore if that's the case
        foreach (User usr in GameControl.savedGames)
        {
            if (usr.name == GameControl.PlayerName)
            {
                if (GameControl.control.GetScore() > usr.highscore)
                {
                    Debug.Log("here");
                    usr.highscore = GameControl.control.GetScore();

                    //Write to file
                    BinaryFormatter bf = new BinaryFormatter();

                    //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
                    File.Delete(Application.persistentDataPath + "/savedGames.txt");
                    FileStream file = File.Create(Application.persistentDataPath + "/savedGames.txt"); //you can call it anything you want
                    bf.Serialize(file, GameControl.savedGames);
                    file.Close();


                }
            }
        }

    }

    //Update timer
    public void UpdateTimerUI()
    {
        //set timer UI
        GameControl.control.secondsCount += Time.deltaTime;
        timerText.text = "Tempo: " + GameControl.control.minuteCount + "m" + (int)GameControl.control.secondsCount + "s";
        if (GameControl.control.secondsCount >= 60)
        {
            GameControl.control.minuteCount++;
            GameControl.control.secondsCount = 0;
        }
        else if (GameControl.control.minuteCount >= 60)
        {
            GameControl.control.minuteCount = 0;
        }
    }

    //Score Update
    void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + GameControl.control.GetScore();
    }
}
