using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

	[SerializeField] private GameObject gatePrefab;

	static private Stack _gate1Alive = new Stack(3);
	static private Stack _gate1Dead = new Stack(3);
	static public bool tearingGate1 = false;

	static private Stack _gate2Alive = new Stack(3);
	static private Stack _gate2Dead = new Stack(3);
	static public bool tearingGate2 = false;

//
//	private readonly Vector3 _GATE1POS = new Vector3 (0.0f,0.4f,-10.0f);
//	private readonly Vector3 _GATE2POS = new Vector3 (0.0f,0.4f,10.0f);
	//private readonly Vector3 _GATE12ROT = new Vector3 (0.0f,90.0f,0.0f);
//
//
//	// need to rotate
//	private readonly Vector3 _GATE3POS = new Vector3 (-10.0f,0.4f,0.0f);
//	private readonly Vector3 _GATE34ROT = new Vector3 (0.0f,90.0f,0.0f);
//
//	private readonly Vector3 _GATE4POS = new Vector3 (10.0f,0.4f,0.0f);



	// Use this for initialization
	void Start () {

		// gate 1
		Vector3[] _gatepos = {
			new Vector3(0.0f,0.4f,-10.0f),
			new Vector3(0.0f,1.5f, -10.0f),
			new Vector3(0.0f,2.5f,-10.0f)
		};
		Vector3 rotation = new Vector3 (0.0f, 90.0f, 0.0f);
		spawnSetOfGates (ref _gate1Alive, _gatepos, rotation, 1);
	
	
		// gate 2
		_gatepos = new Vector3[] {
			new Vector3(0.0f,0.4f,10.0f),
			new Vector3(0.0f,1.5f,10.0f),
			new Vector3(0.0f,2.5f,10.0f)
		};
		rotation = new Vector3 (0.0f, 90.0f, 0.0f);
		spawnSetOfGates (ref _gate2Alive, _gatepos, rotation, 2);
//
//		// gate 3
//		_gatepos = new Vector3[] {
//			new Vector3(10.0f,0.4f,0.0f),
//			new Vector3(10.0f,1.5f,0.0f),
//			new Vector3(10.0f,2.5f,0.0f)
//		};
//		rotation = new Vector3 (0.0f, 0.0f, 0.0f);
//		spawnSetOfGates (ref _gate2Alive, _gatepos, rotation, 3);
//
//		// gate 4
//		_gatepos = new Vector3[] {
//			new Vector3(-10.0f,0.4f,0.0f),
//			new Vector3(-10.0f,1.5f,0.0f),
//			new Vector3(-10.0f,2.5f,0.0f)
//		};
//		rotation = new Vector3 (0.0f, 0.0f, 0.0f);
//		spawnSetOfGates (ref _gate2Alive, _gatepos, rotation, 4);

	}

	void spawnSetOfGates(ref Stack stackOfGates, Vector3[] gatepos, Vector3 rotation, int gateNum) {

		for (int i = 0; i < gatepos.Length; i++) {

			GameObject gate = Instantiate (gatePrefab) as GameObject;
			gate.gameObject.GetComponent<Gate> ().gateNum = gateNum;
			gate.transform.position = gatepos[i];
			gate.transform.Rotate (rotation);
			stackOfGates.Push (gate);
		}
	}

	static public Stack getGateStack(int gateNum) {

		if (gateNum == 1) {
			return _gate1Alive;
		} else if (gateNum == 2) {
			return _gate2Alive;
		}
		return null;
	}

	// returns if its okay to walk through the gate
	static public bool deleteGateFromSet(int gateNum) {

		if (gateNum == 1 && _gate1Alive.Count != 0) {

			GameObject deadGate = _gate1Alive.Pop () as GameObject;
			deadGate.SetActive (false);
			//GameObject deadGateCopy = deadGate;
			_gate1Dead.Push (deadGate);
			//Destroy (deadGate);
			if (_gate1Alive.Count == 0) {
				return true;
			}
		} else if (gateNum == 2 && _gate2Alive.Count != 0) {
			GameObject deadGate = _gate2Alive.Pop () as GameObject;
			GameObject deadGateCopy = deadGate;
			_gate2Dead.Push (deadGateCopy);
			Destroy (deadGate);
			if (_gate2Alive.Count == 0) {
				return true;
			}
		}
		
			return false;

	}

	// returns if its okay to walk through the gate
	static public bool addGateToSet(int gateNum) {

		print ("adding gate");
		if (gateNum == 1 && _gate1Alive.Count < 3) {

			GameObject addGate = _gate1Dead.Pop () as GameObject;
			_gate1Alive.Push (addGate);
			addGate.SetActive (true);
		} else if (gateNum == 2 && _gate2Alive.Count < 3) {
			GameObject addGate = _gate2Dead.Pop () as GameObject;
			GameObject addGateCopy = addGate;
			_gate2Dead.Push (addGateCopy);
		}

		return false;

	}

	static public Transform getGateTransform(int gateNum) {

		if (gateNum == 1) {
			
			if (_gate1Alive.Count == 0) {
				GameObject gateCopy = _gate1Dead.Peek () as GameObject;
				return gateCopy.transform;
			} else {
				GameObject gateCopy = _gate1Alive.Peek () as GameObject;
				return gateCopy.transform;
			}
		} else if (gateNum == 2) {
			if (_gate2Alive.Count == 0) {
				GameObject gateCopy = _gate2Dead.Peek () as GameObject;
				return gateCopy.transform;
			} else {
				GameObject gateCopy = _gate2Alive.Peek () as GameObject;
				return gateCopy.transform;
			}
		}
		return null;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
