using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyObj enemyObj;

    private Animator anim;
    private Rigidbody2D rig;

    private bool knockback = false;


    public bool Knockback 
    {
        get { return knockback; }
        set { knockback = value; }
    }

    public EnemyObj EnemyObj
    {
        get { return enemyObj; }
        set { enemyObj = value; }
    }

    public Animator Anim
    {
        get { return anim; }
    }
    
    public Rigidbody2D Rig
    {
        get { return rig; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        anim.runtimeAnimatorController = enemyObj.anim;
        StartCoroutine(AttachCollider());
    }

    private IEnumerator AttachCollider() 
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
