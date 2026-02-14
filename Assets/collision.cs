using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("으아아악 어떻게저거~!!!!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("오옹 나이스!");
    }
}
