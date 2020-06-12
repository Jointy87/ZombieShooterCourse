using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponentInChildren<FlashLightHandler>().RestoreToFull();
			Destroy(gameObject);

		}
	}
}
