using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSceneManagement : MonoBehaviour {
    public SaveLog SAVE;
    public float TimePassed;
    public float TimeNow;

    public void Start()
    {
        TimePassed = 0;
    }

    public void Update()
    {
        
        if (GameControl.control.TruesecondsCount >= GameControl.control.getGameDuration())
        {
            TimePassed += Time.deltaTime;
            if (TimePassed >= 8f)
            {
                Debug.Log("end");
                BacktoMenu();
            }
           

        }
    }

    public void BacktoMenu()
    {
        GameControl.control.TruesecondsCount = 0;
        GameControl.control.secondsCount = 0;
        GameControl.control.minuteCount = 0;
        GameControl.control.SetScore(0);
        SceneManager.LoadScene("Menu");

    }

    
}
