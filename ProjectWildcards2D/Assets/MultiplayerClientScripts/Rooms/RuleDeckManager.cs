using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RuleDeckManager : MonoBehaviour
{
    #region Public Fields

    public List<RuleCard> ruleCards;

    #endregion

    #region Private Fields

    private Queue<RuleCard> deck;

    #endregion

    #region Public Methods

    public void InitializeDeck()
    {
        List<RuleCard> shuffled = new List<RuleCard>(ruleCards);
        shuffled = shuffled.OrderBy(x => Random.value).ToList();
        deck = new Queue<RuleCard>(shuffled);
    }

    public RuleCard DrawCard()
    {
        if (deck.Count == 0)
        {
            return null;
        }
        return deck.Dequeue();
    }

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        InitializeDeck();

        foreach (var card in ruleCards)
        {
            Debug.Log(card.ruleName + ": " + card.ruleDescription);
        }
    }

    #endregion
}
