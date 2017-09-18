using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // public float Speed = 10;
    //public float MaxSpeed = 10;
    //public float Acceleration = 10;
    //public float Deceleration = 10;
    // Use this for initialization
    public float Speed = 0f;
    public float SpeedForce = 10f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        { GetComponent<Rigidbody2D>().AddForce(transform.right * SpeedForce); }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        { Speed = 0; }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        { GetComponent<Rigidbody2D>().AddForce(-transform.right * SpeedForce); }

        if (Input.GetKey(KeyCode.UpArrow))
        { GetComponent<Rigidbody2D>().AddForce(transform.up * SpeedForce); }

        if (Input.GetKey(KeyCode.DownArrow))
        { GetComponent<Rigidbody2D>().AddForce(-transform.up * SpeedForce); }

      
    }
    }