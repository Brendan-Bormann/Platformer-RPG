using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTravel : MonoBehaviour
{
	private PlayerManager PlayerManager;

	private Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start()
    {
		PlayerManager = FindObjectOfType<PlayerManager>();
		myRigidBody = GetComponent<Rigidbody2D>();
		myRigidBody.AddForce(new Vector3(1250, 2, 20));
    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnCollisionEnter2D(Collision2D hit)
	{
		if (hit.collider.tag == "Enemy")
		{
			hit.collider.GetComponent<BasicEnemy>().TakeDamage(PlayerManager.DamageCalculation);
		}
		Destroy(gameObject);
	}
}
