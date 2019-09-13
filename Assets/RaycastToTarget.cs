using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToTarget : MonoBehaviour
{
    private int targetLayer = 1 << 8;
    Vector3 speed = new Vector3(0.3f, 0.3f, 0.3f);
    public GameObject target;
    public GameObject target2;

    void Start()
    {
        target = GameObject.Find("Target");
        target2 = GameObject.Find("Target 2");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                Vector3 position = hit.collider.gameObject.transform.position;
                Quaternion rotation = hit.collider.gameObject.transform.rotation;

                if (hit.collider.gameObject.name.Contains("Target 2"))
                {
                    Instantiate(target, position, rotation);
                }

                else if (hit.collider.gameObject.name.Contains("Target"))
                {
                    Instantiate(target2, position, rotation);
                }

                Destroy(hit.collider.gameObject);
            }

            else
            {
                Vector3 moveVec = Vector3.Scale(transform.forward, speed);
                transform.position = transform.position + moveVec;
            }
        }
    }
}
