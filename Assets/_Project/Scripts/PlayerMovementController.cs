using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float gravity = -20f;

    [SerializeField] private CharacterController characterController;

    private InputAction moveAction;

    private Vector3 velocity;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        var input = moveAction.ReadValue<Vector2>();

        var moveDirection =
            transform.right * input.x +
            transform.forward * input.y;

        characterController.Move(moveDirection * walkSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}