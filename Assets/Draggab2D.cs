using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable2D : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;
        offset = transform.position - mouseWorld;
    }

    void OnMouseDrag()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;
        transform.position = mouseWorld + offset;
    }
}
