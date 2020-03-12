using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DriveZombieController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private GameObject player;
    public bool isActive;
    public float speed = 2f;
    public GameObject zombieHead;
    public GameObject zombieBody;
    private DriveGameManager driveGameManager;

    // Start is called before the first frame update
    void Start()
    {
        driveGameManager = GameObject.Find("DriveGameManager").GetComponent<DriveGameManager>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("DriverPlayer");
        target = player.transform;
        isActive = false;
        agent.speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 120f)
        {
            isActive = true;
        }

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 120f)
        {
            isActive = false;
        }

        if (isActive)
        {
            agent.SetDestination(target.position);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Car"))
        {
            if (driveGameManager.getSpeed() >= 25f)
            {
                Vector3 spawnPosHead = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z);
                Vector3 spawnPosBody = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Instantiate(zombieHead, spawnPosHead, gameObject.transform.rotation);
                Instantiate(zombieBody, spawnPosBody, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
        
        
        //if(collision.gameObject.CompareTag("Car"))
        //{
        //    Destroy(gameObject);
            //transform.Translate(-Vector3.forward * Time.deltaTime * 5f);
            //StartCoroutine(KillZombie());
        //}
    }

    private IEnumerator KillZombie()
    {
        yield return new WaitForSeconds(3f);
        transform.Translate(-Vector3.forward * Time.deltaTime * 5f);
        
        //Destroy(gameObject);
    }
}
