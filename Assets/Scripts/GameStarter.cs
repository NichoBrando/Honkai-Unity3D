using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScreen : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene(0);
    }
}
