using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {

	static int currentRound;

	// Use this for initialization
	void Start () {
		currentRound = 1;
	}

	public void changeRound() {

		currentRound++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
