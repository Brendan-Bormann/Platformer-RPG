using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float movementSpeed;
	
	
	[SerializeField] private float jumpPower;
	[SerializeField] private float fallMultiplier = 2.5f;
	[SerializeField] private float lowJumpMultiplier = 2f;

	[SerializeField] private float groundedCollisionDistance = 1.2f;

	private Rigidbody2D myRigidBody;

	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");

		HandleMovement(horizontal);
		JumpMod();
	}

	// private bool isGrounded()
	// {
	// 	if (myRigidBody.velocity.y <= 0)
	// 	{
	// 		RaycastHit2D hit = RaycastHit2D();
	// 	}
	// }

	private void HandleMovement(float horizontal)
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
		{
			Jump(horizontal);
		}

		myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
	}

	private bool isGrounded()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
		if (hit.distance < groundedCollisionDistance)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void Jump(float horizontal)
	{
		myRigidBody.AddForce(transform.up * jumpPower);
	}

	private void JumpMod()
	{
		if (myRigidBody.velocity.y < 0)
		{
			myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (myRigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
		{
			myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}

}