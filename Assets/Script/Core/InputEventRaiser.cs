using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class InputEventRaiser : MonoBehaviour
    {
        public static event Action<RaycastHit[]> MouseClicked;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && MouseClicked != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hitInfos = Physics.RaycastAll(ray, 100f);
                if (hitInfos != null)
                {
                    MouseClicked.Invoke(hitInfos);
                }
            }

            //TODO check if hit the roof of the building, what will happen
            //TODO always raycast, so could use to highlight enemy or detect potential off map action
        }
    }
}