using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	//Config parameters
	[SerializeField] float healthPoints;

	//Cache
	bool isKilled = false;

	public bool FetchIsKilled()
	{
		return isKilled;
	}

	public void TakeDamage(float bulletDMG)
	{
		BroadcastMessage("OnDamageTaken");
		healthPoints -= bulletDMG;

		if (healthPoints <= 0)
		{
			if (isKilled) { return; }
			Die();
		}
	}

	private void Die()
	{
		isKilled = true;
		GetComponent<Animator>().SetTrigger("isKilled");
	}
}
