using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject zombieSpawner;
    public static PlayerController player;
    public GameObject Player;
    //Timer and text code provided by youtube guide https://youtu.be/x-C95TuQtf0
    public Text timer, health, gold;
    public float startTime;
    public float spawnDist = 10;
    public float zombiey = 0;
    public float stage4 = 0;
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
        health.text = "Health:" + PlayerPrefs.GetFloat("Health", 100f).ToString() + "%";
        gold.text = PlayerPrefs.GetFloat("Gold", 0).ToString() + " Gold";
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
            //if(seconds < 10)
            //{
                yield return new WaitForSeconds(Random.Range(.5f, 2));
            //}
            //if(seconds > 10 && seconds < 20)
            //{
            //    yield return new WaitForSeconds(Random.Range(.5f,1.5f));
            //}
            //if(seconds > 20)
            //{
            //    yield return new WaitForSeconds(Random.Range(.1f, .5f));
            //}
        }
    }
    void spawn()
    {
        /*
         * Spawn is a random Vector3 that is focused on x and z
         * generating the range of -10 to 10 for the x and z.
         * Y wil always be set to zero.
         */
        Vector3 spawn = new Vector3(Random.Range(Player.transform.position.x-spawnDist, Player.transform.position.x + spawnDist), zombiey, Random.Range(Player.transform.position.z-spawnDist, Player.transform.position.z+spawnDist));
        if (stage4 == 1){
          Vector3 spawnRot = new Vector3(0, zombieSpawner.transform.rotation.y, zombieSpawner.transform.rotation.z);
          Instantiate(zombieSpawner, spawn, Quaternion.Euler(spawnRot));
        }
        else{
          Instantiate(zombieSpawner, spawn, zombieSpawner.transform.rotation);
        }
      }
}
