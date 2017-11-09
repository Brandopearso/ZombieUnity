using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	[SerializeField] private GameObject gunPrefab;
	private GameObject _currentGun;

	[SerializeField] private GameObject AK47;

	public Transform _camera;
	public Transform _muzzle;
	float timer;
	float fireRate = 0.2f;
	bool isAutomatic;

	// Use this for initialization
	void Start () {
		_currentGun = Instantiate (gunPrefab) as GameObject;
		_currentGun.transform.parent = _camera.transform;
		_currentGun.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
		_currentGun.transform.Rotate (90.0f, 0.0f, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (isAutomatic) {
			if (Input.GetMouseButton (0) && timer > fireRate) {
				fire ();
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				fire ();
			}
		}
	}

	public void changeGuns(string gunName) {

		Destroy (_currentGun);
		Quaternion rot = _currentGun.transform.rotation;
		_currentGun = Instantiate (AK47) as GameObject;
		_currentGun.transform.parent = _camera.transform;
		_currentGun.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		_currentGun.transform.rotation = rot;
		_currentGun.transform.Rotate (-90.0f, 0.0f, 0.0f);
		isAutomatic = true;

	}

	void fire() {
		_fireball = Instantiate (fireballPrefab) as GameObject;
		_fireball.transform.position = _muzzle.transform.position;
		_fireball.transform.rotation = _camera.transform.rotation;
		//_fireball.GetComponent<Rigidbody> ().AddForce (_camera.transform.TransformPoint(Vector3.forward * 9000.5f));
		timer = 0.0f;
	}
}
