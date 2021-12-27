using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = (isRunning ? 8 : 3) * Time.deltaTime; 
        Vector3 movement = Vector3.zero;
        float forwardMovement = Input.GetAxisRaw("Vertical");
        float rightMovement = Input.GetAxisRaw("Horizontal");
        if (forwardMovement != 0) {
            movement += transform.forward * forwardMovement * speed;
        }
        if (rightMovement != 0) {
            movement += transform.right * rightMovement * speed;
        }
        movement.y -= 10 * Time.deltaTime;
        controller.Move(movement);
    }
}
