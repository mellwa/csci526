using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;
    private float firecountdown = 0f;
    [Header("Attributes")]
    public float range = 15f;
    public float turnspeed = 5f;
    public float firerate = 1f;
    [Header("Setup fields")]
    public string enemytag = "Enemy";
    public Transform parttorotate;
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
        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = Vector3.RotateTowards(parttorotate.forward, dir, Time.deltaTime * turnspeed, 0.0f);
        Vector3 rotation = Quaternion.Lerp(parttorotate.rotation, lookrotation, Time.deltaTime * turnspeed).eulerAngles;
        parttorotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
        //Debug.Log("rotationz :" + rotation.z+"  tagert: "+target.rotation.z+"  trans : "+parttorotate.rotation.z+" tower:"+transform.rotation.z);
        //Debug.Log("look rotation: " + parttorotate.rotation.z);
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
        Bullet bullet = bulletgo.GetComponent<Bullet>();
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
