using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagement : MonoBehaviour {
    public SaveLog SAVE;

    public void Update()
    {
        if (GameControl.control.TruesecondsCount >= GameControl.control.getGameDuration())
        {
            Debug.Log("end");
            SAVE.Save();
            BacktoMenu();
        }
    }

    public void BacktoMenu()
    {
        GameControl.control.secondsCount = 0;
        GameControl.control.minuteCount = 0;
        GameControl.control.SetScore(0);
        SceneManager.LoadScene("Menu");

    }

    
}
