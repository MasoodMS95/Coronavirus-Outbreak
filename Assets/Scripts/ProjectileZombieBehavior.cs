using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileZombieBehavior : MonoBehaviour
{
    private float speed = 1f;
    private GameObject player;
    public GameObject blood;
    public GameObject money;
    public AudioClip hit;
    private AudioSource hitsound;
    public float xRange = 10f;
    public float zRange = 10f;
    private float health = 100f;
    public float startDelay = 4f;
    public float minimumBetweenShots = 3f;

    void Start()
    {
        hitsound = GetComponent<AudioSource>();
        player = GameObject.Find("Player");

        InvokeRepeating(nameof(LaunchProjectile), startDelay, minimumBetweenShots);
    }

    void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (transform.position.y != 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            float x = Random.Range(1, 10);
            if (x == 1)
            {
                hitsound.PlayOneShot(hit, 2.0f);
            }
            health -= Random.Range(10, 40);

            if (other.gameObject.name.Contains("GreenBullet"))
            {
                health -= 10;
            }
            else if (other.gameObject.name.Contains("RedBullet"))
            {
                health = 20;
            }

            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
    }

    private void LaunchProjectile()
    {
        Instantiate(Resources.Load("Objects/Spitball"), transform.position, transform.rotation);
    }
}
