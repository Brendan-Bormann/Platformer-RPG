using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaWell : MonoBehaviour {

	[SerializeField] private float regenAmount;
	[SerializeField] private float regenRate;

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
				user.GetComponent<Stats>().currentMana += regenAmount;
			}
		}
	}

	
}
