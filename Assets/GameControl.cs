using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


//Game Control singleton. Used to manage multiple stages of the game
public class GameControl : MonoBehaviour
{
    private BodySourceView BSV;
    public static GameControl control;

    //private BodySourceView BSV;

    //public static List<User> savedGames = new List<User>();

    //Declare game options variables

    private static float Velocity = 200;  //plate velocity
    private static float ObjectsNumber = 4;
    private static float spawningRate = 2;
    private static float currNumberofObjects = 0;


    public static string UsedJoint;  //Used joint to control cursor
    public static bool lost = false;
    //public static string PlayerName; //player name



    //Time and score Counters
    private static int score = 0;  //Score
    public float secondsCount;
    public int minuteCount;
    public GameObject MyCursor;


    private void Start()
    {
      //  UsedJoint = "HandLeft";
      //  PlayerName = "----------------------------";
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