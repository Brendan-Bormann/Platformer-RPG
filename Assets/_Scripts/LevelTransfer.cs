using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransfer : MonoBehaviour {

	[SerializeField] private string sceneName;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	void OnTriggerStay2D(Collider2D user)
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}
