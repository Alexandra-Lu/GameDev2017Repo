using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I super need to fix this.
public class CameraMovement : MonoBehaviour {
    GameObject playerObj;
	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerObj.transform.position;
	}
}
