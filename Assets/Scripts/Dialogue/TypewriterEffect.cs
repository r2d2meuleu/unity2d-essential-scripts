using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    TMP_Text dialogueText;
    [Range(0, 1)] [SerializeField] float textRevealSpeed;

    private void Start()
    {
        dialogueText = GetComponent<TMP_Text>();

        if (dialogueText == null) Debug.Log($"No text component was found in {gameObject.name}");
        else StartCoroutine(TypeWriter());
    }

    /// <summary>
    /// This Coroutine reaveals the text of 'storyText', so you can add custom tags from the inspector without them glitching mid reveal.
    /// </summary>
    /// <returns></returns>
    public IEnumerator TypeWriter()
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
