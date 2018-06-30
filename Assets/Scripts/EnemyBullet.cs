
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //private Transform target;
    public float speed = 10f;
    public float damage =40.0f;
    

    private GameObject nearestenemy;
    private PlaceMonster ShotSpot=null;
    // Update is called once per frame
    public void Seekenemy(GameObject _target)
    {
        nearestenemy = _target;
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
            ShotSpot.monster.GetComponent<FireTower>().firerate = 0;

            Destroy(gameObject);

        }
        else{
            //kejin modify:
        if (ShotSpot!=null){
            ShotSpot.monster.GetComponent<FireTower>().firerate = 1;
        }
        
        Transform healthBarTransform = nearestenemy.transform.Find("HealthBar");
        HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
       
        if (healthBar.currentHealth  > 0)
        {
            switch (healthBar.elementalTag)
            {
                case "fire":
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                break;
                case "water":
                healthBar.currentHealth -= Mathf.Max(damage*0.6f, 0);
                break;
                case "wood":
                healthBar.currentHealth -= Mathf.Max(damage*0.6f, 0);
                break;
                default:
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                break;
            }
    
            
            
            AudioSource audioSource = nearestenemy.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            
            
        }
        //Debug.Log("health    " + Healthtrans.localScale);
        // kejin end
        

    }
    
    }      
}