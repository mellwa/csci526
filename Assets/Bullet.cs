
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform target;
    public float speed = 10f;
    public void Seek(Transform _target){
        target = _target;
    }
    // Update is called once per frame
    void Update () {
        if(target==null){
            Destroy(gameObject);
            return;
        }
        Vector2 dir = target.position - transform.position;
        //Quaternion lookrotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.FromToRotation(transform.position, target.position).eulerAngles;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation.z);
       
        float distancethisframe = speed * Time.deltaTime;
        if(dir.magnitude<=distancethisframe){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancethisframe, Space.World);

	}
    void HitTarget(){
        Destroy(gameObject);

    }
}
