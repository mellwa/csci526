using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Wave2
{
	public GameObject allyPrefab;
	public float spawnInterval = 2;
	public int maxAlly = 20;
}

public class SpawnAllies : MonoBehaviour {
	public GameObject[] waypoints;
	//public GameObject testEnemyPrefab;
	public Wave2[] waves;
	public int timeBetweenWaves = 5;

	private GameManagerBehavior gameManager;

	private float lastSpawnTime;
	private int alliesSpawned = 0;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.time;
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
		//Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;

	}
	
	// Update is called once per frame
	void Update () {
		// 1
		int currentWave = gameManager.Wave2;
		if (currentWave < waves.Length)
		{
		// 2
		float timeInterval = Time.time - lastSpawnTime;
		float spawnInterval = waves[currentWave].spawnInterval;
		if (((alliesSpawned == 0 && timeInterval > timeBetweenWaves) ||
			timeInterval > spawnInterval) && 
		alliesSpawned < waves[currentWave].maxAlly)
		{
    	// 3  
    	lastSpawnTime = Time.time;
    	GameObject newAlly = (GameObject)
    	Instantiate(waves[currentWave].allyPrefab);
    	newAlly.GetComponent<MoveAllies>().waypoints = waypoints;
    	alliesSpawned++;
    }
    	// 4 
    	if (alliesSpawned == waves[currentWave].maxAlly &&
    		GameObject.FindGameObjectWithTag("Ally") == null)
    	{
    		gameManager.Wave2++;
    		//gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
    		alliesSpawned = 0;
    		lastSpawnTime = Time.time;
    	}  
    	// 5 
    }
    else
    {
    	//gameManager.gameOver = true;
    	//GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
    	//gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
    }

}
}
