using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }

    public MovementType Type = MovementType.MoveTowards;
    public MovementPath MyPath;
    public float Speed = 1;
    public float MaxDistanceToGoal = .1f;
    private IEnumerator<Transform> pointInPath;
    private bool canMove = true;
    // Use this for initialization
    void Start()
    {
        if (canMove == true)
        {
            if (MyPath == null)
            {
                
                return;
            }
            //if the object is moving/hasn't collided with anything, pull the next point from the array
            pointInPath = MyPath.GetNextPathPoint();
            pointInPath.MoveNext();

            if (pointInPath.Current == null)
            {
               
                return;
            }
            transform.position = pointInPath.Current.position;
        }

    }
        // Update is called once per frame
        void Update () {
		if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }
        //moves an object between points based on distance
        if (Type == MovementType.MoveTowards)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                pointInPath.Current.position,
                Time.deltaTime * Speed);
        }
        //moves an object between points gradually/ based on a percentage
        else if (Type == MovementType.LerpTowards)
        {
            transform.position = Vector3.Lerp(transform.position,
                pointInPath.Current.position,
                Time.deltaTime * Speed);
        }
        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
        {
            pointInPath.MoveNext();
        }
	}
    //I don't remember why I put this in here
    void OnCollisionEnter2D(Collision2D plswork)
   
    {
       
            canMove = false;

    }
}
