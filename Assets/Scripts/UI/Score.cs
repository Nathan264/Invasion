using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoretxt;

    public void UpdateScoreTxt(float newValue)
    {
        scoretxt.text = "Score: " + newValue;
    } 
}
