using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pixeye.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue State/New State")]
public class DialogueState : ScriptableObject
{
    [Foldout("Dialogue Information", true)]
    
    [SerializeField] private MultipleDialogue[] dialogues;

    [SerializeField] private string[] givenChoises;

    [SerializeField] private Sprite background;

    [SerializeField]
    private DialogueState[] nextStates;

    public DialogueState[] GetNextDialogueStates()
    {
        return nextStates;
    }

    public MultipleDialogue[] GetCurrentDialogue()
    {
        return dialogues;
    }

    public string[] GetCurrentChoices()
    {
        return givenChoises;
    }

    public Sprite GetCurrentBackground()
    {
        return background;
    }
}
