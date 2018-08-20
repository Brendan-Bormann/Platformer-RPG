using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastSpell : MonoBehaviour {

	[SerializeField] private GameObject[] spells;

	[SerializeField] private GameObject[] spellsUI;

	[SerializeField] private bool[] spellsCooldown;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1) && spellsCooldown[0])
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[0].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[0], transform.position, Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[1].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[1], transform.position, Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[2].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[2], transform.position, Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[3].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[3], transform.position, Quaternion.identity);
		}
	}
}
