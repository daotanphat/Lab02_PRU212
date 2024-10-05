using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
	[SerializeField] Text tbPlayerScore;
	[SerializeField] PlayerAttack playerAttack;
	int playerScore;

	public void SetUp()
	{
		gameObject.SetActive(true);
		playerScore = playerAttack.playerScore;
		tbPlayerScore.text = "Your Score: " + playerScore;
	}

	public void RestartOnClick()
	{
		SceneManager.LoadScene("SampleScene");
	}
}
