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
    private Text gold;
    public float startTime;
    public float spawnDist = 10;
    public float zombiey = 0;
    public float stage = 0;
    private GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnner());
        startTime = Time.time;
        gold = GameObject.Find("Gold").GetComponent<Text>();
        healthBar = GameObject.Find("Health");
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)(t / 60)).ToString();
        string seconds = (t % 60).ToString("f2");
        healthBar.transform.localScale = new Vector3(PlayerPrefs.GetFloat("Health", 100f) / 100, 0.17156f);
        gold.text = PlayerPrefs.GetFloat("Gold", 0).ToString() + " Gold";
        if ((PlayerPrefs.GetFloat("Health", 100f)) == 0)
        {
            PlayerPrefs.SetFloat("CurrentTime", t);
            if (stage == 1){
              SceneManager.LoadScene(10);
            }
            else if (stage == 2){
              SceneManager.LoadScene(12);
            }
            else if (stage == 3){
              SceneManager.LoadScene(13);
            }
            else if (stage == 4){
              SceneManager.LoadScene(14);
            }
            else if (stage == 5){
              SceneManager.LoadScene(18);
            }
            else if (stage == 6){
              SceneManager.LoadScene(17);
            }
            else if (stage == 7){
              SceneManager.LoadScene(19);
            }
            else if (stage == 8){
              SceneManager.LoadScene(20);
            }
            else{
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator spawnner()
    {
        for(;;){
            spawn();
            float seconds = ((Time.time - startTime) % 60);
            if(stage == 8)    //hardest level - want a lot to spawn
            {
                yield return new WaitForSeconds(Random.Range(.2f, .8f));
            }
            else
            {
               yield return new WaitForSeconds(Random.Range(.5f,2));
            }
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
        if (stage == 4){
          Vector3 spawnRot = new Vector3(0, zombieSpawner.transform.rotation.y, zombieSpawner.transform.rotation.z);
          Instantiate(zombieSpawner, spawn, Quaternion.Euler(spawnRot));
        }
        else if (stage == 8){       //make it spawn out of sewer's coordinates
          Vector3 spawnRot = new Vector3(0, zombieSpawner.transform.rotation.y, zombieSpawner.transform.rotation.z);
          Instantiate(zombieSpawner, spawn, Quaternion.Euler(spawnRot));
        }
        else{
          Instantiate(zombieSpawner, spawn, zombieSpawner.transform.rotation);
        }
      }
}
