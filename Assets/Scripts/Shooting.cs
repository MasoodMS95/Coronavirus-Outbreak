using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float speed = 20f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        if(transform.position.x > (player.transform.position.x+50) || transform.position.x < (player.transform.position.x-50))
        {
            Destroy(gameObject);
        }
        if (transform.position.z > (player.transform.position.z+50) || transform.position.z < player.transform.position.z-50)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
