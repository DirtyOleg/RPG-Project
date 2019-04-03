using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.CharactorController
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject hitPointIndicator = null;

        private NavMeshAgent agent;
        private Animator anim;
        private GameObject enemyTarget;
        private Vector3 destinationTarget;

        private void Start()
        {
            InputEventRaiser.MouseClicked += PlayerActionSchduler;
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            AnimationHandler();
        }

        private void PlayerActionSchduler(RaycastHit[] hitInfos)
        {
            //current version (04/02/2019) of game will only have two types of action, move or attack. for future development, the condition should adjust to meet need new requirements
            foreach (RaycastHit hitInfo in hitInfos)
            {
                if (hitInfo.collider.GetComponent<EnemyController>() != null)
                {
                    enemyTarget = hitInfo.collider.gameObject;
                    break;
                }
                else
                {
                    destinationTarget = hitInfo.point;
                }
            }

            if (enemyTarget != null)
            {
                AttackEnemy();
                return;
            }

            if (destinationTarget != null)
            {
                MoveToPosition();
                return;
            }
        }

        private void MoveToPosition()
        {
            //Re-assign new destination location for Player
            agent.destination = destinationTarget;

            //Set Hit Point Indicator
            hitPointIndicator.transform.position = destinationTarget;
            hitPointIndicator.gameObject.SetActive(true);
            
        }

        private void AttackEnemy()
        {
            enemyTarget = null;
        }

        private void AnimationHandler()
        {
            Vector3 localVelocity = this.transform.InverseTransformDirection(agent.velocity);
            float forwardSpeed = localVelocity.z;
            anim.SetFloat("forwardSpeed", forwardSpeed);
        }
    }
}