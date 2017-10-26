using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float speed = 4.0f;
	public int damage = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	// called automatically when this gameobject hits another gameobject
//	void OnTriggerEnter(Collider other) {
//		Player player = other.GetComponent<Player> ();
//		if (player != null) {
//			player.Hurt (damage);
//		}
//		Destroy (this.gameObject);
//	}
}
