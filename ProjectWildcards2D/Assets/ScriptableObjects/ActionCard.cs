using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActionCard", menuName = "SavageCrown/Action Card")]
public class ActionCard : ScriptableObject
{

    #region Public Fields

    public string actionName;
    public string actionDescription;
    public Sprite icon;

    #endregion

    #region Public Methods

    public virtual void Activate(GameObject player)
    {
        Debug.Log($"{actionName} activated by {player.name}");

        // add in rule logic here

    }

    #endregion
}
