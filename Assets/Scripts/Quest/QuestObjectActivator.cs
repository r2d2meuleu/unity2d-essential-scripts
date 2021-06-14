using UnityEngine;

/* ASSIGN THIS SCRIPT TO A GAMEOBJECT, THEN CREATE A CHILD. THE CHILD WILL BE THE GAMEOBJECT YOU WILL ATTACH TO 'objectToActivate'
 * 'questToCheck' WILL BE THE QUEST THE GAMEOBJECT WILL WAIT TO BE COMPLETED BEFORE CALLING THE FUNCTION 'CheckCompletion'
 * 'activeIfComplete' WILL SET THE GAMEOBJECT 'objectToActivate' AS TRUE OR FALSE UPON QUEST COMPLETION
 * YOU CAN USE THIS SCRIPT TO CLEAR PATHS OR OPEN DOORS, MAYBE FOR CLOSING DOOR WHEN ENTERING A BOSS AREA
 * LITTLE TIP: YOU MAY SWITCH THE LINE 'objectToActivate.SetActive(activeIfComplete);' AND CALL A 'UnityEvent' TO TRIGGER MORE OPTIONS ;)
 */

public class QuestObjectActivator : MonoBehaviour
{
    public GameObject objectToActivate;
    public string questToCheck;
    public bool activeIfComplete;

    private bool initialCheckDone;

    void Update()
    {
        if (!initialCheckDone)
        {
            initialCheckDone = true;
            CheckCompletion();
        }
    }

    public void CheckCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToCheck))
        {
            objectToActivate.SetActive(activeIfComplete);
        }
    }
}
