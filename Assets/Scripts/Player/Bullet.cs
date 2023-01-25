using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    private Rigidbody2D rig;

    private void Start() 
    {
        transform.localScale = transform.localScale * (pData.Atk / 2);    
    }

    private void OnEnable() 
    {
        if (rig == null)
        {
            rig = GetComponent<Rigidbody2D>();
        }

        ImpulseBullet();
        StartCoroutine(DisableBullet());    
    }

    private void ImpulseBullet()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletDir = (mousePos - transform.position);

        rig.velocity = new Vector2(bulletDir.x, bulletDir.y).normalized * pData.Bullet.bulletSpd;
    }

    private IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(pData.Bullet.timeToDisable);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Walls") || other.CompareTag("Obstacle"))    
        {
            gameObject.SetActive(false);
        }
    }
}
