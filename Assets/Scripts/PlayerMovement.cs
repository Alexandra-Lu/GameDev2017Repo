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
   
    private bool canMove = true;

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
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Collectible")) //holy shit how did i not know about tags until now
        {
            Debug.Log("end me");
            Destroy(col.gameObject);
            //col.gO = the collided object is destroyed instead of the player
        }
       
    }
    void OnCollisionEnter2D(Collision2D plswork)
        //Collider2D = Trigger; Collision2D = Collision
    {
        //access comparetag() from gameobject only???
        //".tag" instead of "CompareTag" IDFK WHY BUT IT FINALLY WORKS
        if (plswork.gameObject.tag == "Enemy")
        {
            GameControl.instance.Death();
            canMove = false;
        }
        Debug.Log("iwanttodie");
        
    }
}