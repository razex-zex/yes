using System.Collections;
using UnityEngine;

public class Scope : MonoBehaviour
{
  
    public Animator animator;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;
    public float scopedFov = 15f;
    public float normalFov;

    private bool isScoped = false;


    private void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("isScoped", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnScoped();
        }
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFov;
    }
   
    IEnumerator OnScoped ()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFov = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFov;
    }

    
}
