using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private PlayerManager PlayerManager;
	private Rigidbody2D MyRigidBody;
	
	public float direction;


	[Header("Gravity Modifer")]
	public bool GravityModifierEnabled = false;
	public float fallMultiplier = 1.5f;
	public float lowJumpMultiplier = 2.1f;

	[Header("Feet Location")]
	public GameObject leftFoot;
	public GameObject rightFoot;
	public float groundedDistance = 1.0f;

	

	void Start ()
	{
		PlayerManager = GetComponent<PlayerManager>();
		MyRigidBody = PlayerManager.Player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButton("Horizontal"))
		{
			// Get input for players direction
			direction = Input.GetAxis("Horizontal");

			// Switch players direction
			FlipPlayer(direction);

			// Move the Player
			MyRigidBody.velocity = new Vector2(direction * PlayerManager.MovementSpeed, MyRigidBody.velocity.y);
		}
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			MyRigidBody.velocity = Vector2.zero;
			MyRigidBody.AddForce(transform.up * PlayerManager.JumpHeight);
		}

		JumpMod();
	}

	private bool IsGrounded()
	{
		RaycastHit2D left = Physics2D.Raycast(leftFoot.transform.position, Vector2.down);
		RaycastHit2D right = Physics2D.Raycast(rightFoot.transform.position, Vector2.down);

		if ((left.distance < groundedDistance || left.distance < groundedDistance) && (left.distance != 0 && left.distance != 0))
		{
			return true;
		}

		return false;		
	}

	private void JumpMod()
	{
		if (GravityModifierEnabled)
		{
			if (MyRigidBody.velocity.y < 0)
			{
				MyRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			}
			else if (MyRigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
			{
				MyRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
			}
		}
	}


	private void FlipPlayer(float horizontal)
	{
		if (horizontal > 0)
		{
			PlayerManager.Player.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (horizontal < 0)
		{
			PlayerManager.Player.GetComponent<SpriteRenderer>().flipX = false;
		}
	}
}
