using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreation : MonoBehaviour {
    private bool spawn;
    public Ball BounceBall;
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
            StartCoroutine(WaitTime(5f)); //Ball generation time

        if (spawn) {
            aux.x = Random.Range(-300, 300);
            aux.y = Random.Range(-200, 150);
            aux.z = 0;
            Ball newBall = Instantiate(BounceBall, aux, BounceBall.transform.rotation);
            spawn = false;
            GameControl.lost = false;
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
