using System.Collections;
using System.Collections.Generic;
using Multiple_Choice_Dialogue;
using UnityEngine;

public class GetChoice : MonoBehaviour
{
    public int choiceIndex;

    public void SetNewState()
    {
        MultipleChoiceDialogueManager.Instance.SetNextState(choiceIndex);
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }
    
    public void SetChoiceIndex(int i)
    {
        choiceIndex = i;
    }
}
