using System;
using GameManager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Control
{
    public class PlayerLookController : MonoBehaviour
    {
        [SerializeField] private Transform cameraPivot;
        [SerializeField] private float sensitivity = 0.12f;
        [SerializeField] private ScenarioManager manager;
        [SerializeField] private DestroyComponentsOnScenarioFinish destroyer;

        private InputAction lookAction;

        private float pitch;

        private void Awake()
        {
            lookAction = InputSystem.actions.FindAction("Look");

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        private void Start()
        {
            destroyer.AddToList(this);
        }

        private void Update()
        {
            var look = lookAction.ReadValue<Vector2>() * sensitivity;

            SetPitch(look);
            SetYaw(look);

            cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }

        private void SetPitch(Vector2 mouseDelta)
        {
            pitch -= mouseDelta.y;
            pitch = Mathf.Clamp(pitch, -80f, 80f);
        }

        private void SetYaw(Vector2 mouseDelta)
        {
            transform.Rotate(Vector3.up * mouseDelta.x);
        }
    }
}