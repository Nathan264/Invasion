using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    [SerializeField] private GameObject helpScreen;

    public void Open()
    {
        helpScreen.SetActive(true);
    }

    public void Close()
    {
        helpScreen.SetActive(false);
    }    
}
