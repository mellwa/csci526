using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    private Transform target;
    private float firecountdown = 0f;
    [Header("Attributes")]
    public float range = 15f;
    public float turnspeed = 5f;
    public float firerate = 1f;
    [Header("Setup fields")]
    public string enemytag = "Enemy";
    //public Transform parttorotate;
    public GameObject bulletprefab;
    public Transform firepoint;
    GameObject nearestenemy = null;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Updatetarget", 0f, 0.5f);

    }

    // Update is called once per frame
    void Updatetarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortesdistoenemy = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distancetoenemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (shortesdistoenemy > distancetoenemy)
            {
                shortesdistoenemy = distancetoenemy;
                nearestenemy = enemy;
            }
        }
        if (nearestenemy != null && shortesdistoenemy <= range)
        {
            target = nearestenemy.transform;
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
            bullet.Seekenemy(nearestenemy);
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;

    }
}
