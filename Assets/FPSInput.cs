using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController charController;
    public InputAction PlayerMovement;
    public float Speed = 6.0f;
    public float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        PlayerMovement.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var moveDirection = PlayerMovement.ReadValue<Vector2>();
        // Debug.Log(moveDirection.x);
        // position += moveDirection * moveSpeed * Time.deltaTime;
        // float deltaX = Input.GetAxis("Horizontal") * Speed;
        // float deltaZ = Input.GetAxis("Vertical") * Speed;
        // Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // movement = Vector3.ClampMagnitude(movement, Speed);
        // movement.y = gravity;

        // movement *= Time.deltaTime;
        // movement = transform.TransformDirection(movement);
        // charController.Move(movement);
        // transform.Translate(deltaX * Time.deltaTime, 0, deltaY * Time.deltaTime);
    }
}
