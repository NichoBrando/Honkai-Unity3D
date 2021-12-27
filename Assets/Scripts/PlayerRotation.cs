using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x, 
            cameraTransform.eulerAngles.y, 
            transform.eulerAngles.z
        );
    }
}
