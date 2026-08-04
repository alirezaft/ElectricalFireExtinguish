using System;
using System.Collections.Generic;
using GameManager;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Control
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Camera playerCamera;

        [SerializeField] private ScenarioManager scenarioManager;
        [SerializeField] private InteractionManager interactionManager;

        [Header("Interaction")] [SerializeField]
        private float interactionDistance = 3f;

        [SerializeField] private float sphereRadius = 0.25f;
        [SerializeField] private string toolTag = "Tool";

        public GameObject CurrentTarget { get; private set; }

        private Tool previousLookedTool;

        private void Update()
        {
            var lookedTool = FindLookedAtTool();
            ChangeToolFocus(lookedTool);

            CurrentTarget = null;
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

        private void ChangeToolFocus(Tool lookedTool)
        {
            if (lookedTool == previousLookedTool)
                return;

            bool isInteractionAvailable;
            if (previousLookedTool != null)
                OnLookExit(previousLookedTool);

            previousLookedTool = lookedTool;

            if (previousLookedTool != null && scenarioManager.IsCurrentInteraction(previousLookedTool))
                OnLookEnter(previousLookedTool);
        }

        private void OnLookExit(Tool tool)
        {
            interactionManager.CancelInteractionAttempt(tool);
        }

        private bool OnLookEnter(Tool tool)
        {
            return interactionManager.AttemptInteraction(tool);
        }

        private void EquipTool(GameObject tool)
        {
            Debug.Log($"Equipped {tool.name}");
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