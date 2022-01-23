using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	// Waypoint
	public Waypoints wayPoint;

	// Rocket launcher
	//private RocketLauncher rocketLauncher;

	// Get player
	public Transform player;

	// Animation parameters
	public Animation _animation;
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip shotAnimation;
	public float walkAnimationSpeed = 1.5f;
	public float idleAnimationSpeed = 1.0f;
	public float runAnimationSpeed = 2.0f;
	public float shotAnimationSpeed = 0.5f;

	// Character movement speed
	public int runSpeed = 6;
	public int walkSpeed = 2;
	public float jumpSpeed = 12.0f;
	public float gravity = 20.0f;

	// Shoot range
	public float shootRange = 15.0f;

	// Detected the player - increase from the shot range
	public float getPlayerRange = 10.0f;

	// Maximum distance from waypoint
	public float waypointDistance = 10.0f;

	// Make the enemy walk for 4 secs before changing to think animation
	public float walkingTime = 4.0f;

	// Make the enemy stop for 2 secs before changing to walk animation
	public float thinkingTime = 2.0f;

	// AI current HP
	public float aiHP = 100;

	// AI max HP
	private float aiMaxHP;

	// Character controller
	private CharacterController controller;

	// Collision flag return from moving the character
	private CollisionFlags c_collisionFlags;

	// Move parameters
	private float f_verticalSpeed = 0.0f;
	private float f_moveSpeed = 0.0f;
	private Vector3 v3_moveDirection = Vector3.zero;

	// Boolean parameters
	private bool b_isRun;
	private bool b_isAiming;
	private bool b_isJumping;
	private bool b_isStop;

	// Shoot parameters
	private bool b_isPrepare = false;
	private bool b_isShot = false;

	// Rotate parameters
	private Quaternion q_currentRotation; //current rotation of the character
	private Quaternion q_rot; //Rotate to left or right direction
	private float f_rotateSpeed = 1.0f; //Smooth speed of rotation

	// Stop time counting
	private float f_lastTime = 0;

	float f_inAirTime;
	float f_inAirStartTime;
	Vector3 v3_movement;

	// Using Awake to set up parameters before Initialization
	public void Awake() {
		controller = GetComponent<CharacterController>();
		b_isRun = false;
		b_isAiming = false;
		b_isJumping = false;
		f_moveSpeed = walkSpeed;
		c_collisionFlags = CollisionFlags.CollidedBelow;
		f_moveSpeed = walkSpeed;
		// To make the character stop moving at the certain time
		f_lastTime = Time.time; // Tracking the time between each movement of the character
		b_isStop = false;
		aiMaxHP = aiHP;
	
		// Set up animation speed and wrapmode
		_animation[walkAnimation.name].speed = walkAnimationSpeed;
		_animation[walkAnimation.name].wrapMode = WrapMode.Loop;
		_animation[runAnimation.name].speed = runAnimationSpeed;
		_animation[runAnimation.name].wrapMode = WrapMode.Loop;
		_animation[idleAnimation.name].speed = idleAnimationSpeed;
		_animation[idleAnimation.name].wrapMode = WrapMode.Loop;
	}

	// Initalization
	public void Start() {
		transform.position = wayPoint.StartPosition();
	}

	// Checking if character hits the ground (collide below)
	public bool IsGrounded() {
		return (c_collisionFlags & CollisionFlags.CollidedBelow) != 0;
	}

	// Checking for collision if the rocket hits the player
	//public void OnCollisionEnter(Collision collision) {
	//	if(StaticVars.b_isGameOver == false) {
	//		if(collision.transform.tag == "Rocket") {
	//			Rocket rocket = collision.gameObject.GetComponent<Rocket>();
	//			float f_damage = rocket.GetDamage();
	//			aiHP -= f_damage;
	//			if(aiHP <= 0) {
	//				aiHP = 0;
	//			}
	//		}
	//	}
	//}

	// Get percentage of maximum HP with the current HP
	public float GetHpPercent() {
		return aiHP/aiMaxHP;
	}

	// Give the enemy characteristic
	// Checking if character is shooting
	public bool Shoot(Vector3 _direction) {
		RaycastHit hit;
		// Checking if player falls within shooting range
		if(Vector3.Distance(transform.position, player.position) <= shootRange) {
			// Cast ray shootRange meters in shot direction, to see if nothing block the rocket
			if(Physics.Raycast(transform.position, _direction, out hit, shootRange)) {
	    		if(hit.transform.tag != "Obstacle") {
	    			b_isAiming = true;
	    			return b_isAiming;
				}
			}
		}
		b_isAiming = false;
		return b_isAiming;
	}

	// Make character jump
	public bool Jump(Vector3 _direction) {
		//Checking for jumping if next y position is different from current y position
		RaycastHit hit;
		Vector3 p1 = transform.position + controller.center + Vector3.up * (-controller.height * 0.5f);
		Vector3 p2 = p1 + Vector3.up * controller.height;
		// Cast ray to check if it hits anything
		if((Physics.CapsuleCast(p1, p2, 0.1f, _direction, out hit)) && (c_collisionFlags & CollisionFlags.Sides) != 0) {
    		if(hit.transform.tag == "Obstacle") {
        		return true;
			}
		}
		return false;
	}

	// Make enemy run when the player falls within certain radius which is between shootRange and getPlayerRange
	public bool Run() {
		// Checking for running
		if((Vector3.Distance(transform.position, player.position) <= (getPlayerRange + shootRange)) && ((Vector3.Distance(transform.position, player.position) > shootRange))) {
			b_isRun = true;
		} else {
			b_isRun = false;
		}
		return b_isRun;
	}

	// Calculate time to let enemy walk and think for certain time
	public bool IsThinking() {
		float f_time;
		// Get time when enemy stop walking
		if (b_isStop) {
			f_time = thinkingTime;
		} else {
			// Get time when enemy is walking
			f_time = walkingTime;
		}
		if(Time.time >= (f_lastTime + f_time)) {
			if(b_isStop) {
				b_isStop = false;
			} else {
				b_isStop = true;
			}
			f_lastTime = Time.time;
		}	
		return b_isStop;
	}

public void Update() {
	if(StaticVars.b_isGameOver == false) {
		Vector3 v3_rocketDirection = (player.position - transform.position).normalized;
		// Check if enemy position is away from waypoint in certain range
		// Make enemy stop running, shooting and walk back to the target waypoint
		if(wayPoint.AwayFromWaypoint(transform, waypointDistance)) {
			b_isAiming = false;
			b_isRun = false;
		} else {
			// Check if enemy is not aiming and check for running
			if(!Shoot(v3_rocketDirection)) {
				Run();
			}
		}
		if(!b_isAiming) {
			// If AI is running, make it stop thinking
			// Obtain direction to player
			Vector3 v3_targetDirection;
			if(b_isRun) {
				v3_targetDirection = wayPoint.GetDirectionToPlayer(transform, player); // Move towards player
			} else {
				if(thinkingTime > 0) {
					if(!IsThinking()) {
						v3_targetDirection = wayPoint.GetDirection(transform); // Use random direction
					} else {
						v3_targetDirection = Vector3.zero;
					}
				} else {
					v3_targetDirection = wayPoint.GetDirection(transform); // Use random direction
				}
			}
			
			if(v3_targetDirection != Vector3.zero) { // If target direction is not zero, rotate toward target direction
					v3_moveDirection = Vector3.Slerp(v3_moveDirection, v3_targetDirection, f_rotateSpeed * Time.deltaTime);
				// Get only direction by normalizing target vector
				v3_moveDirection = v3_moveDirection.normalized;
			} else {
				v3_moveDirection = Vector3.zero;
			}
			
			// Checking if character is on the ground
			if(!b_isJumping) {
				// Holding right shift button to run
				if(b_isRun) {
					f_moveSpeed = runSpeed;
				} else {
					b_isRun = false;
					f_moveSpeed = walkSpeed;
				}  
		        // Press Space to jump
		        if(Jump(v3_moveDirection)) {
		      	  	b_isJumping = true;
		            f_verticalSpeed = jumpSpeed;
		        }
			}

			// Apply gravity
			if(IsGrounded()) {
				f_verticalSpeed = 0.0f; // If character is grounded
				b_isJumping = false; // Checking if character is in the air
				f_inAirTime = 0.0f;
				f_inAirStartTime = Time.time;
			} else {
				f_verticalSpeed -= gravity* Time.deltaTime; // If character is in the air, count time
				f_inAirTime = Time.time - f_inAirStartTime;
			}
			
			// Calculate actual motion
			Vector3 v3_movement = (v3_moveDirection* f_moveSpeed) + new Vector3(0, f_verticalSpeed, 0); // Apply the vertical speed if character fall down
			v3_movement *= Time.deltaTime;
			
			// Set prepared animation to false
			b_isPrepare = false;
			
			// Check if character is moving or not
			if(v3_moveDirection != Vector3.zero) {
				if(f_moveSpeed == walkSpeed) {
					_animation.CrossFade(walkAnimation.name);
				} else {
					_animation.CrossFade(runAnimation.name);
				}
			} else {
				_animation.CrossFade(idleAnimation.name);
			}
			// Move the controller
	   		c_collisionFlags = controller.Move(v3_movement);
	   		
	   		// Update rotation of character
		    if((v3_moveDirection != Vector3.zero) && (!b_isAiming)) {
		    	transform.rotation = Quaternion.LookRotation(v3_moveDirection);
		    }

		} else { // Aiming
	   		v3_moveDirection = Vector3.MoveTowards(v3_moveDirection, v3_rocketDirection, 0.1f);
	   		v3_moveDirection = v3_moveDirection.normalized;
	   		
	   		// Apply gravity
			if(IsGrounded()) {
				f_verticalSpeed = 0.0f; // If character is grounded
				b_isJumping = false; //Checking if character is in the air or not
				f_inAirTime = 0.0f;
				f_inAirStartTime = Time.time;
			} else {
				f_verticalSpeed -= gravity* Time.deltaTime; // If character is in the air
															// Count Time
				f_inAirTime = Time.time - f_inAirStartTime;
			}
			
			// Calculate actual motion
			v3_movement = new Vector3(0, f_verticalSpeed, 0); // Apply the vertical speed if character falls down
			v3_movement *= Time.deltaTime;
			
			// Checking if the character is playing the shoot animation
			if(!b_isPrepare) {
				b_isShot = false;
				// Play the shoot preparing animation function
				StartCoroutine(WaitForPrepare());
			} else {
				if(v3_rocketDirection == v3_moveDirection) {
					if(!b_isShot) {
						b_isShot = true;
						// Play shot animation function
						StartCoroutine(WaitForShot());
					}
				}
			}
			
			// Move controller
	   		c_collisionFlags = controller.Move(new Vector3(0, v3_movement.y, 0));
	   		// Update character rotation
		    transform.rotation = Quaternion.LookRotation(v3_moveDirection);
		}
	} else {
		// Game over
		_animation.CrossFade(idleAnimation.name);
	}
}

	// Wait for shoot animation
	private IEnumerator WaitForShot() {
		_animation[shotAnimation.name].speed = shotAnimationSpeed;
		_animation[shotAnimation.name].wrapMode = WrapMode.ClampForever;
		_animation.PlayQueued(shotAnimation.name, QueueMode.PlayNow);
		BroadcastMessage("Fire", shotAnimation.length); // Enable all function name Fire in every script

		yield return new WaitForSeconds(shotAnimation.length);
		b_isShot = false;
	}

	// Wait for aiming animation
	private IEnumerator WaitForPrepare() {
		_animation[shotAnimation.name].speed = shotAnimationSpeed* 2;
		_animation[shotAnimation.name].wrapMode = WrapMode.ClampForever;
		_animation.CrossFade(shotAnimation.name, 0.6f);
	
		yield return new WaitForSeconds(shotAnimation.length);
		b_isPrepare = true;
	}

	// Draw gizmos and directional line between enemy and player position
	public void OnDrawGizmos() {
		if(player != null) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, player.position);
		}
	}

	// Calculate distance between player and enemy
	public float DistanceTracking() {
		float distance = Vector3.Distance(transform.position, player.position);
		return distance;
	}
}