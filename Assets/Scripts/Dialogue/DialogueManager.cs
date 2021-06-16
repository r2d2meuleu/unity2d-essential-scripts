using System.Collections;
using TMPro;
using UnityEngine;
using Pixeye.Unity;

public class DialogueManager : MonoBehaviour
{
    [Foldout("Dialogue Components", true)]
    [SerializeField] TMP_Text characterName;
    [SerializeField] TMP_Text dialogueText;

    [Foldout("Dialogue Settings", true)]
    [SerializeField] KeyCode dialogueProgressKey;

    [SerializeField] DialogueInformation[] dialogues; //to create a dialogue information right click on an empty folder and from the menu select "Dialogue" on top
    [Range(0, .2f)] [SerializeField] float textRevealSpeed; // Set how much time to wait before revealing a char

    bool proceedWithNextLine; // Stops the player from interrupting the dialogue mid sentence
    int lineCount = 0; // Shows the text of the current Dialogue information selected, leave it to 0
    bool useLines;

    void Start()
    {
        if (characterName == null)
        {
            Debug.Log($"No character name selected in '{gameObject.name}'");
        }

        if (dialogueText == null)
        {
            Debug.Log($"No dialogue text selected in '{gameObject.name}'");
        }

        #region This code initialises the dialogue panel, it passes the first line to play and executes the TypeWriter Coroutine, or if you don't want to play multiple dialogues, it just takes the line from the TMP_Text component attached

        if (dialogues.Length > 0) // If you want multiple dialogues to be used 
        {
            useLines = true;
            dialogueText.text = dialogues[lineCount].GetDialogueText();
            characterName.text = dialogues[lineCount].GetTalkingCharacterName();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues.Length == 0) // This is for using the text in the TMP_Text component
        {
            useLines = false;
            StartCoroutine(TypeWriter());
        }

        #endregion
    }

    private void Update()
    {
        #region This is an example of how you can use the TypeWriter coroutine to make a dialogue between characters, comment out if unnecessary

        if (Input.GetKeyDown(dialogueProgressKey) && proceedWithNextLine && lineCount < dialogues.Length - 1)
        {
            if (useLines) lineCount++;

            proceedWithNextLine = false;

            dialogueText.text = dialogues[lineCount].GetDialogueText();
            characterName.text = dialogues[lineCount].GetTalkingCharacterName();

            StartCoroutine(TypeWriter());
        }

        #endregion
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

        proceedWithNextLine = true;

        yield break;
    }
}
