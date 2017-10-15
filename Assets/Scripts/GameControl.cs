using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public bool gameOver = false;
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;

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
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void Collected()
    {
        if (gameOver)
        { return; }

        score++;
        scoreText.text = "Score:" + score.ToString();
    }
}
