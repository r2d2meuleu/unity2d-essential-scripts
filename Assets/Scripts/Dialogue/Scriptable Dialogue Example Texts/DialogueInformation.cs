using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueInformation : ScriptableObject
{
    [SerializeField] string talkingCharacter;
    [TextArea(10, 14)] [SerializeField] string dialogueText;

    public string GetTalkingCharacterName()
    {
        return talkingCharacter;
    }

    public string GetDialogueText()
    {
        return dialogueText;
    }
}
