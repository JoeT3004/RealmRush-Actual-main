using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] //if class enemy health is used this pulls in the Enemy script as it is a required component
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitPoints = 10;

	[Tooltip("Adds amount to maxHit points when enemy dies.")]
	[SerializeField] int difficultyRamp = 1;

	int currentHitPoints = 0;

	Enemy enemy;

	private void Start()
	{
		enemy = GetComponent<Enemy>();
	}

	private void OnEnable()
	{
		currentHitPoints = MaxHitPoints;
	}

	void OnParticleCollision(GameObject other)
	{
		ProcessHit();
	}

	private void ProcessHit()
	{
		currentHitPoints--;

		if (currentHitPoints <= 0)
		{
			gameObject.SetActive(false);
			MaxHitPoints += difficultyRamp;
			enemy.RewardGold();
		}
	}
}
