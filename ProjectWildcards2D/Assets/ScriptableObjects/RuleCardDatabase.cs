using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuleCardDatabase", menuName = "SavageCrown/Rule Card Database")]
public class RuleCardDatabase : ScriptableObject
{
    public List<RuleCard> allRuleCards;

    private static RuleCardDatabase _instance;

    public static RuleCardDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<RuleCardDatabase>("RuleCardDatabase");
                if (_instance == null)
                {
                    Debug.LogError("RuleCardDatabase: Couldn't find RuleCardDatabase asset in Resources folder.");
                }
            }
            return _instance;
        }
    }

    public RuleCard GetRuleCardByName(string name) => allRuleCards.Find(card => card.ruleName == name);
}