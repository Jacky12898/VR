using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    void Update()
    {
        this.transform.position = Camera.main.gameObject.transform.position;
    }
}
