using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private Char cData;
    
    [SerializeField] private Image healthImg;

    public void UpdateHealth()
    {
        float hpPercentage =  ((pData.Health * 100) / cData.hp) / 100;

        healthImg.fillAmount = hpPercentage;
    }
}
