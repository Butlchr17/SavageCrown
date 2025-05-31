using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameInitializer : MonoBehaviour
{

    #region Private Fields

    [SerializeField]
    private GameObject boardCanvas;

    [SerializeField]
    private GameObject playerCanvas;

    #endregion

    #region MonoBehaviour Callbacks
    
    // Start is called before the first frame update
    void Start()
    {
        ///<Summary>
        /// If the player is the game host, show the board canvas on their screen (host/PC).
        /// If the player is not the game host, show the player canvas on their screen (mobile).
        /// </summary>
        bool isHost = PhotonNetwork.IsMasterClient;

        if (boardCanvas != null && playerCanvas != null)
        {
            boardCanvas.SetActive(isHost);   //enable board canvas
            playerCanvas.SetActive(!isHost); //enable player canvas 
        }
        else
        {
            Debug.Log("Room: Either the boardCanvas or the playerCanvas are not set");
        }

    }

    #endregion

}
