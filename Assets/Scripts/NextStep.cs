using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextStep : MonoBehaviour {
	public Text thisStep;
	public Text nextStep;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);

    }

    private void OnClick(){
        
        thisStep.gameObject.SetActive(false);
        nextStep.gameObject.SetActive(true);
    }
}