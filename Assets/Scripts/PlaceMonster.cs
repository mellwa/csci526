using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject monsterPrefab2;
    public GameObject monsterPrefab3;
    public GameObject monster;
    public Text goldLabel;
    public int towerPrice1;
    public int towerPrice2;
    public int towerPrice3;
    private int gold;
    public Transform RangeTrans;
    public Transform SellTrans;
    public Renderer Ring;
    private Renderer Sell;
    public GameObject gameManagerObj;
    public GameManagerBehavior gameManager;
    public bool RangeOn;
    public int TowerType;
    private float tower1Range;
    private float tower2Range;
    private float tower3Range;
    private Vector3 scaleVec;






    // Use this for initialization
    void Start()
    {
        towerPrice1= 400;//water
        towerPrice2= 300;//wood
        towerPrice3= 250;//fire
        tower1Range= 6.0f;
        tower2Range= 4.0f;
        tower3Range= 5.0f;

        Ring = RangeTrans.gameObject.GetComponent<Renderer>();
        Sell = SellTrans.gameObject.GetComponent<Renderer>();
        gameManager = gameManagerObj.GetComponent<GameManagerBehavior>();
        TowerType =0;
        RangeOn = false;
        scaleVec = RangeTrans.transform.localScale ;
        //+= new Vector3(1.0f, 1.0f, 0)


    }


    // Update is called once per frame
    void Update()
    {

    }


    //1
    void OnMouseUp()
    {
        //2
        if(TowerType>0){
        		if(RangeOn){
        			Ring.enabled=true;
        			Sell.enabled=true;
        			RangeOn = false;

        		}
        		else{
        			Ring.enabled=false;
        			Sell.enabled=false;
        			RangeOn = true;
        		}
        		
            }
        if (TowerType==0)
        {
            Vector3 myVector = transform.position;
            myVector.y-=1.5f; 
            
            gold = gameManager.Gold;
            //3
            if(gameManager.TowerType==1&&gold>=towerPrice1){
                monster = (GameObject)
              Instantiate(monsterPrefab, myVector, Quaternion.identity);
              AudioSource audioSource = gameObject.GetComponent<AudioSource>();
              audioSource.PlayOneShot(audioSource.clip);
              gameManager.Gold -= towerPrice1;
              gameObject.GetComponent<Renderer>().enabled= false;
              TowerType=1;
              RangeTrans.transform.localScale=new Vector3 (scaleVec.x * tower1Range,scaleVec.y * tower1Range,0);
            }
            if(gameManager.TowerType==2&&gold>=towerPrice2){
                monster = (GameObject)
              Instantiate(monsterPrefab2, myVector, Quaternion.identity);
              AudioSource audioSource = gameObject.GetComponent<AudioSource>();
              audioSource.PlayOneShot(audioSource.clip);
            gameManager.Gold -= towerPrice2;
            gameObject.GetComponent<Renderer>().enabled= false;
            TowerType=2;
            RangeTrans.transform.localScale=new Vector3 (scaleVec.x * tower2Range,scaleVec.y * tower2Range,0);
            }
            if(gameManager.TowerType==3&&gold>=towerPrice3){
              monster = (GameObject)
              Instantiate(monsterPrefab3, myVector, Quaternion.identity);
              AudioSource audioSource = gameObject.GetComponent<AudioSource>();
              audioSource.PlayOneShot(audioSource.clip);
              gameManager.Gold -= towerPrice3;
              gameObject.GetComponent<Renderer>().enabled= false;
              TowerType=3;
              RangeTrans.transform.localScale=new Vector3 (scaleVec.x * tower3Range,scaleVec.y * tower3Range,0);
            }
            
            
            gameManager.TowerType = 0;
        }
    }

    //  void OnMouseOver()
    // {
    //     //if(gameManager.TowerType>0){
    //     	Ring.enabled=true;
    //     //}
        
    // }

    // void OnMouseExit()
    // {
    //     //The mouse is no longer hovering over the GameObject so output this message each frame
    //     Ring.enabled=false;
    // }

}