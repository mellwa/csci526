using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerBehavior : MonoBehaviour {
	public Text waveLabel;
	public GameObject[] nextWaveLabels;
	public Text goldLabel;
	private int gold;
	public bool gameOver = false;
	private int wave;
	private int wave2;
	public Text healthLabel;
	public GameObject[] healthIndicator;
	private int health;
	public int Health
	{
	  get
	  {
	    return health;
	  }
	  set
	  {
	    // 1
	    if (value < health)
	    {
	      Camera.main.GetComponent<CameraShake>().Shake();
	    }
	    // 2
	    health = value;
	    healthLabel.text = "HEALTH: " + health;
	    // 3
	    if (health <= 0 && !gameOver)
	    {
	      gameOver = true;
	      GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
	      gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
	    }
	    // 4 
	    for (int i = 0; i < healthIndicator.Length; i++)
	    {
	      if (i < Health)
	      {
	        healthIndicator[i].SetActive(true);
	      }
	      else
	      {
	        healthIndicator[i].SetActive(false);
	      }
	    }
	  }
	}

	public int Wave
	{
		get
		{
			return wave;
		}
		set
		{
			wave = value;
			// if (!gameOver)
			// {
			// 	for (int i = 0; i < nextWaveLabels.Length; i++)
			// 	{
			// 		nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
			// 	}
			// }
			waveLabel.text = "WAVE: " + (wave + 1);
		}
	}

	public int Wave2
	{
		get
		{
			return wave2;
		}
		set
		{
			wave2 = value;
			// if (!gameOver)
			// {
			// 	for (int i = 0; i < nextWaveLabels.Length; i++)
			// 	{
			// 		nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
			// 	}
			// }
			// waveLabel.text = "WAVE: " + (wave + 1);
		}
	}


	public int Gold {
		get
		{ 
			return gold;
		}
		set
		{
			gold = value;
			goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
		}
	}



	// Use this for initialization
	void Start () {
		Wave = 0;
		Wave2 = 0;
		Gold = 1000;
		Health = 5;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
