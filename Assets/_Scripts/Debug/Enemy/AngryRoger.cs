using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryRoger : MonoBehaviour
{

	private BasicEnemy myScript;
	private int myHealth;
	private int myMaxHealth;

	[Header("Special")]
	[SerializeField] private int regen = 2;
	[SerializeField] private float regenSpeed = 2;

	[SerializeField] private float timer = 0.01f;

	[SerializeField] private GameObject nextArea;

    // Use this for initialization
    void Start()
    {
		myScript = GetComponent<BasicEnemy>();
		myMaxHealth = myScript.health;
    }

    // Update is called once per frame
    void Update()
    {
		myHealth = myScript.health;

		if ((float)myHealth/(float)myMaxHealth < 0.5f)
		{
			timer += Time.deltaTime;
			if (timer >= regenSpeed && myScript.health > 0)
			{
				myScript.health += regen;
				timer = 0;
			}
			

			myScript.collisionDistance = 1.5f;
			myScript.speed = 10;
			Vector3 newSize = new Vector3(2, 2f, 1);
			transform.localScale = Vector3.Lerp(transform.localScale, newSize, Time.deltaTime);
			
		}
		else
		{
			myScript.collisionDistance = 0.5f;
			myScript.speed = 7.5f;
			Vector3 newSize = new Vector3(1, 1, 1);
			transform.localScale = Vector3.Lerp(transform.localScale, newSize, Time.deltaTime);
		}

		if (myHealth <= 0)
		{
			nextArea.SetActive(true);
		}
    }
}
