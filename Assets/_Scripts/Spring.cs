﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

	[SerializeField] private float regenAmount;
	[SerializeField] private float regenRate;

	[SerializeField] private bool health = false;
	[SerializeField] private bool mana = false;

	private bool inWater = false;

	void OnTriggerEnter2D(Collider2D user)
	{
		
		if (user.tag == "Player")
		{
			inWater = true;
			Debug.Log("Working");
			StartCoroutine(RegenerateMana(user));
		}
	}

	void OnTriggerExit2D(Collider2D user)
	{
		
		if (user.tag == "Player")
		{
			inWater = false;
			Debug.Log("Bye!");
			StopCoroutine(RegenerateMana(user));
		}
	}

	private IEnumerator RegenerateMana(Collider2D user)
	{
		while (inWater)
		{
			yield return new WaitForSeconds(regenRate);
			if (user.tag == "Player")
			{
				if (health == true)
				{
					user.GetComponent<Stats>().currentHealth += regenAmount;
				}
				if (mana == true)
				{
					user.GetComponent<Stats>().currentMana += regenAmount;
				}
			}
		}
	}

	
}

