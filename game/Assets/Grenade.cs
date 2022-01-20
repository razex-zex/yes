using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float force = 700f;
    public bool spawnMore = false;
    public GameObject miniGrenade;
    public float damage = 10f;
    public Camera fpsCam;
    public float range = 100f;
    

    public float delay = 3f;

    float countdown;

    public float radius = 5;

    bool hasExploded = false;
    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;


        }
    }

    void Explode()
    {

        if (spawnMore == true)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject clone = Instantiate(miniGrenade, transform.position, Random.rotation);
                clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * 50f);
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            Target target = transform.GetComponent<Target>();
            if (rb != null && target != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                target.TakeDamage(damage);

            }

        }
            
        Destroy(gameObject);

    }

}
