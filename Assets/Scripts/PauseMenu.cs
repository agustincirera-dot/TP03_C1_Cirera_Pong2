using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause; // Referencia al objeto Pause
    bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f;
                Pause.SetActive(true); // Activa el menú
            }
            else
            {
                Time.timeScale = 1f;
                Pause.SetActive(false); // Desactiva el menú
            }
        }
    }
}
