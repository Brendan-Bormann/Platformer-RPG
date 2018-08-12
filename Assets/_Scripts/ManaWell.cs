using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaWell : MonoBehaviour {

	[SerializeField] private float regenAmount = 1.0f;
	[SerializeField] private float regenRate = 1.0f;

	void OnCollisionEnter2D(Collision2D user)
	{
		Debug.Log("Working");
	}

	void OnCollisionExit2D(Collision2D user)
	{
		Debug.Log("Bye!");
	}
	
}
