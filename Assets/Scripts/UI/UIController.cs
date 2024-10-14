using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] Text tbTime;
	[SerializeField] int limitTime;
	[SerializeField] Button pauseButon;
	[SerializeField] Button shopButton;
	[SerializeField] Image healthBarFill;
	[SerializeField] PlayerHealth playerHealth;
	[SerializeField] PlayerAttack playerAttack;
	[SerializeField] Text tbScore;
	[SerializeField] EndUIController endUIController;
	[SerializeField] ShopController shopController;
	float timer = 0;
	bool isPaused = false;
	Text txtPausedButton;

	// Start is called before the first frame update
	void Start()
	{
		//tbTime.text = "Time: " + limitTime.ToString();
		tbScore.text = "Score: 0";
		txtPausedButton = pauseButon.GetComponentInChildren<Text>();
		healthBarFill.fillAmount = 1;
	}

	// Update is called once per frame
	void Update()
	{
		//timer += Time.deltaTime;
		//if (timer >= 1)
		//{
		//	limitTime -= 1;
		//	tbTime.text = "Time: " + limitTime.ToString();
			
		//	timer = 0;
		//	healthBarFill.fillAmount = playerHealth.currentHealth / 100f;
		//}
		tbScore.text = "Score: " + playerAttack.playerScore;
		healthBarFill.fillAmount = playerHealth.currentHealth / 100f;

		//if (limitTime == 0)
		//{
		//	Time.timeScale = 0;
		//	gameObject.SetActive(false);
		//	endUIController.SetUp();
		//}
	}

	public void PauseButtonClick()
	{
		if (isPaused) ResumeGame();
		else PauseGame();
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		isPaused = true;
		txtPausedButton.text = "Resume";
	}

	public void ResumeGame()
	{
		isPaused = false;
		txtPausedButton.text = "Pause";
		Time.timeScale = 1;
	}

	public void RestartOnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void ShopOnClick()
	{
		shopController.SetUp();
	}

	public void deactive()
	{
		this.gameObject.SetActive(false);
	}

	public void active()
	{
		this.gameObject.SetActive(true);
	}
}
