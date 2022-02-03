using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
	public float radius = 1.0f; // Radius of each waypoint, use for checking collision detection with AI
	public bool orderDirection = false; // Toggle to make enemy move by order from the first index to last index (looping)
	Transform[] waypoints; // Get all transfrom of waypoint including parent
	int wayIndex; // Current waypoint index
	int nextIndex; // Next waypoint index
	int length; // Length of all waypoints
	Vector3 direction; // Movement direction of AI to next waypoint
	bool hasHitRadius; // Checking if enemy hit waypoint

	void Awake() {
		// Obtain all transforms of gameObject including its children
		waypoints = gameObject.GetComponentsInChildren<Transform>();

		// Set up the length of all transform
		length = waypoints.Length;
		wayIndex = 0;
		nextIndex = 1;
		// Check order direction, false means AI move by random waypoint index
		if(orderDirection == false) {
			int randomWay = (int)Mathf.Floor(Random.value * length); // Randomly returns a number between 0.0 and 1.0 (inclusive of both)
			// Check that waypoint length is more than 1
			if(length > 1) {
				while(wayIndex == randomWay) { // Use random Index
					randomWay = (int)Mathf.Floor(Random.value * length);
				}
			}

			nextIndex = randomWay;
		}

		// Set direction to zero
		direction = Vector3.zero;
		// Ignore first waypoint at the beginning
		hasHitRadius = true;
	}

	public Vector3 StartPosition() {
		return waypoints[0].position;
	}

	// Return direction of enemy towards next waypoint
	public Vector3 GetDirection(Transform AI) {
		if(Vector3.Distance(AI.position, waypoints[nextIndex].position) <= radius) {
			// Check only once when AI hit a waypoint
			if(!hasHitRadius) {
				hasHitRadius = true;
				// Update current waypoint index
				wayIndex = nextIndex;
				// Get direction by order
				if(orderDirection == true) {
					// Get the next way index
					nextIndex = (nextIndex + 1) % length;
				} else {
					int randomWay = (int)Mathf.Floor(Random.value * length);
	    			// Checking to make sure that waypoint length is more than 1
					if (length > 1) {
						// Use random index
						while (wayIndex == randomWay) {
							randomWay = (int)Mathf.Floor(Random.value * length);
						}
					}
					nextIndex = randomWay;
	    		}
			}
		} else {
			hasHitRadius = false;
		}

		// Get direction from current position of character to the next way point
		// Make sure that y position equal to the waypoint y position
		Vector3 currentPosition = new Vector3(AI.position.x, waypoints[nextIndex].position.y, AI.position.z);
		direction = (waypoints[nextIndex].position - currentPosition).normalized;

		return direction;
	}

	// Check if enemy is away from target waypoint of specific distance
	public bool AwayFromWaypoint(Transform AI, float distance) {
		if(Vector3.Distance(AI.position, waypoints[nextIndex].position) >= distance) {
			return true;
		} else {
			return false;
		}
	}

	// Draw gizmos and lines
	public void OnDrawGizmos() {
		// Get all transform of game object including its children
		Transform[] waypointGizmos = gameObject.GetComponentsInChildren<Transform>();
		if (waypointGizmos != null) {
			if (orderDirection == true) {
				// Draw line by order of each waypoint
				for(int i = 0; i<waypointGizmos.Length; i++) {
					Gizmos.color = Color.yellow;
					// Get next waypoint
					int n = (i + 1) % waypointGizmos.Length;
					Gizmos.DrawLine(waypointGizmos[i].position, waypointGizmos[n].position);
					//Gizmos.DrawIcon(waypointGizmos[i].position, iconName);
					Gizmos.color = Color.red;
					Gizmos.DrawWireSphere(waypointGizmos[i].position, radius);
				}
			} else {
				// Draw line from one point to every other points except itself
				for(int j = 0; j<waypointGizmos.Length; j++) {
					for(int k = j; k<waypointGizmos.Length; k++) {
						Gizmos.color = Color.yellow;
						Gizmos.DrawLine(waypointGizmos[j].position, waypointGizmos[k].position);
					}
					//Gizmos.DrawIcon(waypointGizmos[j].position, iconName);
					Gizmos.color = Color.red;
					Gizmos.DrawWireSphere(waypointGizmos[j].position, radius);
				}
			}
		}
	}
}