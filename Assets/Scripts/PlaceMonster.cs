using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject monsterPrefab2;
    public GameObject monsterPrefab3;
    public GameObject monsterPrefab_2;
    public GameObject monsterPrefab2_2;
    public GameObject monsterPrefab3_2;
    public GameObject monsterPrefab_3;
    public GameObject monsterPrefab2_3;
    public GameObject monsterPrefab3_3;
    public GameObject monster;
    public Text goldLabel;
    public int towerPrice;
    public int towerPrice1;
    public int towerPrice2;
    public int towerPrice3;
    private int gold;
    public Transform RangeTrans;
    public Renderer Ring;
    public Transform MenuTrans;
    private Menu menu;
    public GameObject gameManagerObj;
    public GameManagerBehavior gameManager;
    

    public int TowerType;
    public float tower1Range;
    public float tower2Range;
    public float tower3Range;
    public Vector3 scaleVec;
    public Vector3 myVector;
    public bool localMenuOn = false;
    public bool isShot=false;

    // Use this for initialization
    void Start()
    {
        towerPrice1= 400;//water
        towerPrice2= 300;//wood
        towerPrice3= 250;//fire
        tower1Range= 6.0f;
        tower2Range= 5.0f;
        tower3Range= 5.0f;

        Ring = RangeTrans.gameObject.GetComponent<Renderer>();
        gameManager = gameManagerObj.GetComponent<GameManagerBehavior>();
        menu = MenuTrans.gameObject.GetComponent<Menu>();
        TowerType =0;
        localMenuOn = false;
        scaleVec = RangeTrans.transform.localScale ;
        myVector = transform.position;
        myVector.y-=1.5f;
        //+= new Vector3(1.0f, 1.0f, 0)


    }
    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseUp()
    {
    	//if ((!gameManager.menuOn) || localMenuOn){
    		MenuTrans.position = transform.position;
    		gameManager.menuOn =true;
            if(menu.spot!=null){
               menu.spot.Ring.enabled=false; 
            }
            
    		menu.spot =transform.gameObject.GetComponent<PlaceMonster>();
    		menu.SpotTrans =transform;

    		if(TowerType>0){
    			if(!localMenuOn){
    				Ring.enabled=true;MenuTrans.gameObject.SetActive(true);
        			localMenuOn =true;
        			menu.Tower1Trans.gameObject.SetActive(false);
        			menu.Tower2Trans.gameObject.SetActive(false);
	        		menu.Tower3Trans.gameObject.SetActive(false);
	        		menu.SellTrans.gameObject.SetActive(true);
	        		if(TowerType <7){
	        			menu.UpgradeTrans.gameObject.SetActive(true);
	        			menu.MaxTrans.gameObject.SetActive(false);
	        		}
	        		else{
	        			menu.UpgradeTrans.gameObject.SetActive(false);
	        			menu.MaxTrans.gameObject.SetActive(true);
	        		}
	        		

        		}
        		else{
        			Ring.enabled=false;
        			MenuTrans.gameObject.SetActive(false);
        			gameManager.menuOn =false;
        			localMenuOn =false;
        		}
        	}
        	if (TowerType==0){
        		if(localMenuOn){
        			MenuTrans.gameObject.SetActive(false);
        			gameManager.menuOn =false;
        			localMenuOn =false;
        		}
        		else{
        			MenuTrans.gameObject.SetActive(true);
        			localMenuOn =true;
        			menu.Tower1Trans.gameObject.SetActive(true);
        			menu.Tower2Trans.gameObject.SetActive(true);
	        		menu.Tower3Trans.gameObject.SetActive(true);
	        		menu.SellTrans.gameObject.SetActive(false);
	        		menu.UpgradeTrans.gameObject.SetActive(false);
	        		menu.MaxTrans.gameObject.SetActive(false);
        		}

        	}

    	//}
        
    }



}