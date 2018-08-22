using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

	private PlayerManager PlayerManager;
	private GameObject Player;

	private float PlayerDirection;

	private enum dir
	{
		Right,
		Left,
	}

	[SerializeField] private dir PlayerPersistantDirection;

	[SerializeField] private GameObject LeftHitBox;
	[SerializeField] private GameObject RightHitBox;
	[SerializeField] private GameObject UpHitBox;
	[SerializeField] private float AttackSpeed = 1.0f;
	[SerializeField] private bool AttackReady = true;

	void Start ()
	{
		PlayerManager = GetComponent<PlayerManager>();
		Player = PlayerManager.Player;
	}
	
	void Update ()
	{
		PlayerDirection = Input.GetAxis("Horizontal");

		if (PlayerDirection < 0)
		{
			PlayerPersistantDirection = dir.Left;
		}
		else if (PlayerDirection > 0)
		{
			PlayerPersistantDirection = dir.Right;
		}

		if (Input.GetButtonDown("Attack") && AttackReady)
		{
			StartCoroutine(BasicAttack());
		}
	}

	private IEnumerator BasicAttack()
	{
		
		var HitBox = RightHitBox;

		if (PlayerPersistantDirection == dir.Left)
		{
			HitBox = LeftHitBox;
		}

		// Prevent Player from attacking again
		AttackReady = false;

		Player.GetComponent<Animator>().SetBool("Attacking", true);
		// Turn on hitbox for time
		HitBox.SetActive(true);
		yield return new WaitForSeconds(0.25f);
		HitBox.SetActive(false);

		Player.GetComponent<Animator>().SetBool("Attacking", false);

		// Wait time and get ready for another attack
		yield return new WaitForSeconds(AttackSpeed);
		AttackReady = true;
	}
}
