using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        btn.gameObject.SetActive(false);
    }

    private void OnClick(){
    	Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

