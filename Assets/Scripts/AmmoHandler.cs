using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
	//Config parameters
	[SerializeField] int ammoAmount;

	public int FetchAmmoAmount()
	{
		return ammoAmount;
	}

	public void ReduceAmmoAmount()
	{
		ammoAmount--;
		print(ammoAmount);
	}
}
