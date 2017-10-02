using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public bool gameOver = false;
    public static GameControl instance;
    
	// Use this for initialization

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Death()
    {
        gameOver = true;
    }
}
