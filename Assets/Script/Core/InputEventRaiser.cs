using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class InputEventRaiser : MonoBehaviour
    {
        public static event Action<RaycastHit> TerrainHit;
        public static event Action<RaycastHit> EnemyHit;

        // Update is called once per frame
        void Update()
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] _hitInfos = Physics.RaycastAll(_ray, 100f);

            if (_hitInfos == null)
            {
                Debug.Log("destination is not defined");
                return;
            }

            //Action based on Priority
            foreach (RaycastHit hit in _hitInfos)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        print("enemy hit");
                        EnemyHit.Invoke(hit);
                        break;
                    }
                    else
                    {
                        //TODO add outline highlighter in here
                    }

                }
                else if (hit.collider.gameObject.tag == "Terrain")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        print("terrain hit");
                        TerrainHit.Invoke(hit);
                    }
                }
            }
        }
    }
}