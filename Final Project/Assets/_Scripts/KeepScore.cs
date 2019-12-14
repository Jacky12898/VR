using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepScore : MonoBehaviour
{
    int snowmenAlive;
    private AudioSource win;

    void Start()
    {
        snowmenAlive = GameObject.FindGameObjectsWithTag("Snowman").Length;
        win = GetComponent<AudioSource>();
    }

    void Update()
    {
        snowmenAlive = GameObject.FindGameObjectsWithTag("Snowman").Length;
        if (snowmenAlive == 0)
        {
            win.Play();
            Destroy(this.gameObject);
            GameObject player = GameObject.Find("Player");
            Destroy(player);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
