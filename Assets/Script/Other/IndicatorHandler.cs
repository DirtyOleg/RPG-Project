using System;
using System.Collections;
using System.Collections.Generic;
using RPG.CharactorController;
using RPG.Core;
using UnityEngine;

namespace RPG.Other
{
    public class IndicatorHandler : MonoBehaviour
    {
        private Vector3 defaultPosition;

        private void Start()
        {
            InputEventRaiser.EnemyHit += EnemyHitHandler;
            InputEventRaiser.TerrainHit += TerrainHitHandler;
            defaultPosition = this.transform.position;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.tag == "Player")
            {
                this.transform.position = defaultPosition;
            }            
        }

        private void TerrainHitHandler(RaycastHit hit)
        {
            this.transform.position = hit.point;
        }

        private void EnemyHitHandler(RaycastHit hit)
        {
            this.transform.position = defaultPosition;
        }
    }
}
