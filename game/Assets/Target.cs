using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage (float amount)
    {
        Score.scoreValue += 10;
        health -= amount;
        if (health <=0f)
        {
            Die();
        }
        
    }


    void Die()
    {
        Destroy(gameObject);
    }



}
