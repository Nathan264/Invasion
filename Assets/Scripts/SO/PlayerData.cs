using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName ="Scriptable Object/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float atk;
    [SerializeField] private float atkCd;
    [SerializeField] private float spd;

    [SerializeField] private Char selectedChar;
    [SerializeField] private Animator pAnim;
    [SerializeField] private Rigidbody2D pRig;
    [SerializeField] private AudioSource pAudio;
    [SerializeField] private BulletType bullet;


    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Atk
    {
        get { return atk; }
        set { atk = value; }
    }

    public float Spd
    {
        get { return spd; }
        set { spd = value; }
    }

    public float AtkCd
    {
        get { return atkCd; }
        set { atkCd = value; }
    }

    public Char SelectedChar
    {
        get { return selectedChar; }
        set { selectedChar = value; }
    }

    public Animator PlayerAnim
    {
        get { return pAnim; }
        set { pAnim = value; }
    }

    public Rigidbody2D PlayerRig
    {
        get { return pRig; }
        set { pRig = value; }
    }

    public AudioSource PlayerAudio
    {
        get { return pAudio; }
        set { pAudio = value; }
    }
    
    public BulletType Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }
}
