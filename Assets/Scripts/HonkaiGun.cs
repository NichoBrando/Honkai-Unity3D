using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkaiGun : MonoBehaviour
{
    [SerializeField]
    private GameObject handCube;

    [SerializeField]
    private Transform shotPoint;

    [SerializeField]
    private GameObject shotCubePrefab;

    private bool canShot = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canShot) {
            StartCoroutine("shotCooldown");
            GameObject shotCube = Instantiate(shotCubePrefab);
            shotCube.gameObject.transform.position = shotPoint.position;
            shotCube.gameObject.transform.eulerAngles = shotPoint.eulerAngles;
            
            Rigidbody cubeBody = shotCube.gameObject.GetComponent<Rigidbody>();
            cubeBody.velocity = shotPoint.forward * 30;
        }
    }

    IEnumerator shotCooldown () {
        canShot = false;
        handCube.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        handCube.gameObject.SetActive(true);
        canShot = true;
    }
}
