using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] Camera camera;
	[SerializeField] float shootRange;
	[SerializeField] float bulletDamage;
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		RaycastHit hit;
		if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, shootRange))
		{
			EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
			if(target == null) { return; }
			target.TakeDamage(bulletDamage);

			//TODO - add visual hit effect
		}
		else { return; }
		
	}
}
