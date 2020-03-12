using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoleFallScript : MonoBehaviour
{
    private GameObject player;
    private bool hasFallen;
    // Start is called before the first frame update
    void Start()
    {
        hasFallen = false;
        player = GameObject.Find("DriverPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.eulerAngles.x);
        if ((Vector3.Distance(player.transform.position, gameObject.transform.position) < 100) && !hasFallen)
        {
            Vector3 rotation = new Vector3(90f, 0, 0);
            transform.Rotate(rotation * Time.deltaTime);
            if(transform.eulerAngles.x >= 354)
            {
                hasFallen = true;
            }
        }
    }
}
