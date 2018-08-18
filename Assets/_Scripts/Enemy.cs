using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] public float health = 100;

	[SerializeField] private float xMoveDirection = 1f;
	private Rigidbody2D myRigidBody;

	[SerializeField] private float rayDistance = 2.0f;

	[SerializeField] private float collisionDistance = 1f;

	[SerializeField] private LayerMask layerMask;

	[SerializeField] private GameObject Player;

	[SerializeField] private GameObject[] enemySpells;
	[SerializeField] private float attackDistance = 10f;

	[SerializeField] private float attackCooldown = 1f;

	private bool attackedRecently;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		LivingCheck();

		Pathing();

		if (playerNear())
		{
			attackPlayer();
		}
	}

	private void Pathing()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0), Mathf.Infinity, layerMask);

		myRigidBody.velocity = new Vector2(xMoveDirection * speed, myRigidBody.velocity.y);

		if (hit.distance <= collisionDistance) {
			Flip();
		}
	}

	private void Flip()
	{
		if (xMoveDirection > 0) {
			xMoveDirection = -1;
		} else {
			xMoveDirection = 1;
		}
	}

	private void LivingCheck()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	private bool playerNear()
	{
		var distance = Vector2.Distance(Player.transform.position, transform.position);

		if (distance < attackDistance)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void attackPlayer()
	{
		if (!attackedRecently)
		{
			Instantiate(enemySpells[0], transform.position, Quaternion.identity);
			StartCoroutine(attackCooldownStart());
		}
	}

	private IEnumerator attackCooldownStart()
	{
		attackedRecently = true;
		yield return new WaitForSeconds(attackCooldown);
		attackedRecently = false;
	}
}
