using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue State/New Dialogue")]
public class MultipleDialogue : ScriptableObject
{
    [SerializeField] private string talkingCharacter;
    [TextArea(10, 14)] [SerializeField] private string dialogue;
    [SerializeField] private Sprite talkingCharacterImage;
    [SerializeField] private Sprite secondCharacterImage;
    
    public string GetCharacterName()
    {
        return talkingCharacter;
    }

    public string GetDialogue()
    {
        return dialogue;
    }

    public Sprite GetCharacterImage()
    {
        return talkingCharacterImage;
    }
    
    public Sprite GetSecondCharacterImage()
    {
        return secondCharacterImage;
    }
}
