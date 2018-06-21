using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTower : MonoBehaviour
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
        if(gameObject.GetComponent<Renderer>().enabled  && spot.gameManager.Gold>=(int)(spot.towerPrice*0.8f)){
            Destroy(spot.monster);
            switch (spot.TowerType)
            {
                case 1:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab_2, spot.myVector, Quaternion.identity);
                spot.TowerType =4;//waterLv2
                break;
                case 2:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab2_2, spot.myVector, Quaternion.identity);
                spot.TowerType =5;//WoodLv2
                break;
                case 3:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab3_2, spot.myVector, Quaternion.identity);
                spot.TowerType =6;//FireLv2
                break;
                default:
                //healthBar.currentHealth -= Mathf.Max(damage, 0);
                break;
            }
            
            

            //gameObject.GetComponent<Renderer>().enabled =false;
            //SpotTrans.gameObject.GetComponent<Renderer>().enabled =false;
            
            spot.RangeOn = false;
            //spot.GetComponent<Renderer>().enabled =true;
           // spot.Ring.enabled =false;
            //spot.Sell.enabled =false;
            spot.Upgrade.enabled =false;
            spot.gameManager.Gold -= (int)(spot.towerPrice*0.8f);
            spot.towerPrice+=(int)(spot.towerPrice*0.8f);
            

        }

    }



}