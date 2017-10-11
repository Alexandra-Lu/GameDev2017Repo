using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown("space"))
        {
            // GameControl.instance.Collected();
            Debug.Log("plsworkplsplspls");
        }
    }
}
