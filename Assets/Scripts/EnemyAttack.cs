using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	//Config parameters
	[SerializeField] float damagePerHit = 10f;

	//Cache
	PlayerHealth target;

	private void Start()
	{
		target = FindObjectOfType<PlayerHealth>();
	}

	public void DoDamageToPlayer()
	{
		if (target == null) { return; }

		target.TakeDamage(damagePerHit);
	}
}
