
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Transform target;
    public float speed = 10f;

    private GameObject nearestenemy;
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

        //kejin modify:
        Transform Healthtrans = nearestenemy.transform.Find("HealthBar");
        if (Healthtrans == null)
        {
            Debug.Log("no Healthbar");
        }

        if (Healthtrans.localScale.x >= 0)
        {
            Healthtrans.localScale -= new Vector3(10f, 0f, 0f);
        }
        Debug.Log("health    " + Healthtrans.localScale);
        // kejin end
        Destroy(gameObject);

    }
}
