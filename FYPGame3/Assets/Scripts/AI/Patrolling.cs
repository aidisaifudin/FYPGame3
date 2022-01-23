using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{

    public GameObject[] waypoints;

    [SerializeField]
    private NavMeshAgent agent;

    private int currentWaypoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; // auto brake, up to us to change
        
        currentWaypoint = 0; //first index to start

        agent.destination = waypoints[currentWaypoint].transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) <=2f)
        {
            Iterate();
        }
    }

    void Iterate()
    {
        if (currentWaypoint < waypoints.Length - 1)  // 1234 but our list is 0123 , compare to our list of waypoints
        {
            currentWaypoint++;
        }
        
        else
        {
            currentWaypoint = 0;
        }

        agent.destination = waypoints[currentWaypoint].transform.position;
    }
}
