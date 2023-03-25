using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;               // The array of waypoints to follow
    public float moveSpeed = 5.0f;              // The movement speed of the AI
    public float rotationSpeed = 2.0f;          // The rotation speed of the AI
    public float waypointThreshold = 1.0f;      // The distance threshold for considering a waypoint as reached

    private int currentWaypointIndex = 0;       // The index of the current waypoint
    private bool isAtWaypoint = false;          // Flag to check if the AI is at the current waypoint


    public NavMeshAgent agent;

    void Update()
    {
        // Check if the AI is at the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointThreshold)
        {
            isAtWaypoint = true;

            // If the AI has reached the last waypoint, set the index to 0 to loop through the array
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                currentWaypointIndex = 0;
            }
            // Otherwise, increment the waypoint index
            else
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            isAtWaypoint = false;
        }

        // If the AI is not at the current waypoint, move towards it
        if (!isAtWaypoint)
        {
            //Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
            //targetDirection.y = 0.0f;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotationSpeed * Time.deltaTime);
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
