using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveGun : MonoBehaviour
{

	public GameObject explosion;
	public Camera cam;
	public float damage = 10f;
	public float range = 100f;
	public TimeManager timeManager;
	public CameraShake cameraShake;

	void Update()
	{
		// If the player presses fire
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
			StartCoroutine(cameraShake.Shake(.15f, .4f));

		}
	}

	void Shoot()
	{
		RaycastHit _hitInfo;
		// If we hit something
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo, range))
		{
			// Create an explosion at the impact point
			GameObject effect = Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));



			timeManager.DoSlowMotion();

			Target target = _hitInfo.transform.GetComponent<Target>();
			if (target != null)
			{
				target.TakeDamage(damage);

			}
			Destroy(effect, 1.5f);
		}

	}
}
