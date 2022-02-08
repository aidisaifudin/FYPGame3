using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
	public Waypoints wayPoints;
	public Animator animator; // Animator controller for animation parameter trigger
	public int walkSpeed; // Character movement speed
	public float waypointDistance; // Maximum distance from waypoint
	public float walkingTime; // Make the enemy walk for a period of time before changing to think animation
	public float idleTime; // Make the enemy idle for a period of time before changing to walk animation
	public float rotateSpeed;
	CharacterController controller;
	CollisionFlags collisionFlags; // Collision flag return from moving the character
	float moveSpeed = 0.0f;
	Vector3 moveDirection;
	bool hasStop;
	Vector3 targetDirection = Vector3.zero;
	float lastTiming = 0; // Stop time counting
	Vector3 movement;

	public void Awake() {
		controller = GetComponent<CharacterController>();
		moveSpeed = walkSpeed;
		lastTiming = Time.time; // Tracking the time between each movement of character
		hasStop = false;
	}

	public void Start() {
		transform.position = wayPoints.StartPosition();
	}

	// Calculate time to let enemy walk and think for certain duration
	public bool IsIdle() {
		float duration;

		// Get time when AI is idling
		if(hasStop) {
			duration = idleTime;
		} else {
			// Get time when AI is walking
			duration = walkingTime;
		}

		if(Time.time >= lastTiming + duration) {
			if(hasStop) {
				hasStop = false;
			} else {
				hasStop = true;
			}

			lastTiming = Time.time;
		}

		return hasStop;
	}

	public void Update() {
		targetDirection = wayPoints.GetDirection(transform);

		if(IsIdle()) { // Idling
			moveDirection = Vector3.zero; // Stop character movement
			transform.rotation = Quaternion.LookRotation(targetDirection);
			animator.SetTrigger("Idle");
		} else { // Walking
			moveDirection = Vector3.Slerp(moveDirection, targetDirection, rotateSpeed * Time.deltaTime).normalized;
			transform.rotation = Quaternion.LookRotation(moveDirection);
			animator.SetTrigger("Walk");
		}

        // Calculate actual motion
        movement = moveDirection * moveSpeed;
        movement *= Time.deltaTime;

        // Move character controller
        collisionFlags = controller.Move(movement);
    }
}