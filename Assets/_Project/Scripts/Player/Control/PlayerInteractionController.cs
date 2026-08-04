using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Control
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Camera playerCamera;

        [Header("Interaction")] [SerializeField]
        private float interactionDistance = 3f;

        [SerializeField] private float sphereRadius = 0.25f;
        [SerializeField] private string toolTag = "Tool";

        public GameObject CurrentTarget { get; private set; }

        private void Update()
        {
            if (Physics.SphereCast(
                    playerCamera.transform.position,
                    sphereRadius,
                    playerCamera.transform.forward,
                    out RaycastHit hit,
                    interactionDistance))
            {
                
            }

            CurrentTarget = null;
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