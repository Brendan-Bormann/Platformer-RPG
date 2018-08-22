using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private GameObject PlayerBrain;
	public PlayerManager PlayerManager;
	[SerializeField] private GameObject[] enemies;

	[SerializeField] private GameObject EnemyBounds;
	

	// Use this for initialization
	void Start ()
	{
		PlayerManager = PlayerBrain.GetComponent<PlayerManager>();

		foreach (Transform child in EnemyBounds.transform)
    		child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

