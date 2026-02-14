using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.001f;

    void Start()
    {

    }


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // 좌우
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // 상하
        transform.Rotate(0, 0, -steerAmount); // Z축 기준으로 회전
        transform.Translate(0, moveAmount, 0); // Y축 방향으로 이동
    }
}
