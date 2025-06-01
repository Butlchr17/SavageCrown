using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTile", menuName = "SavageCrown/Tile")]
public class Tile : ScriptableObject
{
    #region Public Fields
    public string tileName;
    public Sprite tileSprite;
    public GameObject tilePrefab;

    #endregion

    #region Public Methods

    public virtual void Activate(GameObject player)
    {
        Debug.Log($"{tileName} tile activated by {player.name}");
    }
    
    #endregion
}

