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
            var lookedTool = FindLookedAtInteractable();
            ChangeFocus(lookedTool);
        }

        private void OnEnable()
        {
            InputSystem.actions.FindAction("Interact").performed += OnInteractPressed;
            InputSystem.actions.FindAction("Attack").performed += OnUseToolPressed;
            Debug.Log("Subscribed successfully");
        }


        private void OnDisable()
        {
            InputSystem.actions.FindAction("Interact").performed -= OnInteractPressed;
        }

        private Interactable FindLookedAtInteractable()
        {
            if (Physics.SphereCast(
                    playerCamera.transform.position,
                    sphereRadius,
                    playerCamera.transform.forward,
                    out RaycastHit hit,
                    interactionDistance))
            {
                if (hit.collider.TryGetComponent(out Interactable interactable))
                    Debug.Log(interactable.gameObject.name);
                    return interactable;
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
            
            equipper.EquipTool(tool, handPosition);
        }
        
        
        private void OnUseToolPressed(InputAction.CallbackContext obj)
        {
            if (equipper.CurrentTool is null || previousLookedInteractable is not Part part)
                return;

            if (!scenarioManager.CanUseTool(equipper.CurrentTool, part))
                return;
                
            var tool = equipper.CurrentTool;

            
            tool.Use(part);
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