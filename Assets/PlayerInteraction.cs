using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject nearItem;
    private GameObject nearGoal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 1) 아이템이 근처에 있으면 먹기
            if (nearItem != null)
            {
                GameManager.I.PickupItem();
                Destroy(nearItem); // 먹었으니 씬에서 제거
                nearItem = null;
                return;
            }

            // 2) 목표가 근처에 있으면 클리어 시도
            if (nearGoal != null)
            {
                GameManager.I.TryClear();
                return;
            }

            Debug.Log("상호작용할 대상이 근처에 없음");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item")) nearItem = other.gameObject;
        if (other.CompareTag("Goal")) nearGoal = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item") && nearItem == other.gameObject) nearItem = null;
        if (other.CompareTag("Goal") && nearGoal == other.gameObject) nearGoal = null;
    }
}

