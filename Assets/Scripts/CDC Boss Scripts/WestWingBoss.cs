using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestWingBoss : MonoBehaviour
{
    public GameObject blood;
    private float health = 500;
    public GameObject player;
    private float time;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time == 15)
        {
            speed = 10f;
        }
        if(Time.time - time == 30)
        {
            speed = 20f;
        }
        if(Time.time - time == 60)
        {
            speed = 30f;
        }
        if(health < 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("BlueBullet"))
        {
            health -= Random.Range(10, 20);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
        else if (other.gameObject.name.StartsWith("GreenBullet"))
        {
            health -= Random.Range(20, 30);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
        else if (other.gameObject.name.StartsWith("RedBullet"))
        {
            health -= Random.Range(30, 40);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Wall"))
        {
            Debug.Log("WE COLLIDING BOYS");
            transform.LookAt(player.transform);
        }
    }
}
