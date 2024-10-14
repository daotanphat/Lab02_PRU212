using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] float damage;
	[SerializeField] EndUIController endUIController;
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log(endUIController.gameObject);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
			this.gameObject.SetActive(false);

			if (playerHealth != null) // Ensure the PlayerHealth component exists
			{
				playerHealth.takeDamage(damage);

				if (playerHealth.currentHealth <= 0)
				{
					collision.gameObject.SetActive(false);
					Time.timeScale = 0;
					endUIController.SetUp();
				}
			}
		}
	}
}
