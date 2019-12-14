using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowmanScript : MonoBehaviour
{
    private float snowballSpeed;
    public float snowballSpeedMin;
    public float snowballSpeedMax;
    public float fireRateMin;
    public float fireRateMax;
    private float fireRate;
    public GameObject snowball;
    private GameObject player;
    public ParticleSystem deathParticles;
    private Vector3 newPosition;
    private float time = 0;
    public bool canShoot;
    private AudioSource deathSound;

    void Start()
    {
        snowballSpeed = Random.Range(snowballSpeedMin, snowballSpeedMax);
        fireRate = Random.Range(fireRateMin, fireRateMax);
        player = GameObject.Find("Head");
        deathSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.LookAt(player.transform.position);
        time += Time.deltaTime;
        if(time >= fireRate && canShoot)
        {
            GameObject newSnowball = Instantiate(snowball, this.gameObject.transform.GetChild(4).transform.position, Quaternion.identity);
            Rigidbody rb = newSnowball.GetComponent<Rigidbody>();
            rb.velocity = (player.transform.position - newSnowball.transform.position).normalized * snowballSpeed;
            time = 0;
            fireRate = Random.Range(fireRateMin, fireRateMax);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snowball")
        {
            deathSound.Play();
            if (!canShoot)
            {
                GameObject player = GameObject.Find("Player");
                Destroy(player);
                SceneManager.LoadScene(this.gameObject.name);
            }
            Instantiate(deathParticles, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
