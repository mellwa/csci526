using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerBehavior : MonoBehaviour {
	public Text waveLabel;
	public GameObject[] nextWaveLabels;
	public Text goldLabel;
	public Text gameOverText;
	public Text gameWonText;
	public Text BeforeStart;
	public Text Instruction;
    public Text insufficientFund;
    public Text deductGold;
    public Text AllyPassedThrough;
    private int gold;
	public bool gameOver = false;
	private int wave;
	private int wave2;
	//public GameObject EnemyRoad;
	public Text healthLabel;
	public GameObject[] healthIndicator;
	private int health;
	private int allyNum;
	public int towerType;
	public Button Replay;
	public Button BackToMenu;
	public Button NextLevel;
	public Button StartButton;
	public bool menuOn=false;
    public int AllyPassedGoal =5;
    [Header("Level")]
    public int gameLevel;

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
	      GameOverStop();
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
			waveLabel.text = "WAVE:  " + (wave + 1) +" / "+ GameObject.Find("Road").GetComponent<SpawnEmeny>().waves.Length;
		}
	}

	public int TowerType
	{
		get
		{
			return towerType;
		}
		set
		{
		towerType = value;

			
		}
	}

	public int AllyNum
	{
		get
		{
			return allyNum;
		}
		set
		{
		allyNum = value;
		AllyPassedThrough.text = "ALLY  PASSED:  " + allyNum + " / " + AllyPassedGoal;
			
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
        Config config = Config.getInstance();
		Wave = 0;
		Wave2 = 0;
        Gold = config.getInitGold(this.gameLevel);
        Health = config.getInitialHealth(this.gameLevel);
		AllyNum = 0;
		TowerType= 0; //no tower is selected
		Time.timeScale = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GameOverStop(){
		gameOver = true;
	    gameOverText.gameObject.SetActive(true);
	    BackToMenu.gameObject.SetActive(true);
	    Replay.gameObject.SetActive(true);
	    Time.timeScale = 0;

	}
}
