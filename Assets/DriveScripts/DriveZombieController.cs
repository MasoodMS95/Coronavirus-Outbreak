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

    // Start is called before the first frame update
    void Start()
    {
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
            //transform.LookAt(player.transform);
            agent.SetDestination(target.position);
        }
    }
}
