using UnityEngine;

/* ASSIGN THIS TO A GAMEOBJECT AND GIVE SAID GAMEOBJECT A COLLIDER SET AS TRIGGER, WHEN THE PLAYER STEPS IN, IF 'markQuestAsCompleteOnEnter' IS TRUE -
 * -THE QUEST WILL BE MARKED AS COMPLETED, IF 'markQuestAsCompleteOnEnter' IS SET TO FALSE, IN ORDER TO COMPLETE THE QUEST, THE PLAYER WILL HAVE TO PRESS-
 * -A GIVEN BUTTON FROM 'questMarkerKey'
 */ 

[RequireComponent(typeof(BoxCollider2D))]
public class QuestMarker : MonoBehaviour
{
    [SerializeField] KeyCode questMarkerKey;
    [SerializeField] string questToMark;

    [SerializeField] bool markQuestComplete;
    [SerializeField] bool markQuestAsCompleteOnEnter;
    [SerializeField] bool deactivateGameobjectOnMark;

    private bool canMark;

    void Update()
    {
        if (canMark && Input.GetKeyDown(questMarkerKey))
        {
            canMark = false;
            MarkQuest();
        }
    }

    public void MarkQuest()
    {
        if (markQuestComplete)
        {
            QuestManager.instance.MarkQuestComplete(questToMark);
        }
        else
        {
            QuestManager.instance.MarkQuestIncomplete(questToMark);
        }

        gameObject.SetActive(!deactivateGameobjectOnMark);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (markQuestAsCompleteOnEnter)
            {
                MarkQuest();
            }
            else
            {
                canMark = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canMark = false;
        }
    }
}
