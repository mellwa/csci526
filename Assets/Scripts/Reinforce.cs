using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reinforce : MonoBehaviour {
	public GameObject[] waypoints;
	public GameObject testAllyPrefab;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
        //Debug.Log ("Button Clicked. ClickHandler.");
        GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
      	gameManager.Gold-=100;
      	Instantiate(testAllyPrefab).GetComponent<MoveAllies>().waypoints = waypoints;
    }
}