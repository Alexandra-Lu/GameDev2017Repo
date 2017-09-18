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

        if (transform.position.x >= 0.5f)
        {
            dirRight = false;
        //    mySpriteRenderer.flipX = true;
        }

        if (transform.position.x <= -6)
        {
            dirRight = true;
           // mySpriteRenderer.flipX = false;
        }
    }
}
