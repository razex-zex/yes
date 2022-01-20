using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    private bool isReloading = false;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    public Animator animator;
    public Camera fpsCam;
    public GameObject explosion;
    void Start()
    {
        if(currentAmmo == -1)
        currentAmmo = maxAmmo; 
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;

    }

    void Shoot ()
    {

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            GameObject effect = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            
            Destroy(effect, 1.5f);
        }

    }



}
