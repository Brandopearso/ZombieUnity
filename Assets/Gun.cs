using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	public Transform _camera;
	public Transform _muzzle;
	float timer;
	float fireRate = 0.2f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (Input.GetMouseButton (0) && timer > fireRate) {
			fire ();

		}
	}

	void fire() {
		_fireball = Instantiate (fireballPrefab) as GameObject;
		_fireball.transform.position = _muzzle.transform.position;
		_fireball.transform.rotation = _camera.transform.rotation;
		//_fireball.GetComponent<Rigidbody> ().AddForce (_camera.transform.TransformPoint(Vector3.forward * 9000.5f));
		timer = 0.0f;
	}
}
