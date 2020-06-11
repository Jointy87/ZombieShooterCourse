using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
	//Config parameters
	[SerializeField] AmmoSlot[] ammoSlots;

	[System.Serializable] // Allows you to see the class in inspector
	private class AmmoSlot
	{
		public AmmoType ammoType;
		public int ammoAmount;
	}

	public int FetchAmmoAmount(AmmoType ammoType)
	{
		return GetAmmoSlot(ammoType).ammoAmount;
	}

	public void ReduceAmmoAmount(AmmoType ammoType)
	{
		GetAmmoSlot(ammoType).ammoAmount--;
	}
	
	private AmmoSlot GetAmmoSlot(AmmoType ammoType)
	{
		foreach(AmmoSlot slot in ammoSlots)
		{
			if(slot.ammoType == ammoType)
			{
				return slot;
			}
		}
		return null;
	}
}
