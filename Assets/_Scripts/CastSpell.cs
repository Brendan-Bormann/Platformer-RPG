using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

	[SerializeField] private GameObject[] spells;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			gameObject.GetComponent<Stats>().currentMana -= 5;
			Instantiate(spells[0], transform.position, Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			gameObject.GetComponent<Stats>().currentMana -= 5;
			Instantiate(spells[1], transform.position, Quaternion.identity);
		}
	}
}
