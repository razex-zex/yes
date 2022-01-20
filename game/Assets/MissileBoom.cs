using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBoom : MonoBehaviour
{
    public GameObject explossionEffect;
    public float explosionForce = 10f;
    public float radius = 10f;


    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if (rig !=null)
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
        }
        Instantiate(explossionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }





}
