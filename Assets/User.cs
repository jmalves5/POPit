using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public static User current;

    //public string jointToUse;
    public string name;
    public float gameDuration;
    public float Velocity;
    public float ObjectsNumber;
    public float spawningRate;
    public float ObjectTTL;
    public bool TTLUnlimit;
    public bool impulseInibition;
    public float impulseInibitionProb;
    public float highscore;


    public User()
    {
        //jointToUse = "HandRight";
        this.name = "";
        gameDuration = 300f;
        Velocity = 200;
        ObjectsNumber = 4;
        spawningRate = 2;
        ObjectTTL = 10f;
        TTLUnlimit = false;
        impulseInibition = true;
        impulseInibitionProb = 50f;
        highscore = 0;
    }
}
