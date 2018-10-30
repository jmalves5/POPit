using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonCollider : MonoBehaviour {
 
    public RPB LoadingBar;
    public Button playButton;
    private Vector3 start;
    float timer;
    float timerenabler;


    // Use this for initialization
    void Start () {
        LoadingBar.gameObject.SetActive(false);
        timer = 0.0f;
        timerenabler = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * timerenabler;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        //Find body ands follow right hand joint with cursor

        if (GameControl.control.GetBSV().IsTracked())  //If a body is detected
        {
            Debug.Log("Triggered");
            LoadingBar.gameObject.SetActive(true);
            timerenabler = 1f;

            if (timer > 2)
            {
                playButton.onClick.Invoke();
                timer = 0;
                timerenabler = 0f;
                LoadingBar.currentAmount = 0;
                LoadingBar.gameObject.SetActive(false);
                Debug.Log("Untriggered");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (GameControl.control.GetBSV().IsTracked())  //If a body is detected
        {
            LoadingBar.currentAmount = 0;
            LoadingBar.gameObject.SetActive(false);
            timerenabler = 0f;
            timer = 0;
        }
    }
}
