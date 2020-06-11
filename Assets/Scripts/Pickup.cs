using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] AmmoType ammoType;
	[SerializeField] int ammoAmount;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<AmmoHandler>().AddToAmmo(ammoType, ammoAmount);
			Destroy(gameObject);
		 
		}
	}
}
