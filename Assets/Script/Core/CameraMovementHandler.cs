using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class CameraMovementHandler : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] Transform cameraOrigin;

        private void LateUpdate()
        {
            cameraOrigin.position = player.position;
        }
    }

}