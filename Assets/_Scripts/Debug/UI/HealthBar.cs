using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

	[SerializeField] private Image mainBar;
	[SerializeField] private Image secondaryBar;
	[SerializeField] private GameObject healthTextObject;
	private TextMeshProUGUI healthText;

	[SerializeField] private float lerpSpeed = 0.5f;

	private int health;
	private int MaxHealth;

    void Start()
    {
		MaxHealth = GameObject.Find("Player Brain").GetComponent<PlayerManager>().MaxHealth;
		health = MaxHealth;

		healthText = healthTextObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

		healthText.text = health.ToString() + " / " + MaxHealth.ToString();

		var healthRatio = (float)health / (float)MaxHealth;

		mainBar.fillAmount = Mathf.Lerp(mainBar.fillAmount, healthRatio, lerpSpeed * 2);
		secondaryBar.fillAmount = Mathf.Lerp(secondaryBar.fillAmount, mainBar.fillAmount, lerpSpeed);
    }

	public void SetHealth(int newValue)
	{
		health = newValue;
	}
}
