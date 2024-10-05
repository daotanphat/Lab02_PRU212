using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private Transform firePoint;
	[SerializeField] float attackCooldown;
	[SerializeField] GameObject[] fireBalls;
	Animator animator;
	PlayerMovement playerMovement;
	float cooldownTimer = Mathf.Infinity;
	public int playerScore { get; private set; }

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
		{
			Attack();
		}
		cooldownTimer += Time.deltaTime;
	}

	void Attack()
	{
		animator.SetTrigger("attack");
		cooldownTimer = 0;

		fireBalls[FindFireBall()].transform.position = firePoint.position;
		fireBalls[FindFireBall()].GetComponent<FireBall>().setDirection(Mathf.Sign(transform.localScale.x));
	}

	private int FindFireBall()
	{
		for (int i = 0; i < fireBalls.Length; i++)
		{
			if (!fireBalls[i].activeInHierarchy)
			{
				return i;
			}
		}
		return 0;
	}

	public void AddScore(int score)
	{
		playerScore += score;
	}
}
