using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UserList : MonoBehaviour {
   
    public Text NameText;
    public Text ScoreText;
    private List<Text> TextObjs = new List<Text>();

    public void Start()
    {
        GameControl.savedGames.Clear();
        //Read file
        Load();
        //Remove old texts
        DestroyTexts();

        //Populate lists
        PopulateLists();

    }

    public void FixedUpdate()
    {
        if (GameControl.addedUsers)
        {
            //Read file
            Load();

            GameControl.savedGames.Sort(SortByScore);

            //Remove old texts
            DestroyTexts();

            //Populate lists
            PopulateLists();



            GameControl.addedUsers = false;
        }


        if (GameControl.removedUsers)
        {
            //Read file
            Load();

            GameControl.savedGames.Sort(SortByScore);

            //Remove old texts
            DestroyTexts();
            //Populate lists
            PopulateLists();

            GameControl.removedUsers = false;
        }
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.txt"))
        {
            //Load file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.txt", FileMode.Open);
            GameControl.savedGames = (List<User>)bf.Deserialize(file);
            file.Close();
        }
    }

    public void PopulateLists() {
        GameControl.savedGames.Sort(SortByScore);
        foreach (User usr in GameControl.savedGames)
        {
            //Instantiates the Object
            Text NameTextBox = Instantiate(NameText, NameText.transform.position, NameText.transform.rotation);
            NameTextBox.text = usr.name;
            NameTextBox.transform.SetParent(GameObject.Find("GridNames").transform, false);
            TextObjs.Add(NameTextBox);


            Text ScoreTextBox = Instantiate(ScoreText, ScoreText.transform.position, ScoreText.transform.rotation);
            ScoreTextBox.text = usr.highscore.ToString();
            ScoreTextBox.transform.SetParent(GameObject.Find("GridScores").transform, false);
            TextObjs.Add(ScoreTextBox);
        }
    }

    public void DestroyTexts() {
        foreach (Text txt in TextObjs)
        {
            if(txt!=null)
                Destroy(txt.transform.gameObject);
            
        }
       
    }

    static int SortByScore(User p1, User p2)
     {
         return p2.highscore.CompareTo(p1.highscore);
     }



}

