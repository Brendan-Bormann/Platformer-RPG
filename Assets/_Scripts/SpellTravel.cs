using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTravel : MonoBehaviour {

	[SerializeField] private Rigidbody2D myRigidBody;

	private Vector3 destination;
	private Vector2 startLocation;
	private float timeCastAt;

	[SerializeField] private float speed;
	[SerializeField] private float lifeTime = 1f;


	[SerializeField] private bool doesSpin;
	private int myCurrentSpin;
	[SerializeField] private int spinSpeed;

	private Vector2 direction;

	// Use this for initialization
	void Start ()
	{
		// reference my rigidbody
		myRigidBody = GetComponent<Rigidbody2D>();

		// get mouse position
		destination = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		
		// start time, so i can kill it after seconds
		timeCastAt = Time.time;

		// find direction to target
		direction = destination - myRigidBody.transform.position;
		direction.Normalize();

		// random starting rotation
		myCurrentSpin = (int) Random.Range(-360.0f, 360.0f);
	}
	void Update ()
	{
		// move the projectile
		myRigidBody.velocity = direction * speed;

		// Set correct angle according ti cast angle
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// step through spin during frames
		if (doesSpin)
		{
			myCurrentSpin += spinSpeed;
			angle = myCurrentSpin;
		}

		// apply angle or spin
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		// Time from cast deletes object
		if (Time.time > timeCastAt + lifeTime)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
		// kill self on collision
		Destroy(gameObject);

		if (hit.collider.tag == "Enemy")
		{
			hit.collider.GetComponent<Enemy>().health -= 5;
		}
	}
}
