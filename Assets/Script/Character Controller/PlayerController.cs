using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using System;

namespace RPG.CharactorController
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour, IAttack, IMove
    {
        private NavMeshAgent agent;
        private Animator anim;
        private GameObject enemyTarget;
        private Vector3 destinationTarget;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            InputEventRaiser.TerrainHit += TerrainHitHandler;
            InputEventRaiser.EnemyHit += EnemyHitHandler;
        }

        void Update()
        {
            AnimationHandler();
        }

        private void AnimationHandler()
        {
            Vector3 localVelocity = this.transform.InverseTransformDirection(agent.velocity);
            float forwardSpeed = localVelocity.z;
            anim.SetFloat("forwardSpeed", forwardSpeed);
        }

        private void EnemyHitHandler(RaycastHit hit)
        {
            throw new NotImplementedException();
        }

        private void TerrainHitHandler(RaycastHit hit)
        {
            CancelAttack();
            CancelMove();
            MoveToTarget(hit.point);
        }

        public void MoveToTarget(Vector3 target)
        {
            agent.destination = target;
        }

        public void CancelMove()
        {
            //agent.isStopped = true;
            //Debug.Log("Stop move");
        }

        public void AttackTarget(GameObject target)
        {
            throw new System.NotImplementedException();
        }

        public void CancelAttack()
        {
            //Debug.Log("Stop attack");
        }
    }
}