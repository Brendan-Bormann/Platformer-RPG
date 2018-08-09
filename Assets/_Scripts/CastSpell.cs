using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

	[SerializeField] private GameObject spell;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Instantiate(spell, transform.position, Quaternion.identity);
		}
	}
}
