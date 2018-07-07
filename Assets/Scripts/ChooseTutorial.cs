using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTutorial : MonoBehaviour {
	public GameObject star2;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        if(PlayerPrefs.GetInt("Level1", 0)>0){
        	star2.GetComponent<Star>().Star1.enabled = true;
        	star2.GetComponent<Star>().Star4.enabled = false;


        	if(PlayerPrefs.GetInt("Level1", 0)>1){
        		star2.GetComponent<Star>().Star2.enabled = true;
        		star2.GetComponent<Star>().Star5.enabled = false;

        		if(PlayerPrefs.GetInt("Level1", 0)>2){
        			star2.GetComponent<Star>().Star3.enabled = true;
        			star2.GetComponent<Star>().Star6.enabled = false;

        		}
        	}
        }
    }

    private void OnClick(){
        
        Application.LoadLevel(4);
    }
}