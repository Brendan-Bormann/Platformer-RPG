using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
	// Referances to Player Object
	[SerializeField] public GameObject Player;

	[SerializeField] public Transform SpawnPoint;

	// Name //
	[SerializeField] public string PlayerName = "Player";

	// Health //
	[Header("Health")]
	[SerializeField] public int CurrentHealth = 100;
	[SerializeField] public int MaxHealth = 100;

	// Damage Stats
	[Header("Combat")]
	[SerializeField] public int Power = 10;
	[SerializeField] public int critChancePercent = 5;
	[SerializeField] public float critDamageMod = 1.2f;

	public int DamageCalculation
	{
		get
		{
			if (Random.Range(1, 101) < critChancePercent) return (int)((float)Power * critDamageMod);
			else return Power;
		}
	}

	// Movement Stats
	[Header("Movement")]
	[SerializeField] public int JumpHeight = 1000;
	[SerializeField] public float MovementSpeed = 8;

	[Header("UI")]
	[SerializeField] private GameObject UIBrain;
	private HealthBar HealthBarController;
	

	
	void Start ()
	{
		HealthBarController = UIBrain.GetComponent<HealthBar>();
		SpawnPoint.GetComponent<SpriteRenderer>().enabled = false;
		Player.transform.position = SpawnPoint.position;
	}
	
	
	void Update ()
	{
		HealthBarController.SetHealth(CurrentHealth);
		healthDebug();
	}


	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
	}

	void healthDebug()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			CurrentHealth -= 10;
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			CurrentHealth += 10;
		}
	}

	void CheckHealth()
	{
		if (Player.transform.position.y < -20)
		{
			PlayerDie();
		}
		if (CurrentHealth <= 0)
		{
			PlayerDie();
		}
	}

	void PlayerDie()
	{
		Scene thisScene = SceneManager.GetActiveScene();
		SceneManager.SetActiveScene(thisScene);
	}
}
