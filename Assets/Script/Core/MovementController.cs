using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Core
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementController : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public Vector3 AgentGlobalVelocity 
        { 
            get
            {
                return navMeshAgent.velocity;
            }        
        } 

        private void Start() 
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        //Set Nav Mesh Agent's destination to target position
        public void MoveToPosition(Vector3 targetPosition)
        {
            navMeshAgent.destination = targetPosition;
        }     
    }
}