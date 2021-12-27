using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkaiObjects : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("expirateHonkai");
    }

    void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.gameObject.tag == "Enemy") {
            Health enemyHealth = collidedObject.gameObject.GetComponent<Health>();
            if (enemyHealth != null) {
                enemyHealth.receiveDamage(3);
            }
        }
        Destroy(gameObject);
    }

    IEnumerator expirateHonkai() 
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
