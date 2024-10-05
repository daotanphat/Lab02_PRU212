using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float playerHealth;
	public float currentHealth { get; private set; }
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = playerHealth;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void takeDamage(float damage)
	{
		currentHealth -= damage;
	}
}
