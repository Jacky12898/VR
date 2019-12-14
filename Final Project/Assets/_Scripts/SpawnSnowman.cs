using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnSnowman : MonoBehaviour
{
    public GameObject[] snowmenPrefabs;

    void Start()
    {
        Instantiate(snowmenPrefabs[Random.Range(0, snowmenPrefabs.Length)], this.transform.position, Quaternion.identity);
    }
}
