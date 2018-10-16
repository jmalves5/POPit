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
    public Rigidbody2D rb;

   
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        Velocity = 200;
        Direction = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        Direction.Normalize(); // equivalente a dizer direction = direcion.normalized;
        counting = false;
    }
	
	
	void Update ()
    {
        if(transform.position.x> Screen.width/2 || transform.position.y>Screen.height/2 || transform.position.x < -Screen.width/2 || transform.position.y < -Screen.height/2)
        {
            GameControl.lost = true;
            Destroy(transform.gameObject);
        }


        Velocity = GameControl.control.getVelocity();

        if (!counting)
            StartCoroutine(WaitTime(GameControl.control.getNObjects()*5f));

       // transform.position += Direction * Velocity * Time.deltaTime;
	}


    void FixedUpdate()
    {

        //[.....comando de teclas aqui...]

        //Vector3 movement = new Vector3(1, 1f, 0);
        //rb.velocity = movement * 0.5f;
        

        transform.position += Direction * Velocity * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EdgesCollisions edgesCollisions = collision.transform.GetComponent<EdgesCollisions>();

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ball") {
            Debug.Log("wall bounce");
            List<Vector2> normals = new List<Vector2>();

            ContactPoint2D[] contacts = new ContactPoint2D[16];

            collision.GetContacts(contacts);

            for (int i = 0; i < contacts.Length; i++)
            {
                normals.Add(contacts[i].normal);
            }



            foreach (Vector2 normal in normals)
            {
                Direction = Vector2.Reflect(Direction, normal);
                Direction.Normalize();

            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            Debug.Log("Good Job");
            GameControl.control.incrementScore();
            Destroy(transform.gameObject);
            GameControl.lost = true;
        }
    }

    private void OnMouseEnter()
    {
      
    }

    public IEnumerator WaitTime(float time2Count)
    {
        counting = true;
        yield return new WaitForSecondsRealtime(time2Count);

        Destroy(transform.gameObject);
        counting = false;
    }
}
