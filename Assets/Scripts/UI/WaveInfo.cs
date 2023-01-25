using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text waveTxt;
    [SerializeField] private TMP_Text enemiesTxt;
    [SerializeField] private TMP_Text waveTimer;

    private void Awake() 
    {
        waveTimer.gameObject.SetActive(false);    
    }

    public void SetTimer()
    {
        waveTimer.gameObject.SetActive(true);

        StartCoroutine(Countdown());
    }     

    public void UpdateEnemiesTxt(int newValue)
    {
        enemiesTxt.text = "Enemies: " + newValue;
    }

    public void UpdateWaveTxt(int newValue)
    {
        waveTxt.text = "Wave: " + newValue;
    }

    private IEnumerator Countdown()
    {
        float count = WaveController.Instance.TimeToStartWave;

        for (int i = 0; i <= WaveController.Instance.TimeToStartWave; i++)
        {
            waveTimer.text = count.ToString();
            count--;

            if (count < 0)
            {
                waveTimer.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(1f);
        }

    }
}
