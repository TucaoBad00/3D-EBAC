using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy;
    public int damageAmount;
    public float speed;
    public List<string> tagsToShoot;
    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var t in tagsToShoot)
        {
            if (collision.transform.tag == t)
            {
                
                var damageble = collision.transform.GetComponent<IDamageble>();

                if (damageble != null)
                { 
                    damageble.IDamage(damageAmount); 
                
                }
                break;
            }
        }
            Destroy(gameObject);

    }
}
