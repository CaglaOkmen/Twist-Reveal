using UnityEngine;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour
{
    float speed = 4f;
    public bool isMove = false;
    public List<Transform> waypoints = new List<Transform>();
    int currentWaypoint = 0;

    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.05f)
            {
                transform.position = waypoints[currentWaypoint].position;
                currentWaypoint += 1;
            }
            if (waypoints.Count <= currentWaypoint)
            {
                Debug.Log("Kazandin.");
                this.enabled = false;
            }
        }
    }
}
