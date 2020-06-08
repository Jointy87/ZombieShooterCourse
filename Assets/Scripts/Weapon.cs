using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	//Config parameter
	[SerializeField] Camera camera;
	[SerializeField] float shootRange;
	[SerializeField] float bulletDamage;
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] GameObject hitVFX;

	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		PlayMuzzleFlash();
		ProcessRaycast();
	}

	private void PlayMuzzleFlash()
	{
		muzzleFlash.Play();
	}
	private void ProcessRaycast()
	{
		RaycastHit hit;
		if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, shootRange))
		{
			CreateHitImpact(hit);

			EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
			if (target == null) { return; }
			target.TakeDamage(bulletDamage);
		}
		else { return; }
	}
	private void CreateHitImpact(RaycastHit target)
	{
		GameObject hitFX = Instantiate(hitVFX, target.point, Quaternion.LookRotation(target.normal));
		Destroy(hitFX, 0.5f);
	}
}
