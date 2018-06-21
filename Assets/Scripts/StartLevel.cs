using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        
    }

    private void OnClick(){
    	Time.timeScale = 1;
        GameObject.Find("GameManager").GetComponent<GameManagerBehavior>().StartButton.gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManagerBehavior>().BeforeStart.gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManagerBehavior>().Instruction.gameObject.SetActive(false);
    }
}

