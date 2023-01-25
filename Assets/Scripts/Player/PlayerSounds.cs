using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip atk;
    
    public void PlayClip(string audio)
    {
        AudioClip audioClip = null;

        switch (audio)
        {
            case "Hit":
                audioClip = hit;
            break;

            case "Atk":
                audioClip = atk;
            break;

        }

        pData.PlayerAudio.clip = audioClip;
        pData.PlayerAudio.Play();
    }
}