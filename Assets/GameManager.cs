using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("State")]
    public bool hasItem = false;

    [Header("Fail")]
    public int hitCount = 0;
    public int hitLimit = 5;

    [Header("Hit Cooldown")]
    public float hitCooldown = 0.7f;   // 붙어있을 때 데미지 간격
    private float nextHitTime = 0f;

    private bool ended = false;

    void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        Time.timeScale = 1f;
    }

    public void PickupItem()
    {
        if (ended) return;

        hasItem = true;
        Debug.Log("아이템 획득!");
    }

    public void TryClear()
    {
        if (ended) return;

        if (hasItem)
        {
            Win();
        }
        else
        {
            Debug.Log("아이템이 없어. 먼저 nutariri1을 먹어!");
        }
    }

    public void AddHit()
    {
        if (ended) return;

        // 🔥 쿨타임 체크 (붙어있어도 일정 간격만 데미지)
        if (Time.time < nextHitTime) return;

        nextHitTime = Time.time + hitCooldown;

        hitCount++;
        Debug.Log($"피격: {hitCount}/{hitLimit}");

        if (hitCount >= hitLimit)
        {
            Lose();
        }
    }

    public void Win()
    {
        if (ended) return;

        ended = true;
        Debug.Log("클리어!");
        EndGameFreeze();
    }

    public void Lose()
    {
        if (ended) return;

        ended = true;
        Debug.Log("실패!");
        EndGameFreeze();
    }

    private void EndGameFreeze()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!ended) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

