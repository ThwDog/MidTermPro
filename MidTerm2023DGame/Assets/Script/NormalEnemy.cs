using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.currentHP -= enemyData.damege;
            StartCoroutine(atk());
        }
    }

    IEnumerator atk()
    {
        player.haveAtk = true;
        yield return new WaitForSeconds(6);
        player.haveAtk = false;

    }
}
