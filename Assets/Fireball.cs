using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed = 4.0f;
	public int damage = 1;
	Vector3 startpos;

	// Use this for initialization
	void Start () {


		//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
			
//		if (Vector3.Distance (startpos, transform.position) > 20.0f) {
//			Destroy (this.gameObject);
//		}
	}

	// called automatically when this gameobject hits another gameobject
	void OnTriggerEnter(Collider other) {
//		WanderingAI player = other.GetComponent<WanderingAI> ();
//		if (player != null) {
//			print ("NONONONON");
//		}
		Destroy (this.gameObject);
	}

//	private IEnumerator EndLifetime() {
//
//		yield return new WaitForSeconds (0.5f);
//		Destroy (this.gameObject);
//	}
}
