using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionCardDatabase", menuName = "SavageCrown/Action Card Database")]
public class ActionCardDatabase : ScriptableObject
{
    public List<ActionCard> allActionCards;

    private static ActionCardDatabase _instance;

    public static ActionCardDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<ActionCardDatabase>("ActionCardDatabase");
                if (_instance == null)
                {
                    Debug.LogError("ActionCardDatabase: Couldn't find ActionCardDatabase asset in Resources folder.");
                }
            }
            return _instance;
        }
    }

    public ActionCard GetActionCardByName(string name) => allActionCards.Find(card => card.actionName == name);
}

