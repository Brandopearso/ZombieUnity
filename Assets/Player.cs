using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int _health;
	public int _score;

	// Use this for initialization
	void Start () {
		_health = 5;
		_score = 0;
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
				
			if (hitObject.GetComponent<PurchaseGunController> () != null) {
				if (hit.distance < 5.0f) {
					if (!GameObject.Find ("AKMessage")) {
						GameObject UI = GameObject.Find ("UI");
						GameObject AKmessage = new GameObject ();
						AKmessage.name = "AKMessage";
						//Instantiate (AKmessage);
						AKmessage.transform.parent = UI.transform;
						TextMesh messageTextMesh = AKmessage.AddComponent<TextMesh> () as TextMesh;
						messageTextMesh.text = "";
						messageTextMesh.characterSize = 0.1f;
						messageTextMesh.alignment = TextAlignment.Left;
						messageTextMesh.transform.position = new Vector3 (UI.transform.position.x, UI.transform.position.y - 0.2f, UI.transform.position.z);
						messageTextMesh.transform.rotation = UI.transform.rotation;

						if (_score < 100) {
							messageTextMesh.text = "cant buy";
						} else {
							messageTextMesh.text = "buy now";
						}
					}
					if (Input.GetKeyDown (KeyCode.Q) && _score > 100) {
						hitObject.GetComponent<PurchaseGunController> ().givePlayerGun ();
						_score -= 100;
					} else {

					}
				}
			} else {

				if (GameObject.Find ("AKMessage")) {

					Destroy (GameObject.Find ("AKMessage"));
				}
			}
		}
	}

//	public void Hurt(int damage) {
//		_health -= damage;
//		//Debug.Log ("Health: " + _health);
//	}
}
