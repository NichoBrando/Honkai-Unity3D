using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int remainHealth;

    [SerializeField]
    private int health;

    [SerializeField]
    private bool isPlayer;

    private GameEventController controller;

    private void Start()
    {
        restore();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameEventController>();
    }

    public void receiveDamage(int dmg) 
    {
        remainHealth -= dmg;
        if (remainHealth <= 0) {
            if (isPlayer) {
                SceneManager.LoadScene(0);
            }
            else {
                controller.onKillMob();
                Destroy(gameObject);
            }
        }
    }

    public void restore()
    {
        remainHealth = health; 
    }
}

