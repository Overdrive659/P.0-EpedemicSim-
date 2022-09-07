using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;

    [Range(0f,5f)]
    public float width = 1f;

    public Vector2 getPosition()
    {
        Vector2 minBound = transform.position + transform.right * width / 2f;
        Vector2 maxBound = transform.position - transform.right * width / 2f;

        return Vector2.Lerp(minBound, maxBound, Random.Range(0f,1f));
    }

    

}
