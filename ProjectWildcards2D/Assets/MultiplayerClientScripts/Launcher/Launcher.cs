using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace SavageCrown
{

    public class Launcher : MonoBehaviourPunCallbacks
    {
        #region Private Serializable Fields

        /// <summary>
        /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created.
        /// </summary>
        [Tooltip("The maximum number of players per room, When a room is fulll, it can't be joined by new players, and so a new room will be created.")]
        [SerializeField, Range(2, 6)]
        private byte maxPlayersPerRoom = 6;

        #endregion

        #region Private Fields

        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        ///  </summary>
        string gameVersion = "1";

        bool isConnecting;

        #endregion

        #region Public Fields

                [Tooltip("The UI Panel to let the user enter their name, connect, and play")]
                [SerializeField]
                private GameObject controlPanel;
                
                [Tooltip("The UI Label to inform the user that the connection is in progress")]
                [SerializeField]
                private GameObject progressLabel;

        #endregion

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehavior method called on GameObject by Unity during early initialization phase
        /// </summary>
        void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all other clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        ///<summary>
        /// Monobehavior method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }

        #endregion

        #region Public Methods

        ///<summary>
        /// Start the connection process.
        /// - If already connected, we attempt joining a random room
        /// - If not yet connected, Connect this application instance to Photon Cloud
        /// </summary>
        public void Connect()
        {

            Debug.Log("PhotonNetwork.IsConnected: " + PhotonNetwork.IsConnected);

            progressLabel.SetActive(true);
            controlPanel.SetActive(false);

            // we check if we are connected or not, we join if we are, else we initiate connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we''ll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
               isConnecting = PhotonNetwork.ConnectUsingSettings();
               PhotonNetwork.GameVersion = gameVersion; 
            }
        }

        #endregion

        #region MonoBehaviorPunCallbacks Callbacks

        public override void OnConnectedToMaster()
        {
            Debug.Log("Launcher: OnConnectedToMaster() was called by PUN");
            
            // do not connect unless we are attempting to join a room
            if (isConnecting)
            {
                // #Critical: The first we try to do is to join a potential exisiting room. If there is, good, else, we'll be back with OnJoinRandomFailed()
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            // do not join a new room on disconnect
            isConnecting = false;

            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
            
            Debug.LogFormat("Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Launcher: OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

            // #Critical: We only load if we are the first player, else, we rely on PhotonNetwork.AutomaticallySyncScene to sync our instance scene.

            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("We load the 'Room for 1' ");

                // #Critical
                // Load the Room Level
                PhotonNetwork.LoadLevel("Room for 1");
            }
            
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                Debug.Log("We load the 'Room for 2' ");

                // #Critical
                // Load the Room Level
                PhotonNetwork.LoadLevel("Room for 2");
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
            {
                Debug.Log("We load the 'Room for 3' ");

                // #Critical
                // Load the Room Level
                PhotonNetwork.LoadLevel("Room for 3");
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
            {
                Debug.Log("We load the 'Room for 4' ");

                // #Critical
                // Load the Room Level
                PhotonNetwork.LoadLevel("Room for 4");
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 5)
            {
                Debug.Log("We load the 'Room for 5' ");

                // #Critical
                // Load the Room Level
                PhotonNetwork.LoadLevel("Room for 5");
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 6)
            {
                Debug.Log("We load the 'Room for 6' ");

                // #Critical
                // Load the Room Level
                PhotonNetwork.LoadLevel("Room for 6");
            }
        }

        #endregion

    }
}