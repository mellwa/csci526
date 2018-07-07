
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //private Transform target;
    public float speed = 10f;
    private float damage;
    private float damageScale;
    

    private GameObject nearestenemy;
    private PlaceMonster ShotSpot=null;
    // Update is called once per frame
    public void Seekenemy(GameObject _target,float _damage,float _damageScale )
    {
        nearestenemy = _target;
        damage= _damage;
        damageScale= _damageScale;
    }
    void Update()
    {
        if (nearestenemy == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 dir = nearestenemy.transform.position - transform.position;

        float distancethisframe = speed * Time.deltaTime;
        if (dir.magnitude <= distancethisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancethisframe, Space.World);

    }
    void HitTarget()
    {
        if(nearestenemy.gameObject.tag=="spot"){
            ShotSpot = nearestenemy.gameObject.GetComponent<PlaceMonster>();
            ShotSpot.monster.GetComponent<FireTower>().damageScale = damageScale;

            Destroy(gameObject);

        }
        else{
            //kejin modify:
            Transform healthBarTransform = nearestenemy.transform.Find("HealthBar");
            HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
       
        if (healthBar.currentHealth  > 0)
        {
            healthBar.currentHealth -= Mathf.Max(damage, 0);
            //AudioSource audioSource = nearestenemy.GetComponent<AudioSource>();
            //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            
            
        }
        //Debug.Log("health    " + Healthtrans.localScale);
        // kejin end
        Destroy(gameObject);
    }
    }      
}