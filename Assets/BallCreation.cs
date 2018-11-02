using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreation : MonoBehaviour {
    private bool spawn;
    public Ball BounceBall;
    public BallRed BounceBallRed;
    private bool waiting;
    private Vector3 aux;

	// Use this for initialization
	void Start () {
        spawn = true;
        waiting = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControl.lost == true)
        {
            spawn = true;
        }       


        if(!waiting)
            StartCoroutine(WaitTime(10f / GameControl.control.getSpawnRate())); //Ball generation time

        if (spawn && GameControl.control.getCurrNumberObjects()<GameControl.control.getNObjects() && GameControl.control.TruesecondsCount < GameControl.control.getGameDuration()) {
            aux.x = Random.Range(-300, 300);
            aux.y = Random.Range(-200, 100);
            aux.z = 0;

            var r = Random.Range(0, 100);
            if (r <= GameControl.control.GetImpulseInibitionProb() && GameControl.control.GetImpulseInibitionBool())
            {
                BallRed newBall = Instantiate(BounceBallRed, aux, BounceBallRed.transform.rotation);
            }
            else
            {
                Debug.Log(GameControl.control.GetImpulseInibitionBool());
                Ball newBall = Instantiate(BounceBall, aux, BounceBall.transform.rotation);
            }
            

            
            spawn = false;
            GameControl.lost = false;
            GameControl.control.incrementCurrNumberObjects();
        }
    }

    public IEnumerator WaitTime(float time2Count)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(time2Count);
        waiting = false;
        spawn = true;
        
    }
}
