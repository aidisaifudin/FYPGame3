using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
	// Name of icon image
	public string iconName = "wayIcon.psd";

	// Radius of each way point - use for checking collision detection with enemy
	public float radius = 1.0f;

	// Toggle this to make enemy move by order from the first index to last index (looping)
	public bool orderDirection = false;

	// Get all transfrom of waypoint including the parent
	private Transform[] waypoints;

	// Current waypoint index
	private int wayIndex;

	// Next waypoint index
	private int nextIndex;

	// Length of all waypoints
	private int wayLength;

	// Movement direction of enemy to next waypoint
	private Vector3 direction;

	// Checking if enemy hit waypoint
	private bool isHitRadius;

	// Set up all parameters before initailize
	void Awake() {
	// Obtain all transforms of gameObject including its children
	waypoints = gameObject.GetComponentsInChildren<Transform>();
	// Set up the length of all transform
	wayLength = waypoints.Length;
	wayIndex = 0;
	nextIndex = 1;
	// Check order direction
	// False means AI not moving by order - using random index of waypoint
	if(orderDirection == false) {
		int randomWay = (int)Mathf.Floor(Random.value * wayLength); // Randomly returns a number between 0.0 and 1.0 (inclusive of both)
		// Check that waypoint length is more than 1
		if (wayLength > 1) {
			// Use random Index
			while (wayIndex == randomWay) {
				randomWay = (int)Mathf.Floor(Random.value * wayLength);
			}
		}
		nextIndex = randomWay;
	}
	// Set direction to zero
	direction = Vector3.zero;
	// Ignore first waypoint at the beginning
	isHitRadius = true;
}

	public Vector3 StartPosition() {
		return waypoints[0].position;
	}

	// Return direction of enemy towards next waypoint
	public Vector3 GetDirection(Transform AI) {
		if (Vector3.Distance(AI.position, waypoints[nextIndex].position) <= radius) {
			// Only check once when the AI hit the waypoint
			if (!isHitRadius) {
				isHitRadius = true;
				// Update current waypoint index
				wayIndex = nextIndex;
				// Get direction by order
				if (orderDirection == true) {
					// Get the next way index
					nextIndex = (nextIndex + 1) % wayLength;
				} else {
					int randomWay = (int)Mathf.Floor(Random.value * wayLength);
	    			// Checking to make sure that waypoint length is more than 1
					if (wayLength > 1) {
						// Use random index
						while (wayIndex == randomWay) {
							randomWay = (int)Mathf.Floor(Random.value * wayLength);
						}
					}
					nextIndex = randomWay;
	    		}
			}
		} else {
			isHitRadius = false;
		}

		// Get direction from current position of character to the next way point
		// Make sure that y position equal to the waypoint y position
		Vector3 currentPosition = new Vector3(AI.position.x, waypoints[nextIndex].position.y, AI.position.z);
		direction = (waypoints[nextIndex].position - currentPosition).normalized;
		return direction;
	}

	// Get direction from current position of enemy to player
	public Vector3 GetDirectionToPlayer(Transform AI, Transform player) {
		// Make sure that y position equal to waypoint y position
		Vector3 currentPosition = new Vector3(AI.position.x, waypoints[wayIndex].position.y, AI.position.z);
	Vector3 playerPosition = new Vector3(player.position.x, waypoints[wayIndex].position.y, player.position.z);
	direction = (playerPosition - currentPosition).normalized;
		return direction;
	}

	// Check if enemy is away from target waypoint of specific distance
	public bool AwayFromWaypoint(Transform AI, float _distance) {
		if (Vector3.Distance(AI.position, waypoints[nextIndex].position) >= _distance) {
			return true;
		} else {
			return false;
		}
	}

	// Draw gizmos and directional line
	public void OnDrawGizmos() {
		// Get all transform of game object including its children
		Transform[] waypointGizmos = gameObject.GetComponentsInChildren<Transform>();
		if (waypointGizmos != null) {
			if (orderDirection == true) {
				// Draw line by order of each waypoint 0,1,2,3,...
				for (int i = 0; i<waypointGizmos.Length; i++) {
					Gizmos.color = Color.red;
					// Get next waypoint
					int n = (i + 1) % waypointGizmos.Length;
					Gizmos.DrawLine(waypointGizmos[i].position, waypointGizmos[n].position);
					Gizmos.DrawIcon(waypointGizmos[i].position, iconName);
					Gizmos.color = Color.green;
					Gizmos.DrawWireSphere(waypointGizmos[i].position, radius);
				}
			} else {
				// Draw line from one point to every other points except itself
				for (int j = 0; j<waypointGizmos.Length; j++) {
					for (int k = j; k<waypointGizmos.Length; k++) {
						Gizmos.color = Color.red;
						Gizmos.DrawLine(waypointGizmos[j].position, waypointGizmos[k].position);
					}
					Gizmos.DrawIcon(waypointGizmos[j].position, iconName);
					Gizmos.color = Color.green;
					Gizmos.DrawWireSphere(waypointGizmos[j].position, radius);
				}
			}
		}
	}
}