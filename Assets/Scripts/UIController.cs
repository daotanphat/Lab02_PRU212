using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] Text tbTime;
	[SerializeField] int limitTime;
	[SerializeField] Button pauseButon;
	[SerializeField] Image healthBarFill;
	float timer = 0;
	float damage;
	bool isPaused = false;
	Text txtPausedButton;
	// Start is called before the first frame update
	void Start()
	{
		tbTime.text = "Time: " + limitTime.ToString();
		txtPausedButton = pauseButon.GetComponentInChildren<Text>();
		healthBarFill.fillAmount = 1;
		damage = 1.0f / limitTime;
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 1)
		{
			limitTime -= 1;
			tbTime.text = "Time: " + limitTime.ToString();
			timer = 0;
			healthBarFill.fillAmount -= damage;
		}
		if (limitTime == 0)
		{
			Time.timeScale = 0;
		}
	}

	public void PauseButtonClick()
	{
		if (isPaused) ResumeGame();
		else PauseGame();
	}

	public void PauseGame()
	{
		isPaused = true;
		txtPausedButton.text = "Resume";
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		isPaused = false;
		txtPausedButton.text = "Pause";
		Time.timeScale = 1;
	}
}
