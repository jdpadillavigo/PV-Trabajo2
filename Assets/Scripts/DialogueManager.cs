using System;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public DialogueRunner DialogueRunner;
    public String StartNode;

    public void StartDialogue()
    {
        DialogueRunner.StartDialogue(StartNode);
    }
}
