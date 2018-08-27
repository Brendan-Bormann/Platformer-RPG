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
	[SerializeField] public int baseExp = 100;
	[SerializeField] public int ExpToLevel = 0;
	[SerializeField] public float levelFactor = 1.4f;
	[SerializeField] public int CurrentLevel = 1;

	// Damage Stats
	[Header("Combat")]
	[SerializeField] public int Power = 10;
	[SerializeField] public int critChancePercent = 5;
	[SerializeField] public float critDamageMod = 1.2f;
	[SerializeField] public float recoveryTime;
	[SerializeField] private float recoveryTimer = 0;
	[SerializeField] private bool inRecoveryTime = false;

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
	private UIManager UIManager;
	

	
	void Start ()
	{
		// init UI
		UIManager = UIBrain.GetComponent<UIManager>();
		// init health and exp bar
		HealthBarController = UIBrain.GetComponent<HealthBar>();
		ExpBarController = UIBrain.GetComponent<ExpBar>();
		// remove spawn point from edit mode
		SpawnPoint.GetComponent<SpriteRenderer>().enabled = false;
		// set the player to the spawn point location
		Player.transform.position = SpawnPoint.position;
	}
	
	
	void Update ()
	{

		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

		ExpToLevel = (int)Mathf.Round(baseExp * (Mathf.Pow(CurrentLevel, levelFactor)));
		HealthBarController.SetHealth(CurrentHealth);
		CheckHealth();
		ExpBarController.SetExp(CurrentExp, ExpToLevel);
		ExpBarController.SetLevel(CurrentLevel);
		healthDebug();
		LevelUp();

		if (inRecoveryTime)
		{
			recoveryTimer += Time.deltaTime;
			if (recoveryTime <= recoveryTimer)
			{
				inRecoveryTime = false;
				recoveryTimer = 0;
			}
		}
	}

	// health loss calculation
	public void TakeDamage(int damage)
	{
		if (!inRecoveryTime)
		{
			CurrentHealth -= damage;
			inRecoveryTime = true;
		}
	}

	// exp gain
	public void GainExp(int exp)
	{
		CurrentExp += exp;
	}

	// dev controls for health and exp gain
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
			GainExp(ExpToLevel/10);
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
			UIManager.SpawnText(new Vector2(Player.transform.position.x, Player.transform.position.y + 1), "Level Up!", Color.yellow);
			CurrentLevel++;
			CurrentExp -= ExpToLevel;
			ExpToLevel =  (int)(ExpToLevel * 1.2f);
		}
	}
}
