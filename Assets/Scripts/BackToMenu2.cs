using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenu2 : MonoBehaviour {

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        //btn.gameObject.SetActive(false);
    }

    private void OnClick(){
        //Debug.Log ("Button Clicked. ClickHandler.");
        //Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}