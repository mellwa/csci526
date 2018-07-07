using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTower : MonoBehaviour
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
        if(menu.spot.gameManager.Gold>=(int)(menu.spot.towerPrice*0.8f )){
            Destroy(menu.spot.monster);
            switch (menu.spot.TowerType)
            {
                case 1:
                //waterLv2
                menu.spot.monster = (GameObject)
                Instantiate(menu.spot.monsterPrefab_2, menu.spot.myVector, Quaternion.identity);
                
                break;
                case 2:
                menu.spot.monster = (GameObject)
                Instantiate(menu.spot.monsterPrefab2_2, menu.spot.myVector, Quaternion.identity);
               
                break;
                case 3:
                menu.spot.monster = (GameObject)
                Instantiate(menu.spot.monsterPrefab3_2, menu.spot.myVector, Quaternion.identity);
                
                break;
                case 4:
                menu.spot.monster = (GameObject)
                Instantiate(menu.spot.monsterPrefab_3, menu.spot.myVector, Quaternion.identity);
                
                break;
                case 5:
                menu.spot.monster = (GameObject)
                Instantiate(menu.spot.monsterPrefab2_3, menu.spot.myVector, Quaternion.identity);
                
                break;
                case 6:
                menu.spot.monster = (GameObject)
                Instantiate(menu.spot.monsterPrefab3_3, menu.spot.myVector, Quaternion.identity);
               
                break;
                default:
                
                break;
            }
            menu.spot.TowerType +=3;
            menu.spot.gameManager.Gold -= (int)(menu.spot.towerPrice*0.8f);
            menu.spot.towerPrice+=(int)(menu.spot.towerPrice*0.8f);
            menu.spot.Ring.enabled=false;

            MenuTrans.gameObject.SetActive(false);
            menu.spot.gameManager.menuOn =false;
            menu.spot.localMenuOn =false;
            if (Time.timeScale > 0)
            {
                menu.spot.gameManager.deductGold.text = "Gold -" + menu.spot.towerPrice;
                menu.spot.gameManager.insufficientFund.gameObject.SetActive(false);
                menu.spot.gameManager.deductGold.gameObject.SetActive(true);
            }
            // if(menu.spot.TowerType>6){
            //     menu.MaxTrans.gameObject.SetActive(true);
            //     menu.UpgradeTrans.gameObject.SetActive(false);
            // }
        }
        else{
            
            if(Time.timeScale >0){
                menu.spot.gameManager.deductGold.gameObject.SetActive(false);
                menu.spot.gameManager.insufficientFund.gameObject.SetActive(true);
            }
            
        }
        Invoke("Vanish", 1.0f); 

        menu.spot.Ring.enabled=false;
        MenuTrans.gameObject.SetActive(false);
        menu.spot.gameManager.menuOn =false;
        menu.spot.localMenuOn =false;
    


    }
    void Vanish()
    {
        menu.spot.gameManager.insufficientFund.gameObject.SetActive(false);
        menu.spot.gameManager.deductGold.gameObject.SetActive(false);
    }
}