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
        public GameObject hitPointIndicator;

        private MovementController movementController;
        private Animator anim;

        private void Start()
        {
            movementController = GetComponent<MovementController>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickToMove();
            }

            AnimationHandler();
        }

        private void ClickToMove()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                movementController.MoveToPosition(hitInfo.point);
                Instantiate(hitPointIndicator, hitInfo.point, Quaternion.identity);
            }
        }

        float forwardSpeed;
        private void AnimationHandler()
        {
            Vector3 localVelocity = this.transform.InverseTransformDirection(movementController.AgentGlobalVelocity);
            forwardSpeed = localVelocity.z;
            anim.SetFloat("forwardSpeed", forwardSpeed);
        }
    }
}