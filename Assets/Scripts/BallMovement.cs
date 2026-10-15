using UnityEngine;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour
{
    public Transform cam;
    float speed = 4f;
    public bool isMove = false;
    public List<Transform> waypoints = new List<Transform>();
    int currentWaypoint = 0;

    void Update()
    {
        if (isMove)
        {
            Vector3 camBall = cam.transform.InverseTransformPoint(transform.position);
            Vector3 camWaypoint = cam.transform.InverseTransformPoint(waypoints[currentWaypoint].position);
            camBall.z = 1;
            Vector3 targetWaypint = new Vector3(camWaypoint.x, camWaypoint.y, 1);
            camBall = Vector3.MoveTowards(camBall, targetWaypint, speed * Time.deltaTime);
            
            transform.position = cam.transform.TransformPoint(camBall);
            if (Vector2.Distance( new Vector2(camBall.x, camBall.y), new Vector2(camWaypoint.x, camWaypoint.y)) < 0.05f)
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
