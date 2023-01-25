using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private PlayerSounds pSound;

    [SerializeField] private float invencibleTime;
    private bool invencible = false;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (GameController.Instance.IsGameOver)
        {
            return;
        }

        if (other.gameObject.CompareTag("Enemy") && !invencible)
        {
            Hit(other);
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (GameController.Instance.IsGameOver)
        {
            return;
        }

        if (other.gameObject.CompareTag("Enemy") && !invencible)
        {
            Hit(other);
        }
    }

    private void Hit(Collision2D enemy)
    {
        pSound.PlayClip("Hit");
        pData.PlayerAnim.SetTrigger("Hit");

        pData.Health -= enemy.gameObject.GetComponent<Enemy>().EnemyObj.atk;
        healthbar.UpdateHealth();

        if (pData.Health <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(HitTimer());
    }

    private void Die()
    {
        pData.PlayerAnim.SetTrigger("Death");
        GameController.Instance.GameOver();
    }

    private IEnumerator HitTimer()
    {
        invencible = true;

        yield return new WaitForSeconds(invencibleTime);

        invencible = false;
    }

    public void AddHealth()
    {   
        pData.Health += (pData.SelectedChar.hp * 30) / 100;

        if (pData.Health > pData.SelectedChar.hp)
        {
            pData.Health = pData.SelectedChar.hp;
        }
     
        healthbar.UpdateHealth();
    }
}
