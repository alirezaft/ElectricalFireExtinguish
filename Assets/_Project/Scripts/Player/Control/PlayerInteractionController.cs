using System;
using System.Collections.Generic;
using GameManager;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player.Control
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Camera playerCamera;

        [SerializeField] private Equipper equipper;
        [SerializeField] private ScenarioManager scenarioManager;
        [SerializeField] private InteractionManager interactionManager;

        [Header("Interaction")] [SerializeField]
        private float interactionDistance = 3f;

        [SerializeField] private Transform handPosition;
        [SerializeField] private float sphereRadius = 0.25f;
        

        private Interactable previousLookedInteractable;

        private void Update()
        {
            var lookedTool = FindLookedAtTool();
            ChangeFocus(lookedTool);
        }

        private void OnEnable()
        {
            InputSystem.actions.FindAction("Interact").performed += OnInteractPressed;
            Debug.Log("Subscribed successfully");
        }

        private void OnDisable()
        {
            InputSystem.actions.FindAction("Interact").performed -= OnInteractPressed;
        }

        private Tool FindLookedAtTool()
        {
            if (Physics.SphereCast(
                    playerCamera.transform.position,
                    sphereRadius,
                    playerCamera.transform.forward,
                    out RaycastHit hit,
                    interactionDistance))
            {
                if (hit.collider.TryGetComponent(out Tool tool))
                    return tool;
            }

            return null;
        }

        private void ChangeFocus(Interactable lookedTool)
        {
            if (lookedTool == previousLookedInteractable)
                return;

            if (previousLookedInteractable != null)
                OnLookExit(previousLookedInteractable);

            previousLookedInteractable = lookedTool;

            if (previousLookedInteractable == null)
                return;
            
            var isToolRequired = scenarioManager.IsCurrentInteraction(previousLookedInteractable);

            if (previousLookedInteractable != null && isToolRequired)
                OnLookEnter(previousLookedInteractable);
            else if (previousLookedInteractable != null && !isToolRequired)
                previousLookedInteractable = null;
        }

        private void OnLookExit(Interactable tool)
        {
            interactionManager.CancelInteractionAttempt(tool);
        }

        private bool OnLookEnter(Interactable tool)
        {
            return interactionManager.AttemptInteraction(tool);
        }
        

        private void OnInteractPressed(InputAction.CallbackContext ctx)
        {
            if (previousLookedInteractable is null || previousLookedInteractable is not Tool tool)
                return;
            
            previousLookedInteractable.transform.MoveChildTo(tool.HoldingPoint, handPosition.position);
            previousLookedInteractable.transform.rotation = Quaternion.Euler(tool.HoldingRotation);
            previousLookedInteractable.transform.parent = handPosition;
            
            equipper.EquipTool(tool);
        }
        
        private void EquipTool(Tool tool)
        {
            
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (playerCamera == null)
                return;

            Gizmos.color = Color.green;

            Vector3 start = playerCamera.transform.position;
            Vector3 end = start + playerCamera.transform.forward * interactionDistance;

            Gizmos.DrawWireSphere(start, sphereRadius);
            Gizmos.DrawWireSphere(end, sphereRadius);
            Gizmos.DrawLine(start, end);
        }
#endif
    }
}