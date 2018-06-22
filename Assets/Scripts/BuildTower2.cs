﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTower2 : MonoBehaviour
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

    void OnMouseUp()
    {
    	
    	if(menu.spot.gameManager.Gold>=menu.spot.towerPrice2){
    		
    		menu.spot.monster = (GameObject)
	        Instantiate(menu.spot.monsterPrefab2, menu.spot.myVector, Quaternion.identity);
	        AudioSource audioSource = menu.SpotTrans.gameObject.GetComponent<AudioSource>();
	        audioSource.PlayOneShot(audioSource.clip);
	        menu.spot.gameManager.Gold -= menu.spot.towerPrice2;
            menu.spot.towerPrice = menu.spot.towerPrice2;
	        menu.SpotTrans.gameObject.GetComponent<Renderer>().enabled= false;
	        menu.spot.TowerType=2;
	        menu.spot.RangeTrans.transform.localScale=new Vector3 (menu.spot.scaleVec.x * menu.spot.tower2Range,menu.spot.scaleVec.y * menu.spot.tower2Range,0);
	        menu.Tower1Trans.gameObject.SetActive(false);
	        menu.Tower2Trans.gameObject.SetActive(false);
	        menu.Tower3Trans.gameObject.SetActive(false);
	        menu.SellTrans.gameObject.SetActive(true);
	        menu.UpgradeTrans.gameObject.SetActive(true);
	        
	        menu.spot.Ring.enabled=true;

	    }

	    //TODO:not enough money warning

    }



}