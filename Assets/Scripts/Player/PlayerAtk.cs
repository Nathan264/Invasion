using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private PlayerSounds pSound;

    private bool canAtk = true;

    private void Update() 
    {
        if (GameController.Instance.IsGameOver)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && canAtk)
        {
            Fire();
        }    
    }


    private void Fire()
    {
        pSound.PlayClip("Atk");
        pData.PlayerAnim.SetTrigger("Fire");

        GameObject tmp = ObjectPooler.Instance.GetPooledObject("Bullet");

        if (tmp == null)
        {
            return;
        }

        tmp.transform.position = transform.position;
        tmp.SetActive(true);

        StartCoroutine(AtkCooldown());
    }

    private IEnumerator AtkCooldown()
    {
        canAtk = false;

        yield return new WaitForSeconds(pData.AtkCd);

        canAtk = true;
    }
}
