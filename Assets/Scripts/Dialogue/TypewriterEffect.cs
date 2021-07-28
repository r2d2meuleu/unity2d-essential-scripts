using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    TMP_Text dialogueText;
    [Range(0, 1)] [SerializeField] float textRevealSpeed = .2f;

    private void Start()
    {
        dialogueText = GetComponent<TMP_Text>();

        if (dialogueText == null) Debug.Log($"No text component was found in {gameObject.name}");
        else StartCoroutine(TypeWriterEffect());
    }

    /// <summary>
    /// Set on a gameObject with the component TMP_Text and set the speed you want each character to reveal; 
    /// This Coroutine reveals the text of 'storyText', so you can add custom tags from the inspector without them glitching mid reveal.
    /// </summary>
    /// <returns></returns>
    public IEnumerator TypeWriterEffect()
    {
        dialogueText.ForceMeshUpdate();

        int totalVisibleCharacters = dialogueText.textInfo.characterCount;

        for (int i = 0; i < totalVisibleCharacters; i++)
        {
            dialogueText.maxVisibleCharacters = i + 1;

            yield return new WaitForSeconds(textRevealSpeed);
        }

        dialogueText.maxVisibleCharacters = totalVisibleCharacters;

        yield break;
    }
}
