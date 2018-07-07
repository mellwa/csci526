using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reinforce : MonoBehaviour {
	public GameObject[] waypoints;
	public GameObject testAllyPrefab;
    public int price;
    GameManagerBehavior gameManager;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private void OnClick(){
        if(gameManager.Gold>=price){
            gameManager.Gold-=price;
            Instantiate(testAllyPrefab).GetComponent<MoveAllies>().waypoints = waypoints;
            if (Time.timeScale > 0)
            {
                gameManager.deductGold.text = "Gold -" + price;
                gameManager.insufficientFund.gameObject.SetActive(false);
                gameManager.deductGold.gameObject.SetActive(true);
            }
        }
        else{
            
            if(Time.timeScale >0){
                gameManager.deductGold.gameObject.SetActive(false);
                gameManager.insufficientFund.gameObject.SetActive(true);
            }
            
        }
        Invoke("Vanish", 1.0f); 
      	
    }

    void Vanish()
    {
        gameManager.insufficientFund.gameObject.SetActive(false);
        gameManager.deductGold.gameObject.SetActive(false);
    }
}