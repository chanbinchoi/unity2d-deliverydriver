using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private bool alreadyHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (alreadyHit) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            alreadyHit = true;
            GameManager.I.AddHit();

            // 맞춘 적은 제거(원하는 스타일)
            Destroy(gameObject);
        }
    }
}
