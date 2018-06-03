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

	public int Wave
	{
		get
		{
			return wave;
		}
		set
		{
			wave = value;
			if (!gameOver)
			{
				for (int i = 0; i < nextWaveLabels.Length; i++)
				{
					nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
				}
			}
			waveLabel.text = "WAVE: " + (wave + 1);
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
		Gold = 1000;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
