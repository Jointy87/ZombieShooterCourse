using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weapon : MonoBehaviour
{
	//Config parameter
	[Header("General")]
	[SerializeField] Camera camera;
	[SerializeField] RigidbodyFirstPersonController fpController;
	[SerializeField] AmmoHandler ammoHandler;
	[SerializeField] AmmoType ammoType;
	[Header("Aim Down Sights")]
	[Range(5f, 60f)][SerializeField] float zoomFOV = 40f;
	[SerializeField] float zoomMouseSensitivity;
	[Header("Shooting values")]
	[SerializeField] float shootRange;
	[SerializeField] float bulletDamage;
	[SerializeField] float shootInterval;
	[Header("FX")]
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] GameObject hitVFX;

	//Cache
	float camStartFOV;
	float originalMouseSensX;
	float originalMouseSensY;
	bool canShoot = true;

	private void Start()
	{
		camStartFOV = camera.fieldOfView;
		originalMouseSensX = fpController.mouseLook.XSensitivity;
		originalMouseSensY = fpController.mouseLook.YSensitivity;
	}
	private void OnEnable()
	{
		canShoot = true;
	}

	private void OnDisable()
	{
		ZoomOut();
	}

	void Update()
	{
		AimDownSights();

		if (Input.GetButtonDown("Fire1") && canShoot == true)
		{
			StartCoroutine(Shoot());
		}
	}

	private void AimDownSights()
	{
		if (Input.GetButton("Fire2"))
		{
			ZoomIn();
		}
		else
		{
			ZoomOut();
		}
	}

	private void ZoomIn()
	{
		camera.fieldOfView = zoomFOV;
		fpController.mouseLook.XSensitivity = zoomMouseSensitivity;
		fpController.mouseLook.YSensitivity = zoomMouseSensitivity;
	}

	private void ZoomOut()
	{
		camera.fieldOfView = camStartFOV;
		fpController.mouseLook.XSensitivity = originalMouseSensX;
		fpController.mouseLook.YSensitivity = originalMouseSensY;
	}

	IEnumerator Shoot()
	{
		if (ammoHandler.FetchAmmoAmount(ammoType) > 0)
		{
			canShoot = false;
			PlayMuzzleFlash();
			ProcessRaycast();
			ammoHandler.ReduceAmmoAmount(ammoType);
		}
		else
		{
			print("Out of ammo");
			//play clicking sound
		}

		yield return new WaitForSeconds(shootInterval);
		canShoot = true;
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
