using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	[SerializeField] public float currentHealth;
	[SerializeField] private float maxHealth;
	[SerializeField] public float currentMana;
	[SerializeField] private float maxMana;


	[SerializeField] private GameObject healthBar;
	[SerializeField] private GameObject shadedHealthBar;
	[SerializeField] private GameObject manaBar;
	[SerializeField] private GameObject shadedManaBar;

	[SerializeField] private float lerpSpeed = 1.0f;
	private float oldHealth;
	private float oldMana;



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		HealthManaBarHandler();
	}

	void HealthManaBarHandler()
	{
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		currentMana = Mathf.Clamp(currentMana, 0, maxMana);

		healthManaDebug();

		healthBar.GetComponent<Image>().fillAmount = Mathf.Lerp(healthBar.GetComponent<Image>().fillAmount, currentHealth / maxHealth, lerpSpeed * 2);
		manaBar.GetComponent<Image>().fillAmount = Mathf.Lerp(manaBar.GetComponent<Image>().fillAmount, currentMana / maxMana, lerpSpeed * 2);

		if (shadedHealthBar.GetComponent<Image>().fillAmount != healthBar.GetComponent<Image>().fillAmount)
		{
			shadedHealthBar.GetComponent<Image>().fillAmount = Mathf.Lerp(shadedHealthBar.GetComponent<Image>().fillAmount, healthBar.GetComponent<Image>().fillAmount, lerpSpeed);
		}

		if (shadedManaBar.GetComponent<Image>().fillAmount != manaBar.GetComponent<Image>().fillAmount)
		{
			shadedManaBar.GetComponent<Image>().fillAmount = Mathf.Lerp(shadedManaBar.GetComponent<Image>().fillAmount, manaBar.GetComponent<Image>().fillAmount, lerpSpeed);
		}

		oldHealth = currentHealth;
		oldMana = currentMana;

	}


	void healthManaDebug()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			currentHealth -= 10;
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			currentHealth += 10;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			currentMana -= 10;
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			currentMana += 10;
		}
	}
}
