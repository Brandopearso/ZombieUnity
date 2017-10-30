using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	private ArrayList _enemyList = new ArrayList();



	// Use this for initialization
	void Start () {
		GameObject _enemy = Instantiate (enemyPrefab) as GameObject;
		WanderingAI ai = _enemy.GetComponent<WanderingAI> ();
		ai.spawnGate = 2;
		int randrange = Random.Range (-5, 5);
		_enemy.transform.position = new Vector3 (randrange, 0.0f, 15.0f);
		_enemy.transform.Rotate (0, 0, 0);
		_enemyList.Add (_enemy);
	}

	// Update is called once per frame
	void Update () {

		spawnEnemy ();
	}

	void spawnEnemy() {
		while (_enemyList.Count < 5) {
			
			GameObject _enemy = Instantiate (enemyPrefab) as GameObject;
			WanderingAI ai = _enemy.GetComponent<WanderingAI> ();
			ai.spawnGate = 1;
			int randrange = Random.Range (-5, 5);
			_enemy.transform.position = new Vector3 (randrange, -5.0f, -15.0f);
			_enemy.transform.Rotate (0, 0, 0);
			_enemyList.Add (_enemy);
		}
	}
}
