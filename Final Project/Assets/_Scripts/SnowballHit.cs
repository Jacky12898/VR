using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowballHit : MonoBehaviour
{
    private AudioSource deathSound;

    void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snowball")
        {
            deathSound.Play();
            GameObject player = GameObject.Find("Player");
            Destroy(player);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
