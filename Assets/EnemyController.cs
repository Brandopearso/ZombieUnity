using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	static public ArrayList _enemyList = new ArrayList();
	static bool spawningEnemies;

	static int currentRound;


	// Use this for initialization
	void Start () {
//		GameObject _enemy = Instantiate (enemyPrefab) as GameObject;
//		WanderingAI ai = _enemy.GetComponent<WanderingAI> ();
//		ai.spawnGate = 2;
//		int randrange = Random.Range (-5, 5);
//		_enemy.transform.position = new Vector3 (randrange, 0.0f, 15.0f);
//		_enemy.transform.Rotate (0, 0, 0);
//		_enemyList.Add (_enemy);

		currentRound = 0;
		spawningEnemies = false;
	}

	// Update is called once per frame
	void Update () {
		print (_enemyList.Count);

		//print (_enemyList.Count);
		if (_enemyList.Count < 1 && !spawningEnemies) {
			spawningEnemies = true;
			while(_enemyList.Count < (currentRound * 5)) {
				spawnEnemy ();
			}
			spawningEnemies = false;
			updateRound ();
		}
	}

	void updateRound() {

		currentRound++;
		GameObject round = GameObject.Find ("Round");
		round.GetComponent<TextMesh> ().text = "Round:" + currentRound;
	}

	void spawnEnemy() {

		GameObject _enemy = Instantiate (enemyPrefab) as GameObject;
		WanderingAI ai = _enemy.GetComponent<WanderingAI> ();
		ai.spawnGate = 1;
		int randrange = Random.Range (-5, 5);
		_enemy.transform.position = new Vector3 (randrange, -5.0f, -15.0f);
		_enemy.transform.Rotate (0, 0, 0);
		_enemyList.Add (_enemy);
	}
}
