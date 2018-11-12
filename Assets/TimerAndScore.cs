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
        GameControl.control.TruesecondsCount = 0;
        GameControl.control.minuteCount = (int)GameControl.control.getGameDuration() / 60;
        GameControl.control.secondsCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //Update score & Timer
        UpdateTimerUI();
        UpdateScoreText();

    }

    //Update timer
    public void UpdateTimerUI()
    {
        //set timer UI
        GameControl.control.TruesecondsCount += Time.deltaTime;
        GameControl.control.secondsCount -= Time.deltaTime;

        if (GameControl.control.TruesecondsCount < GameControl.control.getGameDuration()+1) {
            if (GameControl.control.secondsCount < 0)
            {
                GameControl.control.minuteCount--;
                GameControl.control.secondsCount = 60;
            }
            timerText.text = "Tempo: " + GameControl.control.minuteCount + "m" + (int)GameControl.control.secondsCount + "s";

        }
        
    }

    //Score Update
    void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + GameControl.control.GetScore();
    }
}
