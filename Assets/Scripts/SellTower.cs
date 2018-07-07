using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellTower : MonoBehaviour
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
        Destroy(menu.spot.monster);
            menu.spot.TowerType=0;
            menu.spot.RangeTrans.transform.localScale=new Vector3 (menu.spot.scaleVec.x ,menu.spot.scaleVec.y,0);
            menu.spot.gameManager.Gold+=  (int)(menu.spot.towerPrice*0.5f);
            menu.spot.Ring.enabled=false;
            menu.spot.localMenuOn=false;
            menu.spot.gameManager.menuOn =false;
            MenuTrans.gameObject.SetActive(false);
            menu.SpotTrans.gameObject.GetComponent<Renderer>().enabled= true;


    }



}