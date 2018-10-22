using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgesCollisions : MonoBehaviour {

	
	void Start () {
        Camera cam = Camera.main;
        GameObject ceiling = GameObject.Find("ceiling");
        GameObject floor = GameObject.Find("floor");
        GameObject lwall = GameObject.Find("rwall");
        GameObject rwall = GameObject.Find("lwall");

        Vector2 cantoInferiorEsquerdo = cam.ScreenToWorldPoint(new Vector3 (-10, -10, 0));
        Vector2 cantoSuperiorEsquerdo = cam.ScreenToWorldPoint(new Vector3(-10, Screen.height-100, 0));
        Vector2 cantoSuperiorDireito = cam.ScreenToWorldPoint(new Vector3(Screen.width+10, Screen.height-100, 0));
        Vector2 cantoInferiorDireito = cam.ScreenToWorldPoint(new Vector3(Screen.width+10, -10, 0));


        ceiling.GetComponent<EdgeCollider2D>().points = new Vector2[2] {cantoSuperiorEsquerdo, cantoSuperiorDireito};
        floor.GetComponent<EdgeCollider2D>().points = new Vector2[2] {cantoInferiorEsquerdo, cantoInferiorDireito};
        rwall.GetComponent<EdgeCollider2D>().points = new Vector2[2] {cantoSuperiorDireito, cantoInferiorDireito};
        lwall.GetComponent<EdgeCollider2D>().points = new Vector2[2] {cantoInferiorEsquerdo, cantoSuperiorEsquerdo};

        ceiling.gameObject.tag = "ceiling";
        floor.gameObject.tag = "floor";
        rwall.gameObject.tag = "rwall";
        lwall.gameObject.tag = "lwall";
    }
	
	
	void Update () {
		
	}
}
