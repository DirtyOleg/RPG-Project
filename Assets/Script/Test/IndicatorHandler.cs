using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Test
{
    public class IndicatorHandler : MonoBehaviour
    {
        //todo destroy indicator if there is more then 1 indicator in the scene
        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.tag == "Player")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
