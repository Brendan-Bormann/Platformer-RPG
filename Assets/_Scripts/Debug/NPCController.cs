﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

	public Dialogue dialogue;
	
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().startDialogue(dialogue);
	}

	void OnTriggerEnter2D()
	{
		Debug.Log("Bye!");
	}

	void OnTriggerStay2D(Collider2D talker)
	{
		if (Input.GetButtonDown("Use") && talker.name == "Player")
		{
			TriggerDialogue();
		}
	}

	void OnTriggerExit2D()
	{
		Debug.Log("Bye!");
	}
}
