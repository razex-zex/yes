using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
 

    Rigidbody rb;
    [SerializeField]
    public float speed = 5000f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        rb.AddForce(direction * speed * Time.deltaTime);
    }




    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}


