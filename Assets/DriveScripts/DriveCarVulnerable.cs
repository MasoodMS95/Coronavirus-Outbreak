using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DriveCarVulnerable : MonoBehaviour
{
    private DriveGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("DriveGameManager").GetComponent<DriveGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Here");
        if (collision.gameObject.CompareTag("Zombie"))
        {
            if (Math.Abs(gameManager.getSpeed()) < 15)
            {
                PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") - 10f);
                Debug.Log(PlayerPrefs.GetFloat("Health"));
            }
        }
    }



}
