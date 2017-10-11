using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }
    public PathTypes PathType;
    public int movementDirection = 1;
    public int movingTo = 0;
    public Transform[] PathSequence;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrawGizmos()
    {
        //draws the line in the editor (and only the editor) to show the path between placed points
        if (PathSequence == null || PathSequence.Length < 2)
        { return; }
        for (var i = 1; i < PathSequence.Length; i++)
        {
            Gizmos.DrawLine(PathSequence[i - 1].position, PathSequence[i].position);
        }
        if (PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length - 1].position);
        }
    }
    
    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathSequence == null|| PathSequence.Length < 1)
        {
            yield break;
        }
        while(true)
        {
            //poppin through the arrayyy
            yield return PathSequence[movingTo];
            if(PathSequence.Length == 1)
            {
                continue;
            }
            //Linear paths for when they don't loop/connect back to each other
            //so the enemy would move from one end of the line to the other, and back
            if(PathType == PathTypes.linear)
            {
                if (movingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (movingTo >= PathSequence.Length - 1)
                {
                    movementDirection = -1;
                }
            }
            movingTo = movingTo + movementDirection;

            //Loop path is a loop
            //Like an enemy circling
            if(PathType == PathTypes.loop)
                if (movingTo >= PathSequence.Length)
                {
                    movingTo = 0;
                }
            if (movingTo <0)
            {
                movingTo = PathSequence.Length - 1;
            }
        }
    }
}