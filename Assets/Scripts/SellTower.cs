using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellTower : MonoBehaviour
{

    public Transform SpotTrans;
    private Renderer Ring;
    private PlaceMonster spot;

 // Use this for initialization
    void Start()

    {
        spot = SpotTrans.gameObject.GetComponent<PlaceMonster>();

    }


    // Update is called once per frame
    void Update()
    {

    }


    //1
    void OnMouseUp()
    {
        if(gameObject.GetComponent<Renderer>().enabled){
            Destroy(spot.monster);
            gameObject.GetComponent<Renderer>().enabled =false;
            SpotTrans.gameObject.GetComponent<Renderer>().enabled =false;
            spot.TowerType =0;
            spot.RangeOn = false;
            spot.GetComponent<Renderer>().enabled =true;
            spot.Ring.enabled =false;
            spot.Upgrade.enabled =false;
            spot.gameManager.Gold += (int)(spot.towerPrice*0.5f);

        }

    }



}