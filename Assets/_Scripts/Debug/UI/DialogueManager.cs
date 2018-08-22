using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Text nameField;
    [SerializeField] private Text textField;
    private Queue<string> sentances;

    void Start()
    {
        sentances = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
      dialogBox.SetActive(true);
      sentances.Clear();
      nameField.text = dialogue.name;

      foreach (string sentance in dialogue.sentances)
      {
          sentances.Enqueue(sentance);
      }

      DisplayNextSentance();

    }

    public void DisplayNextSentance()
    {
      if (sentances.Count == 0)
      {
        EndDialogue();
        return;
      }

      string sentance = sentances.Dequeue();

      textField.text = sentance;
    }

    void EndDialogue()
    {
      dialogBox.SetActive(false);
    }

}
