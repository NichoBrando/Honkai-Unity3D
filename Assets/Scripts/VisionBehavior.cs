using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionBehavior : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    float GetAxisWithSensibility (string axis) {
        return Input.GetAxis(axis) * 5;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        transform.eulerAngles = Vector3.zero;
    }

    void FixedUpdate()
    {
        float mouseHorizontalMovement = GetAxisWithSensibility("Mouse X");
        float mouseVerticalMovement = -GetAxisWithSensibility("Mouse Y");
        Vector3 updatedAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        updatedAngles.x += mouseVerticalMovement;
        updatedAngles.y += mouseHorizontalMovement;
        transform.eulerAngles = updatedAngles;
    }

    void LateUpdate() 
    {
        transform.position = playerTransform.position;
    }
}
