using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObject", menuName ="Scriptable Object/Enemy")]
public class EnemyObj : ScriptableObject
{
    public float atk;
    public float health;
    public float spd;
    public float score;

    public RuntimeAnimatorController anim;
}
