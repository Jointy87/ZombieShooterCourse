using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weapon : MonoBehaviour
{
	//Config parameter
	[SerializeField] Camera camera;
	[Range(30f, 60f)][SerializeField] float zoomFOV = 40f;
	[SerializeField] float zoomMouseSensitivity;
	[SerializeField] float shootRange;
	[SerializeField] float bulletDamage;
	[SerializeField] AmmoHandler ammoHandler;
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] GameObject hitVFX;

	//Cache
	float camStartFOV;
	RigidbodyFirstPersonController fpController;
	float originalMouseSensX;
	float originalMouseSensY;

	private void Start()
	{
		camStartFOV = camera.fieldOfView;
		fpController = FindObjectOfType<RigidbodyFirstPersonController>();
		originalMouseSensX = fpController.mouseLook.XSensitivity;
		originalMouseSensY = fpController.mouseLook.YSensitivity;
	}

	void Update()
	{
		AimDownSights();
		Shoot();
	}

	private void AimDownSights()
	{
		if(Input.GetButton("Fire2"))
		{
			camera.fieldOfView = zoomFOV;
			fpController.mouseLook.XSensitivity = zoomMouseSensitivity;
			fpController.mouseLook.YSensitivity = zoomMouseSensitivity;
		}
		else
		{
			camera.fieldOfView = camStartFOV;
			fpController.mouseLook.XSensitivity = originalMouseSensX;
			fpController.mouseLook.YSensitivity = originalMouseSensY;
		}
	}

	private void Shoot()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if(ammoHandler.FetchAmmoAmount() > 0)
			{
				PlayMuzzleFlash();
				ProcessRaycast();
				ammoHandler.ReduceAmmoAmount();
			}
			else
			{
				print("Out of ammo");
				//play clicking sound
			}

		}
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
