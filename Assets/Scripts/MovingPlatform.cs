using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeReference]
    private GameObject[] waypoints;

    private int currentWaypointIndex = 0;

    [SerializeReference]
    private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        // When the distance of the platform is less than .1 of the waypoint, move to the next waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;

            // Return to the first waypoint when the last in the array is reached
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

        }
        
        // Move towards the next waypoint in the array
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);

    }
}
