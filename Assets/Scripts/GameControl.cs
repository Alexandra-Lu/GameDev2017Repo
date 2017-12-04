using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public bool gameOver = false;
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public GameObject winText;
    public AudioSource purr;

    

    private int score = 0;
    
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
        //Activates gameover text...but that's kind of obvious
       gameOverText.SetActive(true);
        gameOver = true;
    }

    public void Scored()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        //Activates the "win screen" that isn't actually a screen
        if (score == 6) 
        {
            winText.SetActive(true);
            purr.Play();
        }
    }
    public void Collected()
    {
        if (gameOver)
        { return; }

        
    }
}
