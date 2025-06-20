using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRuleCard", menuName = "SavageCrown/Rule Card")]
public class RuleCard : ScriptableObject
{

    #region Public Fields

    public string ruleName;
    public string ruleDescription;
    public Sprite icon;

    #endregion

    #region Public Methods

    public virtual void Activate(GameObject player)
    {
        Debug.Log($"{ruleName} activated by {player.name}");

        // add in rule logic here

    }

    #endregion
}
