using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController charController;
    public float Speed = 6.0f;
    public float gravity = -9.81f;
    private Vector2 movementValue;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Debug.Log(movementValue.x);
        float deltaX = movementValue.x * Speed;
        float deltaZ = movementValue.y * Speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }

    public void OnPlayerMovement(InputValue value)
    {
        movementValue = value.Get<Vector2>();
        Debug.Log(movementValue.x);
    }
}
