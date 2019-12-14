using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    public GameObject snowball;

    void Start()
    {
        Instantiate(snowball, this.transform.position, Quaternion.identity);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Snowball")
        {
            Instantiate(snowball, this.transform.position, Quaternion.identity);
        }
    }
}
