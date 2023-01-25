using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    private Rigidbody2D rig;
    private Animator anim;
    private AudioSource audioSource;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        SetPlayerData();
    }

    private void SetPlayerData()
    {
        anim.runtimeAnimatorController = pData.SelectedChar.charAnim;

        pData.Atk = pData.SelectedChar.attack;
        pData.Spd = pData.SelectedChar.spd;
        pData.Health = pData.SelectedChar.hp;
        pData.AtkCd = pData.SelectedChar.attackCd;
        pData.Bullet = pData.SelectedChar.bullet;
        pData.PlayerAnim = anim;
        pData.PlayerRig = rig;
        pData.PlayerAudio = audioSource;
    }
}
