using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float hitPoints;
	[SerializeField] TextMeshProUGUI healthText;
	[SerializeField] DamageDisplay damagedUI;

	private void Update()
	{
		DisplayHealthToHud();
	}

	private void DisplayHealthToHud()
	{
		healthText.text = hitPoints.ToString();
	}

	public void TakeDamage(float enemyDamage)
	{
		hitPoints -= enemyDamage;
		print(hitPoints);
		damagedUI.DisplayBlood();

		if(hitPoints <= 0)
		{
			print("YOU DEAD");
			GetComponent<DeathHandler>().HandleDeath();
		}
	}
}
