using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRuleCard", menuName = "SavageCrown/Rule Card")]
public class RuleCard : ScriptableObject
{
    public string ruleName;
    public string ruleDescription;
    public Sprite icon;
}
