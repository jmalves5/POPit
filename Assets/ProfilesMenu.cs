using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;


//This class contains all the objects present in the Options Menu
public class ProfilesMenu : MonoBehaviour {

    public Text nameText;
    public Text invalidName;
    public DropdownProfiles dropdown;
    private bool repeated = false;

    public void Start()
    {
        invalidName.text = "";
        Load();
    }

    public void Update()
    {
        Load();
    }

    public void SaveUser() {

        Debug.Log("Updated Users");
        GameControl.addedUsers = true;

        User usr = new User();
        if (Regex.IsMatch(nameText.text, "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"))
        {
            usr.name = nameText.text;
            usr.Velocity = GameControl.control.getVelocity();
            usr.ObjectsNumber = GameControl.control.getNObjects();
            usr.spawningRate = GameControl.control.getSpawnRate(); ;
            usr.ObjectTTL = GameControl.control.getObjectTTL();
            usr.TTLUnlimit = GameControl.control.getTTLUnlimit();
            //usr.jointToUse = GameControl.UsedJoint;
            usr.impulseInibition = GameControl.control.GetImpulseInibitionBool();
            usr.impulseInibitionProb = GameControl.control.GetImpulseInibitionProb();

            usr.highscore = 0;
            invalidName.text = "";
            GameControl.PlayerName = nameText.text;
        }
        else {
            invalidName.text = "O seu nome contém caracteres inválidos";  
        }

        foreach (User user in GameControl.savedGames)
        {
            if (usr.name == user.name && Regex.IsMatch(nameText.text, "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"))
            {
                //Update user
                Debug.Log("Repeated user, updated");
                user.Velocity = GameControl.control.getVelocity();
                user.ObjectsNumber = GameControl.control.getNObjects();
                user.spawningRate = GameControl.control.getSpawnRate(); ;
                user.ObjectTTL = GameControl.control.getObjectTTL();
                user.TTLUnlimit = GameControl.control.getTTLUnlimit();
                //usr.jointToUse = GameControl.UsedJoint;
                user.impulseInibition = GameControl.control.GetImpulseInibitionBool();
                user.impulseInibitionProb = GameControl.control.GetImpulseInibitionProb();
                if (user.highscore < GameControl.control.GetScore())
                    user.highscore = GameControl.control.GetScore(); 

                //Write to file
                BinaryFormatter bf = new BinaryFormatter();
               
                //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
                File.Delete(Application.persistentDataPath + "/savedGames.txt");
                FileStream file = File.Create(Application.persistentDataPath + "/savedGames.txt"); //you can call it anything you want
                bf.Serialize(file, GameControl.savedGames);
                file.Close();
                dropdown.PopulateList();
                repeated = true;
            }
        }

        if (!repeated) {
            if (Regex.IsMatch(nameText.text, "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"))
            {
                //Add user
                GameControl.savedGames.Add(usr);
                
                //Write to file
                BinaryFormatter bf = new BinaryFormatter();
                
                //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
                File.Delete(Application.persistentDataPath + "/savedGames.txt");
                FileStream file = File.Create(Application.persistentDataPath + "/savedGames.txt"); //you can call it anything you want
                bf.Serialize(file, GameControl.savedGames);
                file.Close();
                dropdown.PopulateList();
            }
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

    public void Delete()
    {
        GameControl.removedUsers = true;
        //Find user and delete him. Then write new file
        int k = 0;
        List<User> GamesSavedAUX = new List<User>();

        foreach (User usr in GameControl.savedGames)
        {
            GamesSavedAUX.Add(usr);
        }

        foreach (User usr in GamesSavedAUX) {
            k++;
            if ("Jogador: " + usr.name == dropdown.selectedUser.text) {
                GameControl.savedGames.RemoveAt(k-1);
                
                for (int i = dropdown.names.Count - 1; i >= 0; i--)
                {
                    if ("Jogador: " + dropdown.names[i] == dropdown.selectedUser.text && dropdown.selectedUser.text != "Sem dados de jogador") dropdown.names.RemoveAt(i);
                }

                dropdown.selectedUser.text = "Sem dados de jogador";
                dropdown.dropdown.value = 0;


                Debug.Log(dropdown.selectedUser.text);


                BinaryFormatter bf = new BinaryFormatter();
                //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
                File.Delete(Application.persistentDataPath + "/savedGames.txt");
                FileStream file = File.Create(Application.persistentDataPath + "/savedGames.txt"); //you can call it anything you want
                bf.Serialize(file, GameControl.savedGames);
                file.Close();
                dropdown.PopulateList();
            }
        }
    }
}
