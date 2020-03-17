using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TigerController : MonoBehaviour
{
    private GameObject target = null;
    private NavMeshAgent nma = null;
    public float health = 100f;

    public GameObject blood;
    public GameObject money;
    public AudioClip hit;
    private AudioSource hitsound;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        nma = this.GetComponent<NavMeshAgent>();
        hitsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(target.transform.position);
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
                health -= 20;
            }

            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
        if (other.gameObject.name.StartsWith("Player"))
        {
            nma.SetDestination(target.transform.position);
        }
    }
}
