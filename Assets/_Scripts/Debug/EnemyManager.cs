using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private GameObject PlayerBrain;
	public PlayerManager PlayerManager;
	[SerializeField] private GameObject[] enemies;
	

	// Use this for initialization
	void Start ()
	{
		PlayerManager = PlayerBrain.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
