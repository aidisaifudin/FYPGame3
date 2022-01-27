using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour {
	// Player Transform
	protected Transform playerTransform;
	
	// Next destination position of NPC Tank
	protected Vector3 destPos;
	
	// List of points for patrolling
	protected GameObject[] pointList;
	
	// Bullet shooting rate
	protected float shootRate;
	protected float elapsedTime;
	
	// Tank turret
	public Transform turret {get; set;}
	public Transform bulletSpawnPoint {get; set;}
	
	protected virtual void Initialize() {}
	protected virtual void FSMUpdate() {}
	protected virtual void FSMFixedUpdate() {}
	
	// Initialization
	void Start () {
		Initialize();
	}
	
	void Update() {
		FSMUpdate();
	}
	
	void FixedUpdate() {
		FSMFixedUpdate();
	}
}