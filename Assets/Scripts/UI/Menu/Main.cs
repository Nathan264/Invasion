using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject selectionMenu;

    public void GoToSelection()
    {
        gameObject.SetActive(false);
        selectionMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR  
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
