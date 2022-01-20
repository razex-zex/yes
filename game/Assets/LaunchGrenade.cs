using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject missile;
    public GameObject currenMissible;

    public float speed = 20f;
    bool launched;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            launched = true;
    }


    private void FixedUpdate()
    {
        if (launched)
            Launch();
    }


    private void Load()
    {
        GameObject missileInstance = Instantiate(missile, spawnPoint.position, spawnPoint.rotation);
        missileInstance.transform.parent = spawnPoint;
        currenMissible = missileInstance;
        Rigidbody rig_m = currenMissible.GetComponent<Rigidbody>();
        rig_m.isKinematic = true;
    }

    private void Launch()
    {
        Rigidbody rig_m = currenMissible.GetComponent<Rigidbody>();
        currenMissible.transform.parent = null;
        rig_m.isKinematic = false;
        rig_m.AddForce(spawnPoint.right * speed, ForceMode.Impulse);

        launched = false;
        Invoke("Load", 2f);
    }

     

}   


