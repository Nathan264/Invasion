using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private PlayerData pData;
    [SerializeField] private AudioClip hitSound;
    private AudioSource enemyAudio;

    [SerializeField] private float knockbackTime;
    [SerializeField] private float health;

    private void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        FillHealth();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(other.attachedRigidbody.velocity);
        }

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            StartCoroutine(Knockback(-enemy.Rig.velocity * 3));
        }
        
    }

    private void FillHealth()
    {
        if (enemy.EnemyObj)
        {
            health = enemy.EnemyObj.health;
        }
    }

    private void TakeDamage(Vector2 knockbackDir)
    {
        PlayHitSound();
        health -= pData.Atk;

        if (health <= 0)
        {
            Die();
        }

        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Knockback(knockbackDir));    
        }

    }

    private void Die()
    {
        gameObject.SetActive(false);
        GameController.Instance.UpdateScore(enemy.EnemyObj.score);
        WaveController.Instance.UpdateEnemiesCount();
    }

    private void PlayHitSound()
    {
        enemyAudio.clip = hitSound;
        enemyAudio.Play();
    }

    private IEnumerator Knockback(Vector2 knockbackDir)
    {
        enemy.Knockback = true;

        enemy.Rig.velocity = knockbackDir / 2;

        yield return new WaitForSeconds(knockbackTime);  
        enemy.Knockback = false; 
        
    }
}
