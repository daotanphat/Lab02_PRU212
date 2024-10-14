using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	[SerializeField] Text txtPlayerScore;
	[SerializeField] Text txtHealth;
	[SerializeField] Text txtHealthPoint;
	[SerializeField] Text txtError;
	[SerializeField] PlayerAttack playerAttack;
	[SerializeField] PlayerHealth playerHealth;
	[SerializeField] int health;
	[SerializeField] int healthPoint;
	[SerializeField] UIController uiController;

	public void SetUp()
	{
		Time.timeScale = 0;
		gameObject.SetActive(true);
		uiController.deactive();

		txtHealth.text = "+ " + health;
		txtHealthPoint.text = "- " + healthPoint + " points";



		txtPlayerScore.text = "Your point: " + playerAttack.playerScore;
	}

	public void HealthOnClick()
	{
		if (playerAttack.playerScore >= healthPoint)
		{
			playerAttack.MinusScore(healthPoint);
			if (playerHealth.currentHealth + health >= 100)
			{
				playerHealth.addHealth(100 - (int)playerHealth.currentHealth);
			}
			else
			{
				playerHealth.addHealth(health);
			}
			Time.timeScale = 1;
			gameObject.SetActive(false);
			uiController.active();
		}
		else
		{
			txtError.text = "Not enough point!!!";
		}
	}

	public void BackOnClick()
	{
		Time.timeScale = 1;
		this.gameObject.SetActive(false);
		uiController.active();
	}
}