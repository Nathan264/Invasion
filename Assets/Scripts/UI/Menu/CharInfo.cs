using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharInfo : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private TMP_Text atkTxt;
    [SerializeField] private TMP_Text hpTxt;
    [SerializeField] private TMP_Text spdTxt;
    [SerializeField] private TMP_Text fireRateTxt;
    [SerializeField] private TMP_Text bulletSpdTxt;

    public void UpdateCharInfo()
    {
        atkTxt.text = pData.SelectedChar.attack.ToString();
        hpTxt.text = pData.SelectedChar.hp.ToString();
        spdTxt.text = pData.SelectedChar.spd.ToString();
        fireRateTxt.text = pData.SelectedChar.attackCd.ToString();
        bulletSpdTxt.text = pData.SelectedChar.bullet.bulletSpd.ToString();
    }

    
}
