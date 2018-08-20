using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] public float movementSpeed;
	
	
	[SerializeField] public float jumpPower;
	private bool jumpLocked = false;
	[SerializeField] private float fallMultiplier = 2.5f;
	[SerializeField] private float lowJumpMultiplier = 2f;

	[SerializeField] private float groundedCollisionDistance = 1.2f;

	private Rigidbody2D myRigidBody;

	[SerializeField] private GameObject LeftFoot;
	[SerializeField] private GameObject RightFoot;

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

	private void HandleMovement(float horizontal)
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && !jumpLocked)
		{
			Jump(horizontal);
		}

		myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
	}

	private bool isGrounded()
	{
		RaycastHit2D RightFootRay = Physics2D.Raycast(RightFoot.transform.position, Vector2.down);
		RaycastHit2D LeftFootRay = Physics2D.Raycast(LeftFoot.transform.position, Vector2.down);

		if (RightFootRay.distance < groundedCollisionDistance || LeftFootRay.distance < groundedCollisionDistance)
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
		myRigidBody.velocity = Vector2.zero;
		myRigidBody.AddForce(transform.up * jumpPower);

		StopCoroutine(JumpLock());
		StartCoroutine(JumpLock());
	}

	private IEnumerator JumpLock()
	{
		jumpLocked = true;
		yield return new WaitForSeconds(0.1f);
		jumpLocked = false;
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