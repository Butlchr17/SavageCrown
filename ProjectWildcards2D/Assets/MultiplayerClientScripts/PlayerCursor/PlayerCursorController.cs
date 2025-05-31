using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

namespace SavageCrown
{
    public class PlayerCursorController : MonoBehaviourPun
    {

        #region Private Fields

        [SerializeField]
        private float cursorSpeed = 5f;

        [SerializeField]
        private RectTransform boardBounds; // Reference to the host client's BoardCanvas RectTransform

        [SerializeField]
        private Camera mainCam;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            if (mainCam == null)
            {
                mainCam = Camera.main;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            HandleTouchMovement();
        }

        #endregion

        #region  Private Methods

        private void HandleTouchMovement()
        {

#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
            
            if (Input.touchCount > 0){
                Touch touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector3 touchPos = mainCam.ScreenToWorldPoint(touch.position);
                    touchPos.z = 0f;

                    //Clamp to Board
                    Vector3 clampedPos = ClampToBoard(touchPos);
                    transform.position = Vector3.Lerp(transform.position, clampedPos, cursorSpeed * Time.deltaTime);
                }
            }

#endif
        }


        private Vector3 ClampToBoard(Vector3 targetPos)
        {
            if (boardBounds == null)
            {
                Debug.LogWarning("PlayerCursorController: BoardBounds not assigned!");
                return targetPos;
            }

            Vector3[] corners = new Vector3[4];
            boardBounds.GetWorldCorners(corners);

            float minX = corners[0].x;
            float minY = corners[0].y;
            float maxX = corners[2].x;
            float maxY = corners[2].y;

            float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
            float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);

            return new Vector3(clampedX, clampedY, 0f);
        }

        #endregion

    }
}

