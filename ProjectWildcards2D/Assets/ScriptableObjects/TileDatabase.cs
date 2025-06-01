using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(fileName = "TileDatabase", menuName = "SavageCrown/Tile Database")]
public class TileDatabase : ScriptableObject
{
    #region Public Fields

    public List<Tile> allTiles;

    #endregion

    #region Private Fields

    private static TileDatabase _instance;

    #endregion

    #region Public Instances

    public static TileDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<TileDatabase>("TileDatabase");
                if (_instance == null)
                {
                    Debug.LogError("TileDatabase: Couldn't find TileDatabase asset in Resources folder.");
                }
            }
            return _instance;
        }
    }

    #endregion

    #region Public Methods

    public Tile GetTileByName(string tileName)
    {
        return allTiles.Find(t => t.tileName == tileName);
    }

    public Tile GetRandomTile()
    {
        if (allTiles.Count == 0)
        {
            return null;
        }
        return allTiles[Random.Range(0, allTiles.Count)];
    }


    #endregion
}
