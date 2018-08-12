using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	[SerializeField] private string name;
	[SerializeField] private float health;

	private Rigidbody2D myRigidBody;

	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Debug.Log("Hello, I am " + name + ".");
		}
	}
}
