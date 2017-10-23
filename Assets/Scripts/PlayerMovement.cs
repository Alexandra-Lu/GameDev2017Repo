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
    public GameObject collidingobject;
    public GameObject player;
   
    private bool canMove = true;
    bool collectiblecol = false;
  
    bool holdingobject = false; //For picking up only ONE item
    bool colliding;
   

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

        if (holdingobject == true)
        { SpeedForce = 6; ; }
        if (holdingobject == false)
        { SpeedForce = 13; }

        DropItem();
        PickupItem();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            Debug.Log("plsworkpls");    //fuck yeah it fucking works
            colliding = true;
            collidingobject = collision.gameObject;
        }
        if (collision.CompareTag("Goal"))
        {
            CollectibleThing.transform.parent = null;
            holdingobject = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("endme");
        colliding = false;
        collidingobject = null; 

    }

    void PickupItem()
    {
        if (colliding && Input.GetKeyDown(KeyCode.Space)) {
            collidingobject.transform.parent = transform;
            holdingobject = true;
            colliding = false;
            Debug.Log("PICKED UP");
            CollectibleThing = collidingobject;

        } 

    }


    void DropItem()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && holdingobject) {
            Debug.Log("catscatscats");
            CollectibleThing.transform.parent = null;
            holdingobject = false;

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