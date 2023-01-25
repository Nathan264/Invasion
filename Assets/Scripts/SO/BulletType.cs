using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletType", menuName = "Scriptable Object/BulletType")]
public class BulletType : ScriptableObject
{
    public float bulletSpd;
    public float timeToDisable;
}
