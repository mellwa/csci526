using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTower3 : MonoBehaviour {

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
        //Debug.Log ("Button Clicked. ClickHandler.");
        GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
      	gameManager.TowerType = 3;
    }
}