using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

	private EnemyManager EnemyManager;
	private PlayerManager PlayerManager;
	private UIManager UIManager;


	[Header("Stats")]
	// Personal stats
	[SerializeField] private string enemyName;
	[SerializeField] public int health = 1;
	[SerializeField] public float speed = 1;
	[SerializeField] public int damage = 5;
	[SerializeField] public int defence = 0;
	[SerializeField] public int ExpValue = 5;

	[Header("Sprite Info")]
	[SerializeField] private Sprite deathSprite;


	[Header("Physics")]
	// Physics and raycast related items
	[SerializeField] public float collisionDistance = 1f;
	private Rigidbody2D myRigidBody;
	[SerializeField] private float moveDirection = -1f;
	[SerializeField] private LayerMask layerMask;

	public bool allowedToMove = true;
	private bool isDead = false;

	void Start ()
	{
		EnemyManager = FindObjectOfType<EnemyManager>();
		PlayerManager = FindObjectOfType<PlayerManager>();
		UIManager = FindObjectOfType<UIManager>();
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

	public void toggleMove(float time)
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
		if (!(health > 0) && !isDead)
		{
			StartCoroutine(Die());
		}
	}

	private IEnumerator Die()
	{
		isDead = true;
		StopAllCoroutines();
		allowedToMove = false;
		gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
		gameObject.GetComponent<Collider2D>().enabled = false;
		myRigidBody.velocity = Vector2.zero;
		PlayerManager.CurrentExp += ExpValue;
		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);
	}

	public void TakeDamage(int incomingDamage)
	{
		incomingDamage -= defence;
		
		UIManager.SpawnCombatText(transform.position, incomingDamage, Color.red, false);

		health -= incomingDamage;
	}
}
