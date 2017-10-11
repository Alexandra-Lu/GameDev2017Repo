using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    // public float Speed = 10;
    //public float MaxSpeed = 10;
    //public float Acceleration = 10;
    //public float Deceleration = 10;
    // Use this for initialization
    public float MaxSpeed = 0f;
    public float SpeedForce = 10f;

    public GameObject CollectibleThing;
    public GameObject player;
   
    private bool canMove = true;
    private bool hinder = false;
    bool collectiblecol = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            { GetComponent<Rigidbody2D>().AddForce(transform.right * SpeedForce); }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            { MaxSpeed = 0; }

            if (Input.GetKey(KeyCode.LeftArrow))
            { GetComponent<Rigidbody2D>().AddForce(-transform.right * SpeedForce); }

            if (Input.GetKey(KeyCode.UpArrow))
            { GetComponent<Rigidbody2D>().AddForce(transform.up * SpeedForce); }

            if (Input.GetKey(KeyCode.DownArrow))
            { GetComponent<Rigidbody2D>().AddForce(-transform.up * SpeedForce); }

        }

        //hinder slows down the movement to imply weight of object carried
        if (hinder == true)
        {
            SpeedForce = 6;
        }

      
    }
    void OnTriggerStay2D(Collider2D col) 
        //TriggerEnter is only called once, Trigger Stay will actually allow the added 'space' condition to work
    {
        if (col.CompareTag("Collectible")) //holy shit how did i not know about tags until now
        {
            collectiblecol = true;
            Debug.Log("end me");

            if (Input.GetKeyDown("space"))
            {
                Debug.Log("ImBeggingYouPleaseWork"); //fuck yeah it totally works 
            Destroy(col.gameObject);
                hinder = true; 
            }

        }
        //Collision with the escape/goal space removes the 'weight' of the object and resets speed
        if (col.CompareTag("Goal"))
        {
            hinder = false;
            SpeedForce = 13;
        }
    }
 
    void OnCollisionEnter2D(Collision2D plswork)
        //Collider2D = Trigger; Collision2D = Collision
    {
        //access comparetag() from gameobject only???
        //".tag" instead of "CompareTag" IDFK WHY BUT IT FINALLY WORKS

        //Halt movement when colliding with an enemy
        if (plswork.gameObject.tag == "Enemy")
        {
            GameControl.instance.Death();
            canMove = false;
        }
        Debug.Log("iwanttodie");
        
    }
}