using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed;
    public Transform CameraAxisTransform;
    public float MinAngle;
    public float MaxAngle;

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");

        float MouseY = -Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * MouseX, 0);

        var newAxisAngle = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * RotationSpeed * MouseY;

        if (newAxisAngle > 180)
            newAxisAngle -= 360;

        newAxisAngle = Mathf.Clamp(newAxisAngle, MinAngle, MaxAngle);
        
        CameraAxisTransform.localEulerAngles = new Vector3(newAxisAngle, 0, 0);  
    }
}
