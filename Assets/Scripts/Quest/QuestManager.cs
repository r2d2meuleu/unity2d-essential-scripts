using Pixeye.Unity;
using UnityEngine;

/*
 * I CAN'T REALLY FIGURE OUT WHY BUT TO MAKE THE QUEST ACTIVATION FROM THE 'QuestObjectActivator'
 * YOU HAVE TO LEAVE THE FIRST VALUE ON THE ARRAY 'QuestMarkerName' BLANK
 * I WILL INVESTIGATE THIS ISSUE LATER ON
 */

public class QuestManager : MonoBehaviour
{
    [Foldout("Save and Load keys", true)]
    [SerializeField] KeyCode saveQuestsKey = KeyCode.O;
    [SerializeField] KeyCode loadQuestsKey = KeyCode.L;

    [Foldout("Quests", true)]
    [Header("Keep the first value empty")]
    [SerializeField] string[] questMarkerName;
    [Header("Keep empty")]
    [SerializeField] bool[] questMarkerComplete;

    public static QuestManager instance;

    void Start()
    {
        instance = this;

        questMarkerComplete = new bool[questMarkerName.Length];
    }

    void Update()
    {
        if (Input.GetKeyDown(saveQuestsKey))
        {
            SaveQuestData();
        }

        if (Input.GetKeyDown(loadQuestsKey))
        {
            LoadQuestData();
        }
    }

    public int GetQuestNumber(string questToFind)
    {
        for (int i = 0; i < questMarkerName.Length; i++)
        {
            if (questMarkerName[i] == questToFind)
            {
                return i;
            }
        }

        Debug.LogError($"Quest {questToFind} does not exist");
        return 0;
    }

    public bool CheckIfComplete(string questToCheck)
    {
        if (GetQuestNumber(questToCheck) != 0)
        {
            return questMarkerComplete[GetQuestNumber(questToCheck)];
        }

        return false;
    }

    public void MarkQuestComplete(string questToMark)
    {
        questMarkerComplete[GetQuestNumber(questToMark)] = true;
        UpdateLocalQuestObjects();
    }

    public void MarkQuestIncomplete(string questToMark)
    {
        questMarkerComplete[GetQuestNumber(questToMark)] = false;
        UpdateLocalQuestObjects();
    }

    public void UpdateLocalQuestObjects()
    {
        QuestObjectActivator[] questObjects = FindObjectsOfType<QuestObjectActivator>();

        if (questObjects.Length > 0)
        {
            for (int i = 0; i < questObjects.Length; i++)
            {
                questObjects[i].CheckCompletion();
            }
        }
    }

    public void SaveQuestData()
    {
        for (int i = 0; i < questMarkerName.Length; i++)
        {
            if (questMarkerComplete[i])
            {
                PlayerPrefs.SetInt("QuestMarker_" + questMarkerName[i], 1);
            }
            else
            {
                PlayerPrefs.SetInt("QuestMarker_" + questMarkerName[i], 0);
            }
        }
    }

    public void LoadQuestData()
    {
        for (int i = 0; i < questMarkerName.Length; i++)
        {
            int valueToSet = 0;
            if (PlayerPrefs.HasKey("QuestMarker_" + questMarkerName[i]))
            {
                valueToSet = PlayerPrefs.GetInt("QuestMarker_" + questMarkerName[i]);
            }

            if (valueToSet == 0)
            {
                questMarkerComplete[i] = false;
            }
            else
            {
                questMarkerComplete[i] = true;
            }
        }
    }
}
