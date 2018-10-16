using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class MyCursor : MonoBehaviour
{

    //Needed variables
    GameObject KinectObject;
    private static GameObject HandCursor;
    public GameObject Artic;

    private GameObject body;
    private Vector3 newBodyScale;
    private Camera cam;
    private string usedArtic = "HandRight";



    void Awake()
    {
        //Finding Game Objects
        KinectObject = GameObject.Find("GameControl");
        HandCursor = GameObject.Find("MyCursor");
        newBodyScale = new Vector3(3, 3, 3);
        cam = FindObjectOfType<Camera>();

    }

    void Update()
    {
        //Find body ands follow right hand joint with cursor
        body = GameObject.Find("Body");

        if (GameControl.control.GetBSV().IsTracked())  //If a body is detected
        {

            body.transform.localScale = newBodyScale;
            ShearchForKinectJoints(usedArtic);
            HandFollow();

        }
        else
        {
            //Set Cursor to not be visible
            Cursor.visible = false;
            //Follow hand with cursor
            Vector3 temp = Input.mousePosition;
            temp.z = 10f;                           // Set this to be the distance you want the object to be placed in front of the camera.
            temp.y -= 22f;

            if (Camera.main != null)
            {               //On scene shift camera is not instatiated (this if statement resolves error)
                HandCursor.transform.position = Camera.main.ScreenToWorldPoint(temp);
            }
        }
    }

    //Function that finds Joint
    public void ShearchForKinectJoints(string usedArtic)
    {
        Artic = GameObject.Find("GameControl/Body/" + usedArtic);
    }

    //Function to follow hand with cursor
    public void HandFollow()
    {
        Vector3 offset = new Vector3(0, 0, -60);
        float smoothTime = 0.3F;
        Vector3 velocity = Vector3.zero;
        //GameControl.control.MyCursor.transform.position = Artic.transform.position + offset;
        //TESTAR COM KINECT ESTE FILTRO
        GameControl.control.MyCursor.transform.position = Vector3.SmoothDamp(GameControl.control.MyCursor.transform.position, Artic.transform.position + offset, ref velocity, smoothTime);

    }

    //Choose articulation
    public void ChooseArtic(int i)
    {

        switch (i)
        {
            case 0:
                usedArtic = "HandRight";
                GameControl.control.SetUsedJoint(usedArtic);
                break;
            case 1:
                usedArtic = "HandLeft";
                GameControl.control.SetUsedJoint(usedArtic);
                break;
            case 2:
                usedArtic = "Head";
                GameControl.control.SetUsedJoint(usedArtic);
                break;
        }

    }
}
