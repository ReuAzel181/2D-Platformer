using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMov : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] private float speed = 2f;
    private int currentWaypointindex = 0;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointindex].transform.position, transform.position) < .1f)
        {
            currentWaypointindex++;
            if (currentWaypointindex >= waypoints.Length)
            {
                currentWaypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointindex].transform.position, Time.deltaTime * speed);
    }
}
