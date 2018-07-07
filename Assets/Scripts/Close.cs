using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{

    public Transform MenuTrans;
    private Menu menu;

 // Use this for initialization
    void Start()

    {
        menu = MenuTrans.gameObject.GetComponent<Menu>();

    }


    // Update is called once per frame
    void Update()
    {

    }


    //1
    void OnMouseUp()
    {
        if(menu.spot!=null &&menu.spot.gameManager.menuOn){
        menu.spot.Ring.enabled=false;
        menu.spot.localMenuOn=false;
        menu.spot.gameManager.menuOn =false;
        MenuTrans.gameObject.SetActive(false);
            }

            
    }



}