using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    Transform target;

    [SerializeField]
    Transform shootPoint;

    float fireRate = 0.2f;
    [SerializeField]
    float turnSpeed = 5;
    [SerializeField]
    int shootDistance = 20;
    public float lookRadius = 10f;
    NavMeshAgent agent;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;

        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        
        if (fireRate < 0 && Vector3.Distance(transform.position, target.position) < shootDistance)
        {
            fireRate = 0.5f; 
            Shoot();
        }
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                //attack 
                //chase
            }
        }
    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
 