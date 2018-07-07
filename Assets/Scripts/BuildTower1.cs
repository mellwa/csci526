using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTower1 : MonoBehaviour
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
    	
    	if(menu.spot.gameManager.Gold>=menu.spot.towerPrice1){
    		
    		menu.spot.monster = (GameObject)
	        Instantiate(menu.spot.monsterPrefab, menu.spot.myVector, Quaternion.identity);
	        AudioSource audioSource = menu.SpotTrans.gameObject.GetComponent<AudioSource>();
	        audioSource.PlayOneShot(audioSource.clip);
	        menu.spot.gameManager.Gold -= menu.spot.towerPrice1;
	        menu.spot.towerPrice = menu.spot.towerPrice1;
	        menu.SpotTrans.gameObject.GetComponent<Renderer>().enabled= false;
	        menu.spot.TowerType=1;
	        menu.spot.RangeTrans.transform.localScale=new Vector3 (menu.spot.scaleVec.x * menu.spot.tower1Range,menu.spot.scaleVec.y * menu.spot.tower1Range,0);
            if (Time.timeScale > 0)
            {
                menu.spot.gameManager.deductGold.text = "Gold -" + menu.spot.towerPrice1;
                menu.spot.gameManager.insufficientFund.gameObject.SetActive(false);
                menu.spot.gameManager.deductGold.gameObject.SetActive(true);
            }
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