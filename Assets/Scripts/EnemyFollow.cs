using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    
    [SerializeField]
    private Rigidbody body;

    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            transform.LookAt(player.gameObject.transform.position);
            body.velocity = transform.forward * speed;
        }
        else {
            body.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collidedObject)
    {
        if (collidedObject.gameObject.tag == "Player") {
            Health playerHealth = collidedObject.gameObject.GetComponent<Health>();
            if (null != playerHealth) {
                playerHealth.receiveDamage(3);
                Destroy(gameObject);
            }
        }
    }

    public void updateSpeed(float speedIncrement)
    {
        speed += speedIncrement;
    }
}
