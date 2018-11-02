using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;


public class SaveLog : MonoBehaviour {

    public void Save()
    {
        if (GameControl.PlayerName != "Convidado")
        {
            List<string[]> rowData = new List<string[]>();


            string[] rowDataTemp = new string[9];
            rowDataTemp[0] = GameControl.PlayerName;
            rowDataTemp[1] = GameControl.control.getVelocity().ToString();
            rowDataTemp[2] = GameControl.control.getNObjects().ToString();
            rowDataTemp[3] = GameControl.control.getSpawnRate().ToString();
            rowDataTemp[4] = GameControl.control.getObjectTTL().ToString();
            rowDataTemp[5] = GameControl.control.getTTLUnlimit().ToString();
            rowDataTemp[6] = GameControl.control.GetImpulseInibitionBool().ToString();
            rowDataTemp[7] = GameControl.control.GetImpulseInibitionProb().ToString();
            rowDataTemp[8] = GameControl.control.GetScore().ToString();
            Debug.Log(GameControl.control.GetScore().ToString());
            rowData.Add(rowDataTemp);

            string[][] output = new string[rowData.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowData[i];
            }

            int length = output.GetLength(0);
            string delimiter = ";";

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
            Directory.CreateDirectory(Application.persistentDataPath + "/DATA/" + GameControl.PlayerName);
 
            // Creating First row of titles manually..
            string[] rowDataTemp = new string[9];
            rowDataTemp[0] = "Name";
            rowDataTemp[1] = "Ball Velocity";
            rowDataTemp[2] = "Max Objects Number";
            rowDataTemp[3] = "Spawning Rate";
            rowDataTemp[4] = "Object Time to Live";
            rowDataTemp[5] = "Infinite Time to Live";
            rowDataTemp[6] = "Impulse Inibition";
            rowDataTemp[7] = "Impulse Inibition Probability";
            rowDataTemp[8] = "Score";
            rowData.Add(rowDataTemp);

            string[][] output = new string[rowData.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowData[i];
            }

            int length = output.GetLength(0);
            string delimiter = ";";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));


            string filePath = Application.persistentDataPath + "/DATA/" + GameControl.PlayerName + "/Log.csv";

            File.AppendAllText(filePath, sb.ToString());
        }
    }
}
