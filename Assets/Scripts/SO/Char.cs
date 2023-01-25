using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Char", menuName ="Scriptable Object/Char")]
public class Char : ScriptableObject
{
    public float hp;
    public float attack;
    public float attackCd;
    public float spd;

    public BulletType bullet;
    public RuntimeAnimatorController charAnim;
    public Sprite charSprite;
}
