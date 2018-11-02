using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRed : MonoBehaviour {

    private Vector3 Direction;
    public float Velocity;
    private bool counting;
    private bool death;
    private Vector3 oldPos;
    private Vector3 aux;
    public BallRed BounceBall;


   
    void Start ()
    {
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
        {
            StartCoroutine(WaitTime(GameControl.control.getObjectTTL()));
        }
            
    }


    void FixedUpdate()
    {
        transform.position += Direction * Velocity * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EdgesCollisions edgesCollisions = collision.transform.GetComponent<EdgesCollisions>();

        if (collision.gameObject.tag == "Cursor")
        {
            Debug.Log("Bad Job");
            GameControl.control.badPops++;
            GameControl.control.decrementScore();
            Destroy(transform.gameObject);
            GameControl.control.decrementCurrNumberObjects();
        }

        if (collision.gameObject.tag == "ceiling" || collision.gameObject.tag == "lwall" ||
                collision.gameObject.tag == "rwall" || collision.gameObject.tag == "floor")
        {

            Vector2 normal = new Vector2(0, 0);

            switch (collision.gameObject.tag)
            {
                case "ceiling":
                    normal = new Vector2(0, -1);
                    break;
                case "floor":
                    normal = new Vector2(0, 1);
                    break;
                case "rwall":
                    normal = new Vector2(-1, 0);
                    break;
                case "lwall":
                    normal = new Vector2(1, 0);
                    break;
            }

            Direction = Vector2.Reflect(Direction, normal);
            Direction.Normalize();
        }
    }

    //UNCOMMENT THIS FOR BALL COLLISIONS. WARNING: MAY CAUSE INSTABILITY IN WALL COLLISIONS.
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        List<Vector2> normals = new List<Vector2>();

    //        ContactPoint2D[] contacts = new ContactPoint2D[1];

    //        collision.GetContacts(contacts);

    //        Direction = Vector2.Reflect(Direction, contacts[0].normal);
    //        Direction.Normalize();
    //    }
    //}

    public IEnumerator WaitTime(float time2Count)
    {
        counting = true;
        yield return new WaitForSecondsRealtime(time2Count);

        //UNCOMMENT TO ENABLE OBJECT SELF-DESTRUCTION
        Destroy(transform.gameObject);
        GameControl.control.decrementCurrNumberObjects();

        counting = false;
    }
}
