using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.CharactorController
{
    [RequireComponent(typeof(MovementController))]
    public class PlayerController : MonoBehaviour
    {
        private MovementController movementController;
        private NavMeshAgent navMeshAgent;
        private Animator anim;

        private void Start()
        {
            movementController = GetComponent<MovementController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseClick();
            }

            AnimationHandler();
        }

        private void MouseClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                movementController.MoveToPosition(hitInfo.point);
            }
        }

        private void AnimationHandler()
        {
            Vector3 playerVelocity = navMeshAgent.velocity;
            float forwardSpeed = playerVelocity.z;

            anim.SetFloat("forwardSpeed", forwardSpeed);
        }
    }
}