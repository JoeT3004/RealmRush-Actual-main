using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    //deposit gold
    public void RewardGold() //could be better to return a boolean value to say if it was successful or not
	{
        if(bank == null) { return; }
        bank.Deposit(goldReward);
	}

    //withdraw gold
    public void StealGold() //could be better to return a boolean value to say if it was successful or not
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }

}
