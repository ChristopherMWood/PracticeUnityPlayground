using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    private float CurrentVerticalRotation = 0;
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float HorizontalSensitivity = 9.0f;
    public float VerticalSensitivity = 9.0f;

    public float MaxVertical = 45f;
    public float MinVertical = -45f;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        if (body != null) {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        // if (axes == RotationAxes.MouseX) {
        //     transform.Rotate(0, Input.GetAxis("Mouse X") * HorizontalSensitivity, 0);
        // } else if (axes == RotationAxes.MouseY) {
        //     CurrentVerticalRotation -= Input.GetAxis("Mouse Y") * VerticalSensitivity;
        //     CurrentVerticalRotation = Mathf.Clamp(CurrentVerticalRotation, MinVertical, MaxVertical);

        //     float horizontalRot = transform.localEulerAngles.y;
        //     transform.localEulerAngles = new Vector3(CurrentVerticalRotation, horizontalRot, 0);
        // } else {
        //     CurrentVerticalRotation -= Input.GetAxis("Mouse Y") * VerticalSensitivity;
        //     CurrentVerticalRotation = Mathf.Clamp(CurrentVerticalRotation, MinVertical, MaxVertical);

        //     float delta = Input.GetAxis("Mouse X") * HorizontalSensitivity;
        //     float horizontalRotation = transform.localEulerAngles.y + delta;

        //     transform.localEulerAngles = new Vector3(CurrentVerticalRotation, horizontalRotation, 0);
        // }
    }
}
