using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

	[SerializeField] private GameObject destination;

    void OnTriggerStay2D(Collider2D user)
	{
		if (Input.GetKeyDown(KeyCode.W) && user.name == "Player")
		{
			user.transform.position = new Vector2(destination.transform.position.x, destination.transform.position.y);
		}
	}
}
