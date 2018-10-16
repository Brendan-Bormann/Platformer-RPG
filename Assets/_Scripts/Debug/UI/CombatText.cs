using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatText : MonoBehaviour {

	[SerializeField] private string damage = "123456";
	[SerializeField] private Color color = Color.red;
	[SerializeField] private bool crit = false;
	[SerializeField] private float totalTime = 2f;
	[SerializeField] private float fadeSpeed = 5;
	[SerializeField] private float floatSpeed = 0.05f;

	private TextMeshPro textmesh;

	private float time;

	private bool start = false;

	public void init(int newDamage, Color newColor, bool newCrit)
	{
		damage = newDamage.ToString();
		color = newColor;
		crit = newCrit;

		textmesh = GetComponent<TextMeshPro>();
		textmesh.text = damage;
		textmesh.color = color;
		start = true;
	}

	public void initText(string message, Color newColor)
	{
		damage = message;
		color = newColor;

		textmesh = GetComponent<TextMeshPro>();
		textmesh.text = damage;
		textmesh.color = color;
		start = true;
	}
	

	void Update ()
	{
		if (start)
		{
			textMotion();
		}
		
	}

	void textMotion()
	{
		time += Time.deltaTime;
		
		textmesh.color = Color.Lerp(textmesh.color, Color.clear, fadeSpeed);

		if (time > totalTime)
		{
			Destroy(gameObject);
		}
		else
		{
			transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + 1, floatSpeed));
		}
	}
}
