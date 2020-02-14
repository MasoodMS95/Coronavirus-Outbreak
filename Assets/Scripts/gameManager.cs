using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject zombieSpawner;
    public static PlayerController player;
    //Timer and text code provided by youtube guide https://youtu.be/x-C95TuQtf0
    public Text timer, health;
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
        if (player.getHealth() == 0)
        {
            PlayerPrefs.SetFloat("CurrentTime", t);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator spawnner()
    {
        for(;;){
            spawn();
            float seconds = ((Time.time - startTime) % 60);
            if(seconds < 10)
            {
                yield return new WaitForSeconds(Random.Range(1, 3));
            }
            if(seconds > 10 && seconds < 20)
            {
                yield return new WaitForSeconds(Random.Range(.5f,1.5f));
            }
            if(seconds > 20)
            {
                yield return new WaitForSeconds(Random.Range(.1f, .5f));
            }
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
