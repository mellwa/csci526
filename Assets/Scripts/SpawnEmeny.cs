using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EnemyList
{
    public GameObject enemyPrefab;
    public int maxEnemies = 20;

}
[System.Serializable]
public class Wave
{
    //public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int totalEnemies = 20;
    public float HealthScale = 1.0f;
    public EnemyList[] enemyList;

}


public class SpawnEmeny : MonoBehaviour
{
    public GameObject[] waypoints;
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    public string lvStars;
    private GameManagerBehavior gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    private int enemiesSpawned2 = 0;
    private int enemiesType = 0;


    // Use this for initialization
    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        //Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;

    }

    // Update is called once per frame
    void Update()
    {
        // 1
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                  timeInterval > spawnInterval) &&
                  enemiesSpawned < waves[currentWave].totalEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;

                Debug.Log("type: " + enemiesType + " length: " + waves[currentWave].enemyList.Length);
                if (enemiesSpawned2 == waves[currentWave].enemyList[enemiesType].maxEnemies)
                {
                    enemiesType++;
                    enemiesSpawned2 = 0;
                }
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyList[enemiesType].enemyPrefab);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                newEnemy.GetComponent<MoveEnemy>().SetHealth(waves[currentWave].HealthScale);
                enemiesSpawned++;
                enemiesSpawned2++;

            }
            // 4 
            if (enemiesSpawned == waves[currentWave].totalEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                //gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                enemiesSpawned2 = 0;
                enemiesType = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
        else
        {

            //gameManager.gameOver = true;
            if (gameManager.Health > 0 && !gameManager.gameOver)
            {
                gameManager.gameOver = true;
                gameManager.gameWonText.gameObject.SetActive(true);
                gameManager.BackToMenu.gameObject.SetActive(true);
                gameManager.NextLevel.gameObject.SetActive(true);

                PlayerPrefs.SetInt(lvStars, 1);

                Time.timeScale = 0;



            }


            // gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }

    }
}
