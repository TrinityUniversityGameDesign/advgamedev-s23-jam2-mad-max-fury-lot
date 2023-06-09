using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;               // The array of waypoints to follow
    //public float moveSpeed = 5.0f;              // The movement speed of the AI
    //public float rotationSpeed = 2.0f;          // The rotation speed of the AI
    public float waypointThreshold = 5.0f;      // The distance threshold for considering a waypoint as reached

    private int currentWaypointIndex = 0;       // The index of the current waypoint
    private bool isAtWaypoint = false;          // Flag to check if the AI is at the current waypoint


    private bool parked = false;
    public NavMeshAgent agent;

    private void Start()
    {
        moveCarsPlease();
        //agent.SetDestination(GameObject.Find("FINISH LINE Variant").transform.position);
    }

    void Update()
    {

        // Check if the AI is at the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointThreshold)
        {
            isAtWaypoint = true;

            // If the AI has reached the last waypoint, set the index to 0 to loop through the array
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                currentWaypointIndex = waypoints.Length - 1;
                parked = true;
                //currentWaypointIndex = 0;
            }
            // Otherwise, increment the waypoint index
            else
            {
                currentWaypointIndex++;
                moveCarsPlease(); 
            }
        }
        else
        {
            isAtWaypoint = false;
        }

        
    }


    // If the AI is not at the current waypoint, move towards it
    private void moveCarsPlease()
    {
        
        Debug.Log("currentWaypointIndex" + currentWaypointIndex);
        Debug.Log("position to go to " + waypoints[currentWaypointIndex].position);

        agent.SetDestination(waypoints[currentWaypointIndex].position);

        if (parked == true)
        {
            Debug.Log("won");
            transform.position = waypoints[currentWaypointIndex].position;
        }
    }
}
