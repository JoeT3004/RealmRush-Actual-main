using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
	[SerializeField] int currentBalance;

	[SerializeField] TextMeshProUGUI displayBalance;

	public int CurrentBalance
	{
		get
		{
            return currentBalance;
		}
	}

	private void Awake()
	{
		currentBalance = startingBalance;
		UIupdateGold();
	}

	public void Deposit(int amount)
	{
		currentBalance += Mathf.Abs(amount); //mathf.abs switches positive into a negative
		UIupdateGold();
	}

	void UIupdateGold()
	{
		displayBalance.text = "Gold: " + currentBalance;
	}

	public void Withdraw(int amount)
	{
		currentBalance -= Mathf.Abs(amount);
		UIupdateGold();

		if (currentBalance <= 0)
		{
			//SceneManager.LoadScene(0); USE THIS AS A PROTOTYPE .getactivescene is better
			Scene currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.buildIndex);
		}

	}
}
