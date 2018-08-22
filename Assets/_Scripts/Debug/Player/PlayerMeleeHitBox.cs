using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeHitBox : MonoBehaviour
{

	[SerializeField] private GameObject PlayerBrain;
	private PlayerManager PlayerManager;

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
		}
	}
}
