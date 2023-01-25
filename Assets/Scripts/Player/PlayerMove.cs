using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerData pData;
    [SerializeField] private PlayerHealth pHealth;

    private float hInput;
    private float vInput;

    private void Update()
    {
        if (GameController.Instance.IsGameOver)
        {
            pData.PlayerRig.velocity = Vector2.zero;
            return;
        }
        
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (hInput != 0 || vInput != 0)
        {
            pData.PlayerAnim.SetBool("Run", true);
            
            if (hInput < 0)
            {
                Turn(-1);
            }
            else if (hInput > 0)
            {
                Turn(1);
            }

            Move();
        }
        else 
        {
            pData.PlayerAnim.SetBool("Run", false);
            pData.PlayerRig.velocity = Vector2.zero;
        }
    }

    private void Move()
    {
        Vector2 move = new Vector2(hInput, vInput);

        pData.PlayerRig.velocity = move * pData.Spd;
    }

    private void Turn(int dir)
    {
        transform.localScale = new Vector3(dir, 1f, 1f);
    }

    
}
