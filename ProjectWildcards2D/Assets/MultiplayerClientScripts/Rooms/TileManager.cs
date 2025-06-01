using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileManager : MonoBehaviour
{
    #region Public Fields

    [SerializeField]
    public List<GameObject> tilePrefabs; // Assign in inspector

    #endregion

    #region Private Fields

    private Queue<GameObject> tileBag;

    #endregion


    #region MonoBehaviour Callbacks
    void Start()
    {
        ShuffleTiles();
    }


    void ShuffleTiles()
    {
        List<GameObject> shuffled = new List<GameObject>(tilePrefabs);
        shuffled = shuffled.OrderBy(x => Random.value).ToList();
        tileBag = new Queue<GameObject>(shuffled);
    }

    #endregion

    #region  Public Methods

    public GameObject DrawTile()
    {
        if (tileBag.Count == 0)
        {
            Debug.LogWarning("TileManager: Tile Bag is empty!");
            return null;
        }

        return tileBag.Dequeue();
    }

    #endregion
}
