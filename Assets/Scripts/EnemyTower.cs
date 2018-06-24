using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : MonoBehaviour
{
    
    private float firecountdown = 0f;
    [Header("Attributes")]
    public float range = 15f;
    public float firerate = 1f;
    [Header("Setup fields")]
    public string enemytag = "Ally";
    //public Transform parttorotate;
    public GameObject bulletprefab;
    public Transform firepoint;
    GameObject target = null;
    // Use this for initialization

    


    void Start()
    {
        InvokeRepeating("Updatetarget", 0f, 0.5f);

    }

    // Update is called once per frame
    void Updatetarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float minimalEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            float distanceToGoal = enemy.GetComponent<MoveAllies>().DistanceToGoal();
            if (distanceToEnemy<= range && distanceToGoal < minimalEnemyDistance){
                target = enemy;
                minimalEnemyDistance = distanceToGoal;

            }
        }
        
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / firerate;
        }
        firecountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        //Debug.Log("shoot!");
        GameObject bulletgo = (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        FireBullet bullet = bulletgo.GetComponent<FireBullet>();
        if (bullet != null)
        {
            //bullet.Seek(target);
            bullet.Seekenemy(target);
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;

    }
   
}

