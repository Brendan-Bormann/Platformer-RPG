using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	// Referances to Player Object
	[SerializeField] public GameObject Player;

	// Name //
	[SerializeField] public string PlayerName = "Player";

	// Health //
	[Header("Health")]
	[SerializeField] public int CurrentHealth = 100;
	[SerializeField] public int MaxHealth = 100;

	// Damage Stats
	[Header("Combat")]
	[SerializeField] public int AttackPower = 10;
	[SerializeField] public int SpellPower = 10;

	// Movement Stats
	[Header("Movement")]
	[SerializeField] public int JumpHeight = 1000;
	[SerializeField] public float MovementSpeed = 8;

	

	
	void Start ()
	{

	}
	
	
	void Update ()
	{
		
	}


	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
	}
}
