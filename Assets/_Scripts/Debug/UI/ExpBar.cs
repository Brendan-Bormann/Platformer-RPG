using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBar : MonoBehaviour
{

	[SerializeField] private Image mainBar;
	[SerializeField] private GameObject levelTextObject;
	[SerializeField] private GameObject levelPercentObject;
	private TextMeshProUGUI levelText;
	private TextMeshProUGUI levelPercent;
	private int level;

	[SerializeField] private float lerpSpeed = 0.5f;

	private int CurrentExp;
	private int ExpToLevel;

    void Start()
    {
		CurrentExp = FindObjectOfType<PlayerManager>().CurrentExp;
		ExpToLevel = FindObjectOfType<PlayerManager>().ExpToLevel;
		level = FindObjectOfType<PlayerManager>().CurrentLevel;
		levelText = levelTextObject.GetComponent<TextMeshProUGUI>();
		levelPercent = levelPercentObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
		var expRatio = (float)CurrentExp / (float)ExpToLevel;

		var expPercentage = expRatio * 100;

		levelPercent.text = Mathf.Round(expPercentage).ToString() + "%";

		mainBar.fillAmount = Mathf.Lerp(mainBar.fillAmount, expRatio, lerpSpeed);

		levelText.text = "Lv. " + level.ToString();
    }

	public void SetExp(int newExp, int newExpToLevel)
	{
		CurrentExp = newExp;
		ExpToLevel = newExpToLevel;
	}
	public void SetLevel(int newValue)
	{
		level = newValue;
	}
}

