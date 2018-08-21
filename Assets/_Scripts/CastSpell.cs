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

		// for (int i = 0; i < spells.Length - 1; i++)
		// {
		// 	StartCoroutine(updateCooldown(i, spells[0].GetComponent<SpellTravel>().coolDown));
		// }

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[0].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[0], transform.position, Quaternion.identity);
			spellsUI[0].GetComponent<Image>().fillAmount = 0;
			StartCoroutine(updateCooldown(0, spells[0].GetComponent<SpellTravel>().coolDown));
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[1].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[1], transform.position, Quaternion.identity);
			spellsUI[1].GetComponent<Image>().fillAmount = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[2].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[2], transform.position, Quaternion.identity);
			spellsUI[2].GetComponent<Image>().fillAmount = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			gameObject.GetComponent<Stats>().currentMana -= spells[3].GetComponent<SpellTravel>().myManaCost;
			Instantiate(spells[3], transform.position, Quaternion.identity);
		}
	}

	private IEnumerator updateCooldown(int i, float duration)
	{
		for (int j = 0; j < duration; j++)
		{
			yield return new WaitForSeconds(1);
			var oldFill = spellsUI[i].GetComponent<Image>().fillAmount;
			spellsUI[i].GetComponent<Image>().fillAmount = Mathf.Lerp(oldFill, j / duration, 0.5f);
		}
	}
}
