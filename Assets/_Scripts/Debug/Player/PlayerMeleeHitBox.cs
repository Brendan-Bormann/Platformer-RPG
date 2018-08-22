using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeHitBox : MonoBehaviour
{

	[SerializeField] private GameObject PlayerBrain;
	private PlayerManager PlayerManager;

	[SerializeField] private bool knockback = true;

	// Use this for initialization
	void Start ()
	{
		PlayerManager = PlayerBrain.GetComponent<PlayerManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		Debug.Log(hit.name);

		if (hit.tag == "Enemy")
		{
			hit.GetComponent<BasicEnemy>().TakeDamage(PlayerManager.AttackPower);

			if (knockback)
			{
				Rigidbody2D enemyBody = hit.GetComponent<Rigidbody2D>();

				hit.GetComponent<BasicEnemy>().toogleMove(0.75f);

				enemyBody.AddForce(new Vector2(300, 200));
			}
		}
	}
}
