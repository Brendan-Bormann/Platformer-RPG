﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

	[SerializeField] private GameObject PlayerBrain;
	private PlayerManager PlayerManager;

	[Header("Stats")]
	// Personal stats
	[SerializeField] private string enemyName;
	[SerializeField] public int health = 1;
	[SerializeField] public float speed = 1;
	[SerializeField] public int damage = 5;


	[Header("Physics")]
	[SerializeField] private float collisionDistance = 1f;
	private Rigidbody2D myRigidBody;
	[SerializeField] private float moveDirection = -1f;
	[SerializeField] private LayerMask layerMask;

	void Start ()
	{
		PlayerManager = PlayerBrain.GetComponent<PlayerManager>();
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		Move();
		CheckHealth();
	}

	private void Move()
	{
		myRigidBody.velocity = new Vector2(moveDirection * speed, myRigidBody.velocity.y);

		Debug.DrawLine(transform.position, new Vector2(transform.position.x + (moveDirection * 3f), transform.position.y), Color.cyan);
		
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

	private void Flip()
	{
		if (moveDirection > 0)
		{
			GetComponent<SpriteRenderer>().flipX = true;
			moveDirection = -1;
		}
		else
		{
			GetComponent<SpriteRenderer>().flipX = false;
			moveDirection = 1;
		}
	}

	public void CheckHealth()
	{
		if (!(health > 0))
		{
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}
}
