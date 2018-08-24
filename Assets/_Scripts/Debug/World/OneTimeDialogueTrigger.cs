using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeDialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	private void OnTriggerEnter2D(Collider2D other)
	{
		FindObjectOfType<DialogueManager>().startDialogue(dialogue);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		
	}

}
