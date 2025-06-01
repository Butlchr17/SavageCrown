using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileManager : MonoBehaviour
{
    #region Public Fields

    public TileDatabase tileDatabase;

    public int RemainingTileCount => tileBag?.Count ?? 0;

    #endregion

    #region Private Fields

    private Queue<Tile> tileBag;

    #endregion


    #region MonoBehaviour Callbacks
    void Start()
    {
        InitializeBag();
    }

    void InitializeBag()
    {
        if (tileDatabase == null || tileDatabase.allTiles == null || tileDatabase.allTiles.Count == 0)
        {
            Debug.LogWarning("TileManager: TileDatabase or its content is null/empty.");
            return;
        }

        List<Tile> shuffled = new List<Tile>(tileDatabase.allTiles);
        shuffled = shuffled.OrderBy(x => Random.value).ToList();

        tileBag = new Queue<Tile>(shuffled);
    }

     private void ShuffleTiles()
    {
        if (tileBag == null || tileBag.Count == 0)
        {
            Debug.LogWarning("TileManager: Cannot shuffle an empty tile bag.");
            return;
        }

        List<Tile> remainingTiles = tileBag.ToList();
        remainingTiles = remainingTiles.OrderBy(x => Random.value).ToList();
        tileBag = new Queue<Tile>(remainingTiles);
    }

    #endregion

    #region  Public Methods

    public Tile DrawTile()
    {
        if (tileBag == null || tileBag.Count == 0)
        {
            Debug.LogWarning("TileManager: Tile Bag is empty!");
            return null;
        }

        return tileBag.Dequeue();
    }

    public void ShuffleRemainingTiles()
    {
        ShuffleTiles();
    }


    #endregion
}
