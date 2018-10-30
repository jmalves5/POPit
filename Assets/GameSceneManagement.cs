using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagement : MonoBehaviour {

    public void BacktoMenu()
    {
        GameControl.control.secondsCount = 0;
        GameControl.control.minuteCount = 0;
        GameControl.control.SetScore(0);
        SceneManager.LoadScene("Menu");

    }
}
