using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior4 : MonoBehaviour
{
    private float speed = 2f;
    public GameObject player;
    public GameObject blood;
    public GameObject money;
    public AudioClip hit;
    private AudioSource hitsound;
    public float xRange = 10f;
    public float zRange = 10f;
    private float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        hitsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // if (transform.position.x < -xRange)
        // {
        //     transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        // }
        // if (transform.position.x > xRange)
        // {
        //     transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        // }
        // if (transform.position.z < -zRange)
        // {
        //     transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        // }
        // if (transform.position.z > zRange)
        // {
        //     transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        // }
        if(transform.position.y != 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Bullet"))
        {
            float x = Random.Range(1, 10);
            if(x == 1)
            {
                hitsound.PlayOneShot(hit, 2.0f);
            }
            health -= Random.Range(10, 40);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
    }

    private void OnDestroy()
    {
        //if (Random.value > 0.6) {
       //     GameObject goldcoin = (GameObject)Instantiate(money, transform.position, money.transform.rotation);
       //     Destroy(goldcoin, 5);
        //}
    }
}
