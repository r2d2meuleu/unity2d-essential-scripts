using System.Collections;
using Pixeye.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multiple_Choice_Dialogue
{
    public class MultipleChoiceDialogueManager : MonoBehaviour
    {
        [Foldout("Controls", true)] 
        [SerializeField] private KeyCode progressDialogueKey = KeyCode.E;
        [SerializeField] private KeyCode saveStateKey = KeyCode.O;
        [SerializeField] private KeyCode loadStateKey = KeyCode.P;
    
        [Foldout("Dialogue States Settings", true)] 
        [SerializeField] private DialogueState initialState;
        [SerializeField] private DialogueState currentState;
        [SerializeField] private DialogueState savedState;
        [SerializeField] private int currentDialogueProgress = 0;
        [Range(0,0.1f)] [SerializeField] private float textRevealSpeed;
    
        [Foldout("Components", true)]
        [SerializeField] private TMP_Text talkingCharacterNameText;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private Image talkingCharacterSprite;
        [SerializeField] private Image secondCharacterSprite;
        [SerializeField] private Image backgroundSprite;
        [SerializeField] private GameObject buttonChoiceContainer;
        [SerializeField] private GameObject buttonChoice;

        public static MultipleChoiceDialogueManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            currentState = initialState;
        
            SetCurrentState(currentState);
        }

        void Update()
        {
            if (Input.GetKeyDown(progressDialogueKey))
            {
                currentDialogueProgress++;

                if (currentDialogueProgress >= currentState.GetCurrentDialogue().Length)
                {
                    InstantiateButtonChoices();
                    foreach (Transform buttons in buttonChoiceContainer.transform)
                    {
                        buttons.GetComponent<CanvasGroup>().alpha = 1;
                        buttons.GetComponent<CanvasGroup>().interactable = true;
                    }
                }else
                {
                    SetCurrentState(currentState);
                }
            }
        
            if(Input.GetKeyDown(saveStateKey)) SaveState();
            if(Input.GetKeyDown(loadStateKey)) LoadState();
        }

        /// <summary>
        /// Initialise and set the UI based on the current state + currentDialogueProgress
        /// </summary>
        /// <param name="state">the state you want to use</param>
        private void SetCurrentState(DialogueState state)
        {
            talkingCharacterNameText.text = state.GetCurrentDialogue()[currentDialogueProgress].GetCharacterName();
            dialogueText.text = state.GetCurrentDialogue()[currentDialogueProgress].GetDialogue();
            talkingCharacterSprite.sprite = state.GetCurrentDialogue()[currentDialogueProgress].GetCharacterImage();
            secondCharacterSprite.sprite = state.GetCurrentDialogue()[currentDialogueProgress].GetSecondCharacterImage();
            backgroundSprite.sprite = state.GetCurrentBackground();

            StartCoroutine(TypeWriterEffect());
        }

        /// <summary>
        /// Check for the lenght of the array 'currentState.GetCurrentChoices' and instantiate as many buttons as its lenght
        /// </summary>
        private void InstantiateButtonChoices()
        {
            DestroyButtonChoices();

            for (int i = 0; i < currentState.GetCurrentChoices().Length; i++)
            {
                var newButton = Instantiate(buttonChoice, buttonChoiceContainer.transform.parent.position, Quaternion.identity);
                newButton.transform.SetParent(buttonChoiceContainer.transform);

                var choiceText = newButton.GetComponentInChildren<TMP_Text>();
                choiceText.text = currentState.GetCurrentChoices()[i];
            
                newButton.GetComponent<GetChoice>().SetChoiceIndex(i);

                newButton.GetComponent<CanvasGroup>().alpha = 0;
                newButton.GetComponent<CanvasGroup>().interactable = false;
            }
        }

        /// <summary>
        /// Destroy the currently instantiated array of prefabs of buttonChoice
        /// </summary>
        private void DestroyButtonChoices()
        {
            if (buttonChoiceContainer.transform.childCount > 0)
            {
                foreach (Transform child in buttonChoiceContainer.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        /// <summary>
        /// Set the state to be switched equal to the param 'i' on button click
        /// </summary>
        /// <param name="i">position of the state in the .GetNextDialogueStates array</param>
        public void SetNextState(int i)
        {
            currentDialogueProgress = 0;
        
            var nextStates = currentState.GetNextDialogueStates();

            currentState = nextStates[i];
        
            Debug.Log($"button with choice {currentState} clicked!");
        
            talkingCharacterNameText.text = currentState.GetCurrentDialogue()[currentDialogueProgress].GetCharacterName();
            dialogueText.text = currentState.GetCurrentDialogue()[currentDialogueProgress].GetDialogue();
            talkingCharacterSprite.sprite = currentState.GetCurrentDialogue()[currentDialogueProgress].GetCharacterImage();
            secondCharacterSprite.sprite = currentState.GetCurrentDialogue()[currentDialogueProgress].GetSecondCharacterImage();
            backgroundSprite.sprite = currentState.GetCurrentBackground();

            StartCoroutine(TypeWriterEffect());
        
            InstantiateButtonChoices();
        }

        /// <summary>
        /// Load the previously saved state
        /// </summary>
        public void LoadState()
        {
            if (savedState != null)
            {
                DestroyButtonChoices();
                currentDialogueProgress = 0;
                currentState = savedState;
                SetCurrentState(currentState);
            }
            else
            {
                Debug.Log("No saved state retrievable!");
            }
        }

        /// <summary>
        /// Save the current state
        /// </summary>
        public void SaveState()
        {
            savedState = currentState;
        }

        /// <summary>
        /// Set on a gameObject with the component TMP_Text and set the speed you want each character to reveal; 
        /// This Coroutine reveals the text of 'storyText', so you can add custom tags from the inspector without them glitching mid reveal.
        /// </summary>
        /// <returns></returns>
        private IEnumerator TypeWriterEffect()
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
}