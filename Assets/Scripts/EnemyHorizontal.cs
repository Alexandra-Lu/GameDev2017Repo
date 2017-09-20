using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : MonoBehaviour {
    private bool dirRight = true;
    public float speed = 2.0f;
    private SpriteRenderer mySpriteRenderer;
    // Use this for initialization
    void Start () {
     //   mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 12f)
        {
            dirRight = false;
        //    mySpriteRenderer.flipX = true;
        }

        if (transform.position.x <= -2)
            //!!!!!All enemies under this script patrol the same x-coordinates regardless of where
            //!!!!!they are initially placed. This needs to be changed to a distance range so the same 
            //!!!!!enemy can be placed around the house without being drawn to the same 'column'
        {
            dirRight = true;
           // mySpriteRenderer.flipX = false;
        }
    }
}



//OTHER ENEMIES
// AAA One rotation enemy; single sight. spins gradually; bottom right corner
// BBB Enemy that patrols, stops to spin around, turns back and contines down the path
// CCC Every x seconds, a dog that is otherwise sleeping runs out and follows a specific path
//     around the house, audio cue of barking (any way to place specific points/coordinates?)