using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject monster;


    // Use this for initialization
    void Start()
    {

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
            //3
            monster = (GameObject)
              Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            //4
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            // TODO: Deduct gold
        }
    }
}