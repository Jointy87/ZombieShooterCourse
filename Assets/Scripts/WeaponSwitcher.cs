using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
	//Config parameters
	[SerializeField] int currentWeapon = 0;


	void Start()
	{
		SetWeaponActive();
	}


	void Update()
	{
		ProcessKeySwitching();
		ProcessScrollSwitching();
	}

	private void ProcessKeySwitching()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentWeapon = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentWeapon = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentWeapon = 2;
		}

		SetWeaponActive();
	}

	private void ProcessScrollSwitching()
	{
		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if(currentWeapon == transform.childCount - 1)
			{
				currentWeapon = 0;
			}
			else
			{
				currentWeapon++;
			}
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (currentWeapon == 0)
			{
				currentWeapon = transform.childCount - 1;
			}
			else
			{
				currentWeapon--;
			}
		}

		SetWeaponActive();
	}

	private void SetWeaponActive()
	{
		for (int weaponIndex = 0; weaponIndex < transform.childCount; weaponIndex++)
		{
			if (weaponIndex == currentWeapon)
			{
				transform.GetChild(weaponIndex).gameObject.SetActive(true);
			}
			else
			{
				transform.GetChild(weaponIndex).gameObject.SetActive(false);
			}
		}
	}
}
