using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCoroutine : MonoBehaviour{
	static public StaticCoroutine instance; //the instance of our class that will do the work

	void Awake(){ //called when an instance awakes in the game
		instance = this; //set our static reference to our newly initialized instance
	}

	IEnumerator PerformCoroutine(){ //the coroutine that runs on our monobehaviour instance
		yield return new WaitForSeconds(1);
	}

	IEnumerator DoCoroutine(){
		yield return StartCoroutine("PerformCoroutine"); //this will launch the coroutine on our instance
	}

	static public void call() {

		instance.DoCoroutine ();
	}
}