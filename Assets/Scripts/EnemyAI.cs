using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	//Config parameters
	[SerializeField] Transform target;
	[SerializeField] float chaseRange = 5f;

	//Cache
	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	bool isProvoked = false;

	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		CheckProvocation();
	}

	private void CheckProvocation()
	{
		distanceToTarget = Vector3.Distance(target.position, transform.position);
		print(distanceToTarget);

		if(isProvoked)
		{
			EngageTarget();
		}
		else if (distanceToTarget <= chaseRange)
		{
			isProvoked = true;
		}
	}

	private void EngageTarget()
	{
		if (distanceToTarget > navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}
		else if (distanceToTarget <= navMeshAgent.stoppingDistance)
		{
			AttackTarget();
		}
	}

	private void ChaseTarget()
	{
		navMeshAgent.SetDestination(target.position);
	}

	private static void AttackTarget()
	{
		print("Attacking target");
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}
