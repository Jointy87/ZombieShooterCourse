using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] float healthPoints;
	public void TakeDamage(float bulletDMG)
	{
		healthPoints -= bulletDMG;

		if (healthPoints <= 0)
		{
			Destroy(gameObject);
		}
	}
}
