﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

	private EnemyManager EnemyManager;
	private PlayerManager PlayerManager;


	[Header("Stats")]
	// Personal stats
	[SerializeField] private string enemyName;
	[SerializeField] public int health = 1;
	[SerializeField] public float speed = 1;
	[SerializeField] public int damage = 5;

	[Header("Sprite Info")]
	[SerializeField] private Sprite deathSprite;


	[Header("Physics")]
	// Physics and raycast related items
	[SerializeField] private float collisionDistance = 1f;
	private Rigidbody2D myRigidBody;
	[SerializeField] private float moveDirection = -1f;
	[SerializeField] private LayerMask layerMask;

	public bool allowedToMove = true;

	void Start ()
	{
		EnemyManager = GameObject.Find("Enemy Brain").GetComponent<EnemyManager>();
		PlayerManager = GameObject.Find("Player Brain").GetComponent<PlayerManager>();
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		if (allowedToMove)
		{
			Move();
		}
		CheckHealth();
	}

	private void Move()
	{
		myRigidBody.velocity = new Vector2(moveDirection * speed, myRigidBody.velocity.y);
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveDirection, 0), 5f, layerMask);
		if (hit.distance <= collisionDistance && hit.collider != null)
		{
			if (hit.collider.name == "Player")
			{
				PlayerManager.TakeDamage(damage);
			}

			Flip();
		}
	}

	private IEnumerator BlockMove(float time)
	{
		yield return new WaitForSeconds(time);
		allowedToMove = true;
	}

	public void toogleMove(float time)
	{
		allowedToMove = false;
		StartCoroutine(BlockMove(time));
	}

	private void Flip()
	{
		if (moveDirection > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
			moveDirection = -1;
		}
		else
		{
			GetComponent<SpriteRenderer>().flipX = true;
			moveDirection = 1;
		}
	}

	public void CheckHealth()
	{
		if (!(health > 0))
		{
			StartCoroutine(Die());
		}
	}

	private IEnumerator Die()
	{
		allowedToMove = false;
		gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
		gameObject.GetComponent<Collider2D>().enabled = false;
		myRigidBody.freezeRotation = false;
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}
}