using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestWingBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AttackDownwards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AttackDownwards()
    {
        while(transform.position.z < 19f)
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
        transform.Rotate(0, 90, 0);
        while (transform.position.z > -11f)
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
        transform.Rotate(0, -90, 0);
    }
}
