using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] public int health = 100;

	[SerializeField] private bool goingRight = true;
	private Rigidbody2D myRigidBody;

	[SerializeField] private float rayDistance = 2.0f;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		LivingCheck();

		var direction = 0;

		if (goingRight)
		{
			direction = 1;
		}
		else
		{
			direction = -1;
		}

		myRigidBody.velocity = new Vector2(direction * speed, myRigidBody.velocity.y);
		TurnAround();
	}

	private void TurnAround()
	{
		//fix me :(
		RaycastHit2D Lhit = Physics2D.Raycast(myRigidBody.transform.position, Vector2.left);
		RaycastHit2D Rhit = Physics2D.Raycast(myRigidBody.transform.position, Vector2.right);

		// Debug.Log("1" + Rhit.distance);
		// Debug.Log("2" + rayDistance);

		if (Rhit.distance <= rayDistance && goingRight)
		{
			goingRight = false;
		}
		else if (Lhit.distance <= rayDistance && !goingRight)
		{
			goingRight = true;
		}
	}

	private void LivingCheck()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
