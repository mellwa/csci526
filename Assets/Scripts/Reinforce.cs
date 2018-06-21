﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reinforce : MonoBehaviour {
	public GameObject[] waypoints;
	public GameObject testAllyPrefab;
    public int price;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        price =100;
    }

    private void OnClick(){
        //Debug.Log ("Button Clicked. ClickHandler.");
        GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        if(gameManager.Gold>=price){
            gameManager.Gold-=price;
            Instantiate(testAllyPrefab).GetComponent<MoveAllies>().waypoints = waypoints;

        }
      	
    }
}