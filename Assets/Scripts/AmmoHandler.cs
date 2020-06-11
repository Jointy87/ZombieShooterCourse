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

	public int FetchAmmoAmount(AmmoType type)
	{
		return GetAmmoSlot(type).ammoAmount;
	}

	public void ReduceAmmoAmount(AmmoType typeToReduce)
	{
		GetAmmoSlot(typeToReduce).ammoAmount--;
	}
	public void AddToAmmo(AmmoType typeToAdd, int amountToAdd)
	{
		GetAmmoSlot(typeToAdd).ammoAmount += amountToAdd;
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
