using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseGunController : MonoBehaviour {

	public string gunName = "asd";

	// Use this for initialization
	void Start () {
		
	}

	public void givePlayerGun() {


		GameObject gun = GameObject.Find ("Gun");
		if (gun != null) {

			gun.GetComponent<Gun> ().changeGuns (gunName);
		}
	}
}
