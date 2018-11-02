using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;


//Game Control singleton. Used to manage multiple stages of the game
public class GameControl : MonoBehaviour
{
    private BodySourceView BSV;
    public static GameControl control;
    public static List<User> savedGames = new List<User>();

    //Declare game options variables

    private static float Velocity = 200; 
    private static float ObjectsNumber = 4;
    private static float spawningRate = 2;
    private static float currNumberofObjects = 0;
    private static float ObjectTTL = 10f;
    private static bool TTLUnlimit = false;
    private static bool impulseInibition = true;
    private static float impulseInibitionProb = 50f;
    private static float GameDuration = 300f;

    public static bool addedUsers = false;
    public static bool removedUsers = false;

    public static string PlayerName =  "";
    public static string UsedJoint;  //Used joint to control cursor
    public static bool lost = false;




    //Time and score Counters
    private static int score = 0;  //Score
    public float secondsCount;
    public float TruesecondsCount;
    public int minuteCount;
    public GameObject MyCursor;


    private void Start()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/Data");
        UsedJoint = "HandRight";
        PlayerName = "Convidado";
    }

    //Making this object a singleton using DontDestroyOnLoad()
    void Awake()
    {

        //To get body isTracked flag from BSV
        BSV = gameObject.GetComponent<BodySourceView>();

        if (control != null)
        {
            Destroy(gameObject);
        }
        else
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        //Assume no body is being tracked
        BSV._trackRig = false;
    }

    //Useful getter and setter functions

    //Get number of Objects
    public float getNObjects()
    {
        return ObjectsNumber;
    }

    public void SetNObjects(float numberOfObjects)
    {
        ObjectsNumber = numberOfObjects;
    }



    //Get plate velocity
    public float getVelocity()
    {
        return Velocity;
    }

    //Set platevelocity
    public void SetVelocity(float NewVelocity)
    {
        Velocity = NewVelocity;
    }

    //Get game duration
    public float getGameDuration()
    {
        return GameDuration;
    }

    //Set game duration
    public void SetGameDuration(float NewGameDuration)
    {
        GameDuration = NewGameDuration;
    }



    //Get spawn rate
    public float getSpawnRate()
    {
        return spawningRate;
    }

    //Set spawn rate
    public void SetSpawnRate(float NewSpawnRate)
    {
        spawningRate = NewSpawnRate;
    }

    //Get object ttl (time to live)
    public float getObjectTTL()
    {
        return ObjectTTL;
    }

    //Get object ttl (time to live)
    public void SetObjectTTL(float NewObjectTTL)
    {
        ObjectTTL = NewObjectTTL;
    }

    //sET ttl TOGGLE
    public void SetTTLUnlimit(bool newTTLUnlimit)
    {
        TTLUnlimit = newTTLUnlimit;
    }

    public bool getTTLUnlimit()
    {
        return TTLUnlimit;
    }

    //get number of objects
    public float getCurrNumberObjects()
    {
        return currNumberofObjects;
    }

    //Increment number of objects
    public void incrementCurrNumberObjects() {
        currNumberofObjects++;
    }

    //decrement number of objects
    public void decrementCurrNumberObjects()
    {
        currNumberofObjects--;
    }



    //Get score
    public float GetScore()
    {
        return score;
    }

    //Set score (useful for resetting)
    public void SetScore(int NewScore)
    {
        score = NewScore;
    }

    //Increment the score
    public void incrementScore()
    {
        score = score + 200;
    }

    //Decrement the score
    public void decrementScore()
    {
        score = score - 200;
        if (score < 0)
        {
            score = 0;
        }
    }


    //Get impulse inibition flag
    public bool GetImpulseInibitionBool()
    {
        return impulseInibition;
    }

    //Toggle impulse inibtion flag
    public void ToggleImpulseInibition()
    {
        impulseInibition = !impulseInibition;
    }

    //Set impulse inibtion flag
    public void SetImpulseInibition(bool newii)
    {
        impulseInibition = newii;
    }


    //Get impulse inibition probability
    public float GetImpulseInibitionProb()
    {
        return impulseInibitionProb;
    }

    //Set impulse inibition probability
    public void SetInibImpProb(float NewimpulseInibitionProb)
    {
        impulseInibitionProb = NewimpulseInibitionProb;
    }


    //Joints functions
    public void SetUsedJoint(string joint)
    {
        UsedJoint = joint;
    }

    public string GetUsedJoint()
    {
        return UsedJoint;
    }

    //Get BSV
    public BodySourceView GetBSV()
    {
        return BSV;
    }
}