using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Enemy enemySettings;   
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject player;
    private Vector2 move;

    [SerializeField] private float timeToTurn;
    [SerializeField] private float detectionArea;
    private float xDir;
    private float yDir;
    private bool routineIsRunning;


    private void Update()
    {
        if (GameController.Instance.IsGameOver)
        {
            return;
        }

        if (!enemySettings.Knockback)
        {
            Move();
        }
    }

    private void FixedUpdate() 
    {
        Collider2D detect = Physics2D.OverlapCircle(transform.position, detectionArea, playerMask);

        if (detect != null)
        {
            if (routineIsRunning)
            {
                StopCoroutine("ChangeDir");
                routineIsRunning = false;
            }

            if (!player)
            {
                player = detect.gameObject;          
            }

            SetPlayerDir();  
        }
        else
        {
            if (!routineIsRunning)
            {
                StartCoroutine("ChangeDir");
                routineIsRunning = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Walls"))    
        {
            xDir = xDir * -1;
            yDir = yDir * -1;
        }
    }

    private void Move()
    {
        move = new Vector2(xDir, yDir);

        enemySettings.Rig.velocity = move * enemySettings.EnemyObj.spd;
    }

    private void SetPlayerDir()
    {
        Vector3 playerDir = (player.transform.position - transform.position).normalized;

        xDir = playerDir.x;
        yDir = playerDir.y;
    }

    private IEnumerator ChangeDir()
    {
        while (true)
        {
            xDir = Random.Range(-1f, 2f);
            yDir = Random.Range(-1f, 2f);

            yield return new WaitForSeconds(timeToTurn);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, detectionArea);    
    }
}
