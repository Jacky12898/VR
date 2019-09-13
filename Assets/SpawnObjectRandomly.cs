using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectRandomly : MonoBehaviour
{
    GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        float spawnTime = Random.Range(0.0f, 8.0f);
        if(spawnTime == 0)
        {
            Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));
            Quaternion rotation = new Quaternion(0, 0, 0, 0);
            Instantiate(prefab, position, rotation);
        }
    }
}
