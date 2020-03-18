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
    public GameObject money;
    private DriveGameManager driveGameManager;
    private float currentDamageToPlayer;
    private bool canDamagePlayer;

    // Start is called before the first frame update
    void Start()
    {
        canDamagePlayer = true;
        currentDamageToPlayer = 0f;
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
        if ((collision.collider.CompareTag("Car") && driveGameManager.getSpeed() >= 20f) ||
            (collision.collider.CompareTag("CarRear") && driveGameManager.getSpeed() <= -20f))
        {
            Vector3 spawnPosHead = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z);
            Vector3 spawnPosBody = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(zombieHead, spawnPosHead, gameObject.transform.rotation);
            Instantiate(zombieBody, spawnPosBody, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("CarVulnerable") && driveGameManager.getSpeed() < 20)
        {
            if (canDamagePlayer)
            {
                PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") - 7f);
                if (PlayerPrefs.GetFloat("Health") < 0)
                {
                    PlayerPrefs.SetFloat("Health", 0);
                }
                currentDamageToPlayer += 7;
            }

            if (currentDamageToPlayer >= 30)
            {
                canDamagePlayer = false;
            }
        }
    }

    private void OnDestroy()
    {
        if (Random.value > 0.6)
        {
            Vector3 moneyOffset = new Vector3(0, 3, 0);
            GameObject goldcoin = (GameObject)Instantiate(money, transform.position + moneyOffset, money.transform.rotation);
            Destroy(goldcoin, 5);
        }
    }
}
