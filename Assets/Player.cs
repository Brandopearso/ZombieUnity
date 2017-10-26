using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int _health;

	// Use this for initialization
	void Start () {
		_health = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = new Ray (this.transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {

			GameObject hitObject = hit.transform.gameObject;
			GateDoor gateDoor = hitObject.GetComponent<GateDoor> ();
			if (gateDoor != null) {
				if (hit.distance < 5.0f && Input.GetKeyDown (KeyCode.E)) {

					GateController.addGateToSet (gateDoor.gateNum);
				}
			}
		}
	}

//	public void Hurt(int damage) {
//		_health -= damage;
//		//Debug.Log ("Health: " + _health);
//	}
}
