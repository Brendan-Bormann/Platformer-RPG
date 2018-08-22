using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	[SerializeField] private Image mainBar;
	[SerializeField] private Image secondaryBar;

	[SerializeField] private float lerpSpeed = 0.5f;

	private int health;
	private int MaxHealth;

    void Start()
    {
		MaxHealth = GameObject.Find("Player Brain").GetComponent<PlayerManager>().MaxHealth;
		health = MaxHealth;
    }

    void Update()
    {
		var healthRatio = (float)health / (float)MaxHealth;

		mainBar.fillAmount = Mathf.Lerp(mainBar.fillAmount, healthRatio, lerpSpeed * 2);
		secondaryBar.fillAmount = Mathf.Lerp(secondaryBar.fillAmount, mainBar.fillAmount, lerpSpeed);
    }

	public void SetHealth(int newValue)
	{
		health = newValue;
	}
}
