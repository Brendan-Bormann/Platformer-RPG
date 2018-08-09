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

	[SerializeField] private int myCurrentSpin;
	[SerializeField] private int spinSpeed;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		startLocation = transform.position;
		timeCastAt = Time.time;
	}
	void Update ()
	{

		Vector2 direction = (destination * 20) - transform.position;
		myRigidBody.velocity = direction.normalized * speed;
		
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		if (myCurrentSpin != 0)
		{
			myCurrentSpin += spinSpeed;
			angle = myCurrentSpin;
		}

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		// Time from cast deletes object
		if (Time.time > timeCastAt + lifeTime)
		{
			Destroy(gameObject);
		}

		// else if (GetComponent<CircleCollider2D>().IsTouching(GameObject.FindGameObjectWithTag("Enemy").GetComponent<CircleCollider2D>()))
		// {
		// 	Destroy(gameObject);
		// }
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
		Destroy(gameObject);

		if (hit.collider.tag == "Enemy")
		{
			hit.collider.GetComponent<Enemy>().health -= 5;
		}
	}
}
