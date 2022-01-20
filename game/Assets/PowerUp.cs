using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    public float duration = 4f;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          StartCoroutine(Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider player)
    {

        //player.transform.localScale *= multiplier;

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.health /= multiplier;


        Destroy(gameObject);
    }



}
