using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager2 : MonoBehaviour
{
    public GameObject zombieSpawner;
    public static PlayerController player;
    //Timer and text code provided by youtube guide https://youtu.be/x-C95TuQtf0
    public Text timer, health, gold;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnner());
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)(t / 60)).ToString();
        string seconds = (t % 60).ToString("f2");
        timer.text = "TIME: " + minutes + ":" + seconds;
        health.text = "Health:" + player.getHealth().ToString() + "%";
        gold.text = PlayerPrefs.GetFloat("Gold", 0).ToString() + " Gold";
        if (player.getHealth() == 0)
        {
            PlayerPrefs.SetFloat("CurrentTime", t);
        }
    }

    IEnumerator spawnner()
    {
        for(;;){
            spawn();
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }
    void spawn()
    {
        /*
         * Spawn is a random Vector3 that is focused on x and z
         * generating the range of -10 to 10 for the x and z.
         * Y wil always be set to zero.
         */
        Vector3 spawn = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Instantiate(zombieSpawner, spawn, zombieSpawner.transform.rotation);
    }
}
