using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();   
            }
            else
            {
                Unpause();
            }
        }       
    }

    private void Pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        paused = true;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        paused = false;
    }

}
