using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveDeadZombieBodyController : MonoBehaviour
{
    public ParticleSystem BloodSplat;
    Rigidbody zombieRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        BloodSplat.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        zombieRigidBody = GetComponent<Rigidbody>();
        Vector3 velocity = zombieRigidBody.velocity;
        if (velocity.magnitude > 10.0f)
        {
            zombieRigidBody.velocity = velocity.normalized * 10.0f;
        }
    }
}
