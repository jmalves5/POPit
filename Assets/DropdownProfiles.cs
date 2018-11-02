using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownProfiles : MonoBehaviour
{
    public List<string> names = new List<string>() { "Convidado" };
    public Dropdown dropdown;
    public Text selectedUser;
    public OptionsMenu Options;

    public void Awake()
    {
        string name = GameControl.PlayerName;
        PopulateList();
        
        int i = 0;
        foreach (User usr in GameControl.savedGames)
        {
            if (name == usr.name) {
                dropdown.value=i+1;
                break;
            }
            i++;
        }

    }

    public void Dropdown_IndexChanged(int index)
    {
        
        if (index != 0)
        {
            selectedUser.text = "Jogador: " + names[index];

            GameControl.PlayerName = GameControl.savedGames[index - 1].name;
            GameControl.control.SetVelocity(GameControl.savedGames[index - 1].Velocity);
            GameControl.control.SetNObjects(GameControl.savedGames[index - 1].ObjectsNumber);
            GameControl.control.SetSpawnRate(GameControl.savedGames[index - 1].spawningRate);
            GameControl.control.SetObjectTTL(GameControl.savedGames[index - 1].ObjectTTL);
            GameControl.control.SetTTLUnlimit(GameControl.savedGames[index - 1].TTLUnlimit);
            //GameControl.control.SetUsedJoint(GameControl.savedGames[index - 1].jointToUse);
            GameControl.control.SetImpulseInibition(GameControl.savedGames[index - 1].impulseInibition);
            GameControl.control.SetInibImpProb(GameControl.savedGames[index - 1].impulseInibitionProb);
            GameControl.control.SetGameDuration(GameControl.savedGames[index-1].gameDuration);

            Options.GetGameControlValues();
        }
        else {
            GameControl.control.SetVelocity(200);
            GameControl.control.SetNObjects(4);
            GameControl.control.SetSpawnRate(2);
            GameControl.control.SetObjectTTL(10f);
            GameControl.control.SetTTLUnlimit(false);
            GameControl.control.SetImpulseInibition(true);
            GameControl.control.SetInibImpProb(50f);
            GameControl.control.SetGameDuration(300f);
            GameControl.PlayerName = "Convidado";

            Options.GetGameControlValues();

            selectedUser.text = "Sem dados de jogador. Nenhum dado será guardado.";
        }
            
    }

    public void Update()
    {
        PopulateList();
    }

    public void PopulateList() {
        
        names.Clear();
        names.Add("Convidado");
        foreach (User usr in GameControl.savedGames)
        {
            names.Add(usr.name);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(names);

        int i = 0;
        foreach (User usr in GameControl.savedGames)
        {
            if (GameControl.PlayerName == usr.name)
            {
                dropdown.value = i + 1;
                break;
            }
            i++;
        }

    }
}
