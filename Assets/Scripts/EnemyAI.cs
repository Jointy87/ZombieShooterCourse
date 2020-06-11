using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	//Config parameters
	[SerializeField] float chaseRange = 5f;
	[SerializeField] float turnSpeed = 1f;

	//Cache
	PlayerHealth target;
	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	Animator animator;
	EnemyHealth ourHealth;

	//States
	bool isProvoked = false;

	void Start()
	{
		target = FindObjectOfType<PlayerHealth>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		ourHealth = GetComponent<EnemyHealth>();
	}

	void Update()
	{
		CheckIfKilled();
		CheckProvocation();
	}

	private void CheckIfKilled()
	{
		if (ourHealth.FetchIsKilled())
		{
			enabled = false;
			navMeshAgent.enabled = false;
		}
	}

	private void CheckProvocation()
	{
		distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

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
		FaceTarget();

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
		animator.SetBool("isAttacking", false);
		animator.SetTrigger("isMoving");
		navMeshAgent.SetDestination(target.transform.position);
	}

	private void AttackTarget()
	{
		animator.SetBool("isAttacking", true);
	}

	private void FaceTarget()
	{
		//Gets the direction enemy needs to face
		Vector3 direction = (target.transform.position - transform.position); 
		//Creates the rotation with specified x and y taken from direction
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		//Actually rotates enemy
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
	}

	public void OnDamageTaken()
	{
		isProvoked = true;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}
