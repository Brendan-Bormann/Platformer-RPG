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
	[Header("Status")]
	[SerializeField] public int CurrentHealth = 100;
	[SerializeField] public int MaxHealth = 100;

	[SerializeField] public int CurrentExp = 0;
	[SerializeField] public int ExpToLevel = 83 * CurrentLevel * 2;
	[SerializeField] public int CurrentLevel = 1;

	// Damage Stats
	[Header("Combat")]
	[SerializeField] public int Power = 10;
	[SerializeField] public int critChancePercent = 5;
	[SerializeField] public float critDamageMod = 1.2f;

	public int DamageCalculation
	{
		get
		{
			var randomizedPower =  (Power * Random.Range(80, 121)) / 100;
			if (Random.Range(1, 101) < critChancePercent) return (int)((float)randomizedPower * critDamageMod);
			else return randomizedPower;
		}
	}

	// Movement Stats
	[Header("Movement")]
	[SerializeField] public int JumpHeight = 1000;
	[SerializeField] public float MovementSpeed = 8;

	[Header("UI")]
	[SerializeField] private GameObject UIBrain;
	private HealthBar HealthBarController;
	private ExpBar ExpBarController;
	

	
	void Start ()
	{
		HealthBarController = UIBrain.GetComponent<HealthBar>();
		ExpBarController = UIBrain.GetComponent<ExpBar>();
		SpawnPoint.GetComponent<SpriteRenderer>().enabled = false;
		Player.transform.position = SpawnPoint.position;
	}
	
	
	void Update ()
	{
		HealthBarController.SetHealth(CurrentHealth);
		CheckHealth();
		ExpBarController.SetExp(CurrentExp, ExpToLevel);
		ExpBarController.SetLevel(CurrentLevel);
		healthDebug();
		LevelUp();
	}


	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
	}

	public void GainExp(int exp)
	{
		CurrentExp += exp;
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
		if (Input.GetKeyDown(KeyCode.P))
		{
			GainExp(10);
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

	void LevelUp()
	{
		if (CurrentExp >= ExpToLevel)
		{
			CurrentLevel++;
			CurrentExp -= ExpToLevel;
			ExpToLevel =  (int)(ExpToLevel * 1.2f);
		}
	}
}
