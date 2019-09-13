using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool isTouchDown = false;
    Vector3 speed = new Vector3(0.3f, 0.3f, 0.3f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) isTouchDown = true;
        if (Input.GetMouseButtonUp(0)) isTouchDown = false;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 moveVec = Vector3.Scale(transform.forward, speed);
            transform.position = transform.position + moveVec;
        }
    }
}
