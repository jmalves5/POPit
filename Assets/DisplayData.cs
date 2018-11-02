using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class DisplayData : MonoBehaviour {

    public SaveLog SAVE;
    public Text finalText;
    private bool done = false;

    // Use this for initialization
    void Start () {
        finalText.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameControl.control.TruesecondsCount >= GameControl.control.getGameDuration() && !done)
        {
            done = true;
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
            SAVE.Save();
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            for (int i = 0; i < balls.Length; i++){
                Destroy(balls[i]);
            }
            finalText.gameObject.SetActive(true);
            finalText.text = "Pops Correctos: " + GameControl.control.goodPops + "\nPops Incorrectos: " + GameControl.control.badPops + "\nScore: " + GameControl.control.GetScore();
        }
    }
}
