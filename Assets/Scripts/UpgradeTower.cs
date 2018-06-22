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
        if(gameObject.GetComponent<Renderer>().enabled  && spot.gameManager.Gold>=(int)(spot.towerPrice*0.8f )){
            Destroy(spot.monster);
            switch (spot.TowerType)
            {
                case 1:
                //waterLv2
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab_2, spot.myVector, Quaternion.identity);
                
                break;
                case 2:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab2_2, spot.myVector, Quaternion.identity);
               
                break;
                case 3:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab3_2, spot.myVector, Quaternion.identity);
                
                break;
                case 4:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab_3, spot.myVector, Quaternion.identity);
                
                break;
                case 5:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab2_3, spot.myVector, Quaternion.identity);
                
                break;
                case 6:
                spot.monster = (GameObject)
                Instantiate(spot.monsterPrefab3_3, spot.myVector, Quaternion.identity);
               
                break;
                default:
                //healthBar.currentHealth -= Mathf.Max(damage, 0);
                break;
            }
            spot.TowerType +=3;
            
            

            //gameObject.GetComponent<Renderer>().enabled =false;
            //SpotTrans.gameObject.GetComponent<Renderer>().enabled =false;
            
            spot.RangeOn = false;
            //spot.GetComponent<Renderer>().enabled =true;
           // spot.Ring.enabled =false;
            //spot.Sell.enabled =false;
            if(spot.TowerType>6)
            spot.Upgrade.enabled =false;
            spot.gameManager.Gold -= (int)(spot.towerPrice*0.8f);
            spot.towerPrice+=(int)(spot.towerPrice*0.8f);
            

        }

    }



}