using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private PlayerManager PlayerManager;
	private Rigidbody2D MyRigidBody;


	[Header("Gravity Modifer")]
	public bool GravityModifierEnabled = false;
	public float fallMultiplier = 1.5f;
	public float lowJumpMultiplier = 2.1f;

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
			var horizontal = Input.GetAxis("Horizontal");

			// Switch players direction
			if (horizontal >= 0)
			{
				PlayerManager.Player.transform.Rotate(0, 180, 0);
			}
			else if (horizontal <= 0)
			{
				PlayerManager.Player.transform.Rotate(0, 180, 0);
			}

			// Move the Player
			MyRigidBody.velocity = new Vector2(horizontal * PlayerManager.MovementSpeed, MyRigidBody.velocity.y);
		}
		if (Input.GetButtonDown("Jump"))
		{
			MyRigidBody.velocity = Vector2.zero;
			MyRigidBody.AddForce(transform.up * PlayerManager.JumpHeight);
		}

		JumpMod();
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


	private void FlipPlayer(float direction)
	{
		Debug.Log(direction);
		
	}
}
