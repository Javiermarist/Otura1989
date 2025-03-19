using UnityEngine;
using System.Collections.Generic;

public class DetectionRun : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float speed = 3f;
    public List<Transform> waypoints;
    public Animator animator;
    private Transform player;
    private int currentWaypointIndex = 0;
    private bool isFollowing = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            isFollowing = true;
            animator.SetTrigger("Run");
        }
        else
        {
            isFollowing = false;
            animator.ResetTrigger("Run");
        }

        if (isFollowing && waypoints.Count > 0)
        {
            FollowWaypoints();
        }
    }

    void FollowWaypoints()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1f)
        {
            if (currentWaypointIndex == waypoints.Count - 1)
            {
                animator.ResetTrigger("Run");
                animator.SetTrigger("Terrified");
                isFollowing = false;
                return;
            }
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        if (isFollowing)
        {
            Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(waypoints[currentWaypointIndex].position);
        }
    }
}