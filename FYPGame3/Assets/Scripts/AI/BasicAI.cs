using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BasicAI : MonoBehaviour
    {
        public NavMeshAgent agent;
       
        

        public enum State { PATROL}

        public State state;
        public bool alive;

        //Variable for Patrolling
        public GameObject[] waypoints;
        private int waypointIndex;
        public float patrolSpeed = 0.5f;



        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            waypoints = GameObject.FindGameObjectsWithTag("Waypoint"); //find waypoints tag
            waypointIndex = Random.Range(0, waypoints.Length); //random number between 0 and number of waypoints


            agent.updatePosition = true;
            agent.updateRotation = false;

            state = BasicAI.State.PATROL;

            alive = true;

            //Start FSM
            StartCoroutine("FSM"); 
        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch(state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointIndex].transform.position);
                

            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) <= 2)
            {
                waypointIndex = Random.Range(0, waypoints.Length);

            }
            else
            {
                
            }
               
        }


    }
}
