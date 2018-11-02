using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponentInParent<SaveLog>().CreateNew();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
