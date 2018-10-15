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
            StartCoroutine(WaitTime(40f));

        transform.position += Direction * Velocity * Time.deltaTime;
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            Debug.Log("wall bounce");
            List<Vector2> normals = new List<Vector2>();

            ContactPoint2D[] contacts = new ContactPoint2D[4];

            collision.GetContacts(contacts);

            for (int i = 0; i < contacts.Length; i++)
            {
                normals.Add(contacts[i].normal);
            }

            EdgesCollisions edgesCollisions = collision.transform.GetComponent<EdgesCollisions>();

            foreach (Vector2 normal in normals)
            {
                Direction = Vector2.Reflect(Direction, normal);
                Direction.Normalize();
            }
        }
    }

    private void OnMouseEnter()
    {
        Destroy(transform.gameObject);
        Debug.Log("Good Job");
    }

    public IEnumerator WaitTime(float time2Count)
    {
        counting = true;
        yield return new WaitForSecondsRealtime(time2Count);

        Destroy(transform.gameObject);
        counting = false;
    }
}
