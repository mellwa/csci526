using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject monsterPrefab2;
    public GameObject monsterPrefab3;
    private GameObject monster;
    public Text goldLabel;
    public int towerPrice1;
    public int towerPrice2;
    public int towerPrice3;
    private int gold;




    // Use this for initialization
    void Start()
    {
        towerPrice1= 100;
        towerPrice2= 200;
        towerPrice3= 300;

    }


    // Update is called once per frame
    void Update()
    {

    }

    private bool CanPlaceMonster()
    {
        return monster == null;
    }

    //1
    void OnMouseUp()
    {
        //2
        if (CanPlaceMonster())
        {
            GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
            gold = gameManager.Gold;
            //3
            if(gameManager.TowerType==1&&gold>=towerPrice1){
                monster = (GameObject)
              Instantiate(monsterPrefab, transform.position, Quaternion.identity);
              AudioSource audioSource = gameObject.GetComponent<AudioSource>();
              audioSource.PlayOneShot(audioSource.clip);
              gameManager.Gold -= towerPrice1;
            }
            if(gameManager.TowerType==2&&gold>=towerPrice2){
                monster = (GameObject)
              Instantiate(monsterPrefab2, transform.position, Quaternion.identity);
              AudioSource audioSource = gameObject.GetComponent<AudioSource>();
              audioSource.PlayOneShot(audioSource.clip);
            gameManager.Gold -= towerPrice2;
            }
            if(gameManager.TowerType==3&&gold>=towerPrice3){
              monster = (GameObject)
              Instantiate(monsterPrefab3, transform.position, Quaternion.identity);
              AudioSource audioSource = gameObject.GetComponent<AudioSource>();
              audioSource.PlayOneShot(audioSource.clip);
              gameManager.Gold -= towerPrice3;
            }
            
            gameManager.TowerType = 0;
        }
    }
}