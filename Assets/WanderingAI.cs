using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 1.0f;

	public int currentGate;

	// states 
	public bool _atGate;
	private bool _insideGate;

	// pathfinding
	private NavMeshAgent navComponent;
	public Transform target;
	public Vector3 gateTarget;

	public int spawnGate;

	public int _health;

	void Start () {
		_atGate = false;
		_insideGate = false;
		_health = 3;

		target = GameObject.FindGameObjectWithTag ("Player").transform;
		navComponent = this.gameObject.GetComponent<NavMeshAgent> ();

		if (spawnGate == 1) {
			Transform temp = GateController.getGateTransform (1);
			gateTarget = new Vector3 (temp.position.x, temp.position.y, temp.position.z - 0.5f);
		} else if (spawnGate == 2) {
			Transform temp = GateController.getGateTransform (2);
			gateTarget = new Vector3 (temp.position.x, temp.position.y, temp.position.z + 0.5f);
		}
		navComponent.autoBraking = true;
	}

	// Update is called once per frame
	void Update () {
		if (_health < 1) {
			Destroy (gameObject);
		}

		// Enemy is outside the gate, and trying to get in
		if (!_insideGate) {
			// just move towards the gate
			navComponent.SetDestination (gateTarget);
			Rigidbody r = gameObject.GetComponent<Rigidbody> ();
			r.isKinematic = false;
		}

		// Enemy is inside the gate, and needs to chase the player
		if (_insideGate) {

			if (target) {

				navComponent.SetDestination (target.position);
				Rigidbody r = gameObject.GetComponent<Rigidbody> ();
				r.isKinematic = true;
			}
		}

		if (GateController.getGateStack (1).Count == 0 && spawnGate == 1) {

			_atGate = false;
			_insideGate = true;
		}else if (GateController.getGateStack (2).Count == 0 && spawnGate == 2) {

			_atGate = false;
			_insideGate = true;
		}

		Ray ray = new Ray (this.transform.position, transform.forward);
		RaycastHit hit;
//		if(Physics.SphereCast(ray, 0.75f, out hit)) {
//
//			GameObject hitObject = hit.transform.gameObject;
//
//			if (hitObject.GetComponent<Player> ()) {
//				if (_fireball == null) {
//					_fireball = Instantiate (fireballPrefab) as GameObject;
//					_fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
//					_fireball.transform.rotation = transform.rotation;
//				}
//			}
//			if (hit.distance < obstacleRange && hitObject.GetComponent<wall>()) {
//				float angle = Random.Range(-110,110);
//				transform.Rotate(0, angle, 0);
//			}
//		}
	}

	// called automatically when this gameobject hits another gameobject
	void OnTriggerEnter(Collider other) {

		Gate gate = other.GetComponent<Gate> ();
		EnemyController enemyController = gameObject.GetComponent<EnemyController> ();
		if (gate != null && !_atGate) {

			_atGate = true;
			if (!GateController.tearingGate1 && spawnGate == 1) {

				GateController.tearingGate1 = true;
				int gateCount = GateController.getGateStack (gate.gateNum).Count;
				Animation animation = GetComponent<Animation> ();
				currentGate = gate.gateNum;

				animation.Play ("EnemyAnimation");
				while (gateCount > 0) {
					animation.PlayQueued ("EnemyAnimation", QueueMode.CompleteOthers);
					gateCount--;
				}	
			}else if(!GateController.tearingGate2 && spawnGate == 2) {
				GateController.tearingGate2 = true;
				int gateCount = GateController.getGateStack (gate.gateNum).Count;
				Animation animation = GetComponent<Animation> ();
				currentGate = gate.gateNum;

				animation.Play ("EnemyAnimation");
				while (gateCount > 0) {
					animation.PlayQueued ("EnemyAnimation", QueueMode.CompleteOthers);
					gateCount--;
				}	
			}
		}

		Fireball fireball = other.GetComponent<Fireball> ();
		if (fireball != null) {
			
			_health--;
		}
	}

	void OnTriggerExit(Collider other) {

		WanderingAI enemy = other.GetComponent<WanderingAI> ();
		if (enemy != null) {
			navComponent.enabled = true;
		}
	}

	void deleteGate() {

		if (GateController.deleteGateFromSet (currentGate)) {
			_insideGate = true;
		}
	}
}
