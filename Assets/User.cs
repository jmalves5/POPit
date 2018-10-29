﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public static User current;

    //public string jointToUse;
    public string name;
    public float Velocity;
    public float ObjectsNumber;
    public float spawningRate;
    public float ObjectTTL;
    public bool impulseInibition;
    public float impulseInibitionProb;
    public float highscore;

    public User()
    {
        //jointToUse = "HandRight";
        this.name = "";
        Velocity = 200;
        ObjectsNumber = 4;
        spawningRate = 2;
        ObjectTTL = 10f;
        impulseInibition = true;
        impulseInibitionProb = 50f;
        highscore = 0;
    }
}
