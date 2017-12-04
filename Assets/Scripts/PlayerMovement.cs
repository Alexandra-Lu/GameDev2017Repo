using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour {

  
    // Use this for initialization
    public float MaxSpeed = 0f;
    public float SpeedForce = 10f;

    public GameObject CollectibleThing;
    public GameObject collidingobject;
    public GameObject player;
   
    private bool canMove = true;

    public bool gameOver = false;
    public GameObject GameOver;

    //  bool collectiblecol = false;

    bool holdingobject = false; //For picking up only ONE item
    bool colliding;

    Animator anim;

    public AudioSource pickup;
    public AudioSource drop;
    public AudioSource meow;


    void Start()
    {
        anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            if (canMove == true)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    GetComponent<Rigidbody2D>().AddForce(transform.right * SpeedForce);
                    anim.SetInteger("State", 1);
                }
                else if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    MaxSpeed = 0;
                    anim.SetInteger("State", 0);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    GetComponent<Rigidbody2D>().AddForce(-transform.right * SpeedForce);
                    anim.SetInteger("State", 2);
                }
                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    MaxSpeed = 0;
                    anim.SetInteger("State", 0);
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    GetComponent<Rigidbody2D>().AddForce(transform.up * SpeedForce);
                    anim.SetInteger("State", 3);
                }
                else if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    MaxSpeed = 0;
                    anim.SetInteger("State", 0);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    GetComponent<Rigidbody2D>().AddForce(-transform.up * SpeedForce);
                    anim.SetInteger("State", 4);
                }
                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    MaxSpeed = 0;
                    anim.SetInteger("State", 0);
                }
            }
        }

        //score.text = "Score:  " + scoreValue;

        if (holdingobject == true)
        { SpeedForce = 7; ; }
        if (holdingobject == false)
        { SpeedForce = 10; }

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
            if (CollectibleThing != null)
            {
                CollectibleThing.transform.parent = null;
                holdingobject = false;

                meow.Play();
            }
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

            pickup.Play();
        } 

    }


    void DropItem()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && holdingobject) {
            Debug.Log("catscatscats");
            CollectibleThing.transform.parent = null;
            holdingobject = false;

            drop.Play();
        }


    }

 //SetTuningvalue(SettingsObject.)
    void OnCollisionEnter2D(Collision2D plswork)
        //Collider2D = Trigger; Collision2D = Collision
    {
        //access comparetag() from gameobject only???
        //".tag" instead of "CompareTag" IDFK WHY BUT IT FINALLY WORKS

        //Halt movement when colliding with an enemy
        if (plswork.gameObject.tag == "Enemy")
        {
            GameControl.instance.Death();
            gameOver = true;  //KILL ME PLS
            GameOver.SetActive(true);
            canMove = false;
           // GetComponent("FollowPath").enabled = false;
        }
        Debug.Log("iwanttodie");
        
    }
}