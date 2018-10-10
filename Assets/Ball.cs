using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 Direction;
    public float Velocity;
    private bool counting;
    private bool death;
    private Vector3 oldPos;
    private Vector3 aux;
    public Ball BounceBall;

   
    void Start ()
    {
        Velocity = 200;
        Direction = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        Direction.Normalize(); // equivalente a dizer direction = direcion.normalized;
        counting = false;
    }
	
	
	void Update ()
    {
        if (!counting)
            StartCoroutine(WaitTime(30f));

        transform.position += Direction * Velocity * Time.deltaTime;
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool wrongCollision = false;
        Vector2 normal = collision.contacts[0].normal;
        EdgesCollisions edgesCollisions = collision.transform.GetComponent<EdgesCollisions>();

        if (!wrongCollision)
        {
            Direction = Vector2.Reflect(Direction, normal);
            Direction.Normalize();
        }

    }

    public IEnumerator WaitTime(float time2Count)
    {
        Debug.Log("it's ya boy");
        counting = true;
        yield return new WaitForSecondsRealtime(time2Count);
        Debug.Log("it's ya boy2");
        Destroy(transform.gameObject);
        counting = false;
    }
}
