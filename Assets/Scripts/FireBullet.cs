
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //private Transform target;
    public float speed = 10f;
   
    public float fireDamageRate;
    public float woodDamageRate;
    public float waterDamageRate;
    private PlaceMonster ShotSpot=null;
    private GameObject nearestenemy;
    private int damage;
    // Update is called once per frame
    public void Seekenemy(GameObject _target,int _damage)
    {
        nearestenemy = _target;
        damage = _damage;
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
    
        
        Transform healthBarTransform = nearestenemy.transform.Find("HealthBar");
        HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
       
        if (healthBar.currentHealth  > 0)
        {
            switch (healthBar.elementalTag)
            {
                case "fire":
                healthBar.currentHealth -= Mathf.Max(damage*fireDamageRate, 0);
               
                break;
                case "water":
                healthBar.currentHealth -= Mathf.Max(damage*waterDamageRate, 0);
                break;
                case "wood":
                healthBar.currentHealth -= Mathf.Max(damage*woodDamageRate, 0);
                break;
                default:
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                break;
            }
    
            
            
            //AudioSource audioSource = nearestenemy.GetComponent<AudioSource>();
            //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            
            
        }
        //Debug.Log("health    " + Healthtrans.localScale);
        // kejin end
        Destroy(gameObject);
    
    }      
}