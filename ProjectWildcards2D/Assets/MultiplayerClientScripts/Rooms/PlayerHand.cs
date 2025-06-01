using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerHand : MonoBehaviourPun
{
    #region Public Fields

    public List<Tile> heldTiles = new List<Tile>();
    public List<RuleCard> heldRules = new List<RuleCard>();
    public List<ActionCard> heldActions = new List<ActionCard>();

    public delegate void HandUpdated();
    public event HandUpdated OnHandUpdated;

    #endregion

    #region Tile Methods

    [PunRPC]
    public void RPC_AddTile(string tileName)
    {
        Tile tile = TileDatabase.Instance.GetTileByName(tileName);
        if (tile != null && !heldTiles.Contains(tile))
        {
            heldTiles.Add(tile);
            OnHandUpdated?.Invoke();
        }
    }

    [PunRPC]
    public void RPC_PlayTile(string tileName)
    {
        Tile tile = heldTiles.Find(t => t.tileName == tileName);
        if (tile != null)
        {
            heldTiles.Remove(tile);
            OnHandUpdated?.Invoke();
            tile.Activate(this.gameObject);
        }
    }


    #endregion

    #region RuleCard Methods

    [PunRPC]
    public void RPC_AddRuleCard(string ruleName)
    {
        RuleCard card = RuleCardDatabase.Instance?.GetRuleCardByName(ruleName);
        if (card != null && !heldRules.Contains(card))
        {
            heldRules.Add(card);
            OnHandUpdated?.Invoke();
            Debug.Log($"[PlayerHand] RuleCard added: {ruleName}");
        }
        else
        {
            Debug.LogWarning($"[PlayerHand] RuleCard not found or already in hand: {ruleName}");
        }
    }

    [PunRPC]
    public void RPC_PlayRuleCard(string ruleName)
    {
        RuleCard card = heldRules.Find(c => c.ruleName == ruleName);
        if (card != null)
        {
            heldRules.Remove(card);
            OnHandUpdated?.Invoke();
            Debug.Log($"[PlayerHand] RuleCard played: {ruleName}");

            card.Activate(this.gameObject);
        }
        else
        {
            Debug.LogWarning($"[PlayerHand] RuleCard not in hand: {ruleName}");
        }
    }

    #endregion

    #region ActionCard Methods

    [PunRPC]
    public void RPC_AddActionCard(string actionName)
    {
        ActionCard card = ActionCardDatabase.Instance?.GetActionCardByName(actionName);
        if (card != null && !heldActions.Contains(card))
        {
            heldActions.Add(card);
            OnHandUpdated?.Invoke();
            Debug.Log($"[PlayerHand] ActionCard added: {actionName}");
        }
        else
        {
            Debug.LogWarning($"[PlayerHand] ActionCard not found or already in hand: {actionName}");
        }
    }

    [PunRPC]
    public void RPC_PlayActionCard(string actionName)
    {
        ActionCard card = heldActions.Find(c => c.actionName == actionName);
        if (card != null)
        {
            heldActions.Remove(card);
            OnHandUpdated?.Invoke();
            Debug.Log($"[PlayerHand] ActionCard played: {actionName}");

            card.Activate(this.gameObject);
        }
        else
        {
            Debug.LogWarning($"[PlayerHand] ActionCard not in hand: {actionName}");
        }
    }

    #endregion
}
