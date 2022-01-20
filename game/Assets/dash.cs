using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    public float dashSpeed;
    Rigidbody rig;
    bool isDashing;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            isDashing = true;
    }

    private void FixedUpdate()
    {
        if (isDashing)
            Dashing();
    }

    private void Dashing ()
    {
        rig.AddForce(transform.position * dashSpeed, ForceMode.Impulse);
        isDashing = false;
    }


}
