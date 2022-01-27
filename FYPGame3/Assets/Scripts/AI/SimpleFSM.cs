using UnityEngine;
using System.Collections;

public class SimpleFSM : FSM {
	public enum FSMState {None, Patrol}
	
	// Current state that NPC is having
	public FSMState curState;
	
	// Speed of the tank
	private float curSpeed;
	
	// Tank rotation speed
	private float curRotSpeed;
	
	// Projectile
	//public GameObject Bullet;
	
	// Check if NPC is destroyed
	//private bool bDead;
	//private int health;
	
	// Initialize finite state machine for NPC tank
	protected override void Initialize () {
		curState = FSMState.Patrol;
		curSpeed = 3.0f;
		curRotSpeed = 0.5f;
		//bDead = false;
		elapsedTime = 0.0f;
		//shootRate = 3.0f;
		//health = 100;
		
		// Get list of points
		pointList = GameObject.FindGameObjectsWithTag("WanderPoint");
		
		// Set random destination point first
		FindNextPoint();
		
		// Get target enemy player
		//GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		//playerTransform = objPlayer.transform;
		
		//if(!playerTransform)
		//	print("Player doesn't exist.. Please add one with Tag named 'Player'");
		
		// Get the turret of the tank
		//turret = gameObject.transform.GetChild(0).transform;
		//bulletSpawnPoint = turret.GetChild(0).transform;
	}
	
	// Update each frame
	protected override void FSMUpdate() {
		switch (curState) {
			case FSMState.Patrol: UpdatePatrolState(); break;
			//case FSMState.Chase: UpdateChaseState(); break;
			//case FSMState.Attack: UpdateAttackState(); break;
			//case FSMState.Dead: UpdateDeadState(); break;
		}
		
		// Update time
		elapsedTime += Time.deltaTime;
		
		// Go to dead state if health is depleted
		//if (health <= 0)
		//	curState = FSMState.Dead;
	}
	
	// Patrol state
	protected void UpdatePatrolState() {
		// Find another random patrol point if current point is reached
		if (Vector3.Distance(transform.position, destPos) <= 100.0f) {
			print("Reached destination point\nCalculating next point");
			FindNextPoint();
		}
  //      else if (Vector3.Distance(transform.position, playerTransform.position) <= 300.0f) { // Transit to chase state when distance is near
		//	print("Switch to chase state");
		//	curState = FSMState.Chase;
		//}
		
		// Rotate to target point
		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);  
		
		// Go forward
		transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	}
	
	//// Chase state
	////protected void UpdateChaseState() {
	////	// Set the target position as the player position
	////	destPos = playerTransform.position;
		
	////	// Check distance with player tank
	////	// When distance is near, transition to attack state
	////	float dist = Vector3.Distance(transform.position, playerTransform.position);
	////	if (dist <= 200.0f) {
	////		curState = FSMState.Attack;
	////	} else if (dist >= 300.0f) { // Go back to patrol state if player becomes too far
	////		curState = FSMState.Patrol;
	////	}
		
	//// Move forward
	//transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	//}
	
	//// Attack state
	////protected void UpdateAttackState() {
	////	// Set the target position as the player position
	////	destPos = playerTransform.position;
		
	////	// Check distance with player tank
	////	float dist = Vector3.Distance(transform.position, playerTransform.position);
	////	if (dist >= 200.0f && dist < 300.0f) {
	////		// Rotate to target point
	////		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
	////		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);  
			
	////		// Go forward
	////		transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
			
	////		curState = FSMState.Attack;
	////	} else if (dist >= 300.0f) { // Transition to patrol is the tank become too far
	////		curState = FSMState.Patrol;
	////	}        
		
	//	// Always turn turret towards the player
	//	Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
	//	turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed); 
		
	//	// Shoot projectiles
	//	ShootBullet();
	//}
	
	// Dead state
	//protected void UpdateDeadState() {
	//	// Show dead animation with some physics effects
	//	if (!bDead) {
	//		bDead = true;
	//		Explode();
	//	}
	//}
	
	// Shoot projectile from turret
	//private void ShootBullet() {
	//	if (elapsedTime >= shootRate) {
	//		//Shoot the bullet
	//		Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
	//		elapsedTime = 0.0f;
	//	}
	//}
	
	//// Check collision with projectile
	///// <param name = "collision"></param>
	//void OnCollisionEnter(Collision collision) {
	//	// Reduce health
	//	if(collision.gameObject.tag == "Bullet")
	//		health -= collision.gameObject.GetComponent<Projectile>().damage;
	//}
	
	// Find next semi-random patrol point
	protected void FindNextPoint() {
		print("Finding next point");
		int rndIndex = Random.Range(0, pointList.Length);
		float randomRadius = 5.0f;
		
		Vector3 rndPosition = Vector3.zero;
		destPos = pointList[rndIndex].transform.position + rndPosition;
		
		// Check range
		// Prevent having the random point being the same as before
		if(IsInCurrentRange(destPos)) {
			rndPosition = new Vector3(Random.Range(-randomRadius, randomRadius), 0.0f, Random.Range(-randomRadius, randomRadius));
			destPos = pointList[rndIndex].transform.position + rndPosition;
		}
	}
	
	// Check whether next random position is the same as current tank position
	/// <param name = "pos"> Position to check </param>
	protected bool IsInCurrentRange(Vector3 pos) {
		float xPos = Mathf.Abs(pos.x - transform.position.x);
		float zPos = Mathf.Abs(pos.z - transform.position.z);
		
		if (xPos <= 50 && zPos <= 50)
			return true;
		
		return false;
	}
	
	//protected void Explode() {
	//	float rndX = Random.Range(10.0f, 30.0f);
	//	float rndZ = Random.Range(10.0f, 30.0f);
	//	for (int i = 0; i < 3; i++) {
	//		GetComponent<Rigidbody>().AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
	//		GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
	//	}
		
	//	Destroy(gameObject, 3.0f);
	//}
}