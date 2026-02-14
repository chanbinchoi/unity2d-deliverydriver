using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayer : MonoBehaviour
{
    private bool alreadyHit = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (alreadyHit) return;

        if (other.CompareTag("Player"))
        {
            alreadyHit = true;
            GameManager.I.AddHit();
            Destroy(gameObject); // 맞춘 적은 제거 (중복 피격 방지)
        }
    }
}

