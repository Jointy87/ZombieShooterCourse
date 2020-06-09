using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float hitPoints;
	
	public void TakeDamage(float enemyDamage)
	{
		hitPoints -= enemyDamage;
		print(hitPoints);

		if(hitPoints <= 0)
		{
			print("YOU DEAD");
		}
	}
}
