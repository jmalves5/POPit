using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLog : MonoBehaviour {

    public void Save()
    {

        if (GameControl.PlayerName != "Convidado")
        {
            List<string[]> rowData = new List<string[]>();


            string[] rowDataTemp = new string[12];
            rowDataTemp[0] = GameControl.PlayerName;
            rowDataTemp[1] = GameControl.control.getGameDuration().ToString();
            rowDataTemp[2] = GameControl.control.getVelocity().ToString();
            rowDataTemp[3] = GameControl.control.getNObjects().ToString();
            rowDataTemp[4] = GameControl.control.getSpawnRate().ToString();
            rowDataTemp[5] = GameControl.control.getObjectTTL().ToString();
            rowDataTemp[6] = GameControl.control.getTTLUnlimit().ToString();
            rowDataTemp[7] = GameControl.control.GetImpulseInibitionBool().ToString();
            rowDataTemp[8] = GameControl.control.GetImpulseInibitionProb().ToString();
            rowDataTemp[9] = GameControl.control.GetScore().ToString();
            rowDataTemp[10] = GameControl.control.goodPops.ToString();
            rowDataTemp[11] = GameControl.control.badPops.ToString();
            Debug.Log(GameControl.control.GetScore().ToString());
            rowData.Add(rowDataTemp);

            string[][] output = new string[rowData.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowData[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            string filePath = Application.persistentDataPath + "/DATA/" + GameControl.PlayerName + "/Log.csv";

            File.AppendAllText(filePath, sb.ToString());
        }
    }

    public void CreateNew()
    {
        List<string[]> rowData = new List<string[]>();

        if (GameControl.PlayerName != "Convidado")
        {
            if (!Directory.Exists(Application.persistentDataPath + "/DATA/" + GameControl.PlayerName))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/DATA/" + GameControl.PlayerName); //windows only?
                // Creating First row of titles manually..
                string[] rowDataTemp = new string[12];
                rowDataTemp[0] = "Name";
                rowDataTemp[1] = "Game Duration";
                rowDataTemp[2] = "Ball Velocity";
                rowDataTemp[3] = "Max Objects Number";
                rowDataTemp[4] = "Spawning Rate";
                rowDataTemp[5] = "Object Time to Live";
                rowDataTemp[6] = "Infinite Time to Live";
                rowDataTemp[7] = "Impulse Inibition";
                rowDataTemp[8] = "Impulse Inibition Probability";
                rowDataTemp[9] = "Score";
                rowDataTemp[10] = "Good Pops";
                rowDataTemp[11] = "Bad Pops";
                rowData.Add(rowDataTemp);

                string[][] output = new string[rowData.Count][];

                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = rowData[i];
                }

                int length = output.GetLength(0);
                string delimiter = ",";

                StringBuilder sb = new StringBuilder();

                for (int index = 0; index < length; index++)
                    sb.AppendLine(string.Join(delimiter, output[index]));


                string filePath = Application.persistentDataPath + "/DATA/" + GameControl.PlayerName + "/Log.csv";

                File.AppendAllText(filePath, sb.ToString());
            }
        }
    }

    public void Delete() //This must run before ProfilesMenu.Delete()
    {
        if (Directory.Exists(Application.persistentDataPath + "/DATA/" + GameControl.PlayerName))
        {
           Directory.Delete(Application.persistentDataPath + "/DATA/" + GameControl.PlayerName, true); //windows only?   
        }
    }


}
