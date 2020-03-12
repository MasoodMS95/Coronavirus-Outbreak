using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject regularZombie;
    public GameObject projectileZombie;
    public GameObject bombZombie;

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
            if (stage == 1)
            {
                SceneManager.LoadScene(10);
            }
            else if (stage == 2)
            {
                SceneManager.LoadScene(12);
            }
            else if (stage == 3)
            {
                SceneManager.LoadScene(13);
            }
            else if (stage == 4)
            {
                SceneManager.LoadScene(14);
            }
            else if (stage == 5)
            {
                SceneManager.LoadScene(18);
            }
            else if (stage == 6)
            {
                SceneManager.LoadScene(17);
            }
            else if (stage == 7)
            {
                SceneManager.LoadScene(19);
            }
            else if (stage == 8)
            {
                SceneManager.LoadScene(20);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator spawnner()
    {
        for (; ; )
        {
            spawn();
            float seconds = ((Time.time - startTime) % 60);
            if (stage == 4)
            {
                yield return new WaitForSeconds(Random.Range(.5f, 1f));
            }
            else if (stage == 8)
            {
                yield return new WaitForSeconds(Random.Range(.5f, 1f));
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(.5f, 2));
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
        Vector3 spawn = new Vector3(Random.Range(Player.transform.position.x - spawnDist, Player.transform.position.x + spawnDist), zombiey, Random.Range(Player.transform.position.z - spawnDist, Player.transform.position.z + spawnDist));
        if (stage == 1){
          if (Player.transform.position.x < -94f){
            spawn = new Vector3(-62.49f, zombiey, 212f);//wave 1
          }
          else if (Player.transform.position.x < -9.7f){
            spawn = new Vector3(8.8f, zombiey, 153.1f);//wave 2
          }
          else if (Player.transform.position.x < 49f){
            spawn = new Vector3(70.7f, zombiey, 153.3f);  //wave 3
          }
          else if (Player.transform.position.x < 93f){
            spawn = new Vector3(125.4f, zombiey, 243.3f);  //wave 4
          }
          else {
            if (Player.transform.position.z <159.2f){
              spawn = new Vector3(199f, zombiey, 133.4f); //wave 6
            }
            else{
              spawn = new Vector3(191f, zombiey, 255f); //wave 5
            }
          }
          Instantiate(regularZombie, spawn, regularZombie.transform.rotation);
        }
        else if (stage == 2)
        {
            return;
        }
        else if (stage == 4)
        {
            Vector3 spawnRot = new Vector3(0, 0.75f, regularZombie.transform.rotation.z);
            Instantiate(regularZombie, spawn, Quaternion.Euler(spawnRot));
        }
        else if (stage == 8)
        {       //make it spawn out of sewer's coordinates
                //spawn = new Vector3(-17.26f, zombiey, -28.5f);
            //Instantiate(zombieSpawner, spawn, Quaternion.Euler(spawnRot));
            spawn = new Vector3(20.5f, zombiey, 17.5f);

            int zombieType = Random.Range(0, 3);

            if (zombieType == 0)
            {
                Vector3 spawnRot = new Vector3(regularZombie.transform.rotation.x, regularZombie.transform.rotation.y, regularZombie.transform.rotation.z);
                Instantiate(regularZombie, spawn, Quaternion.Euler(spawnRot));
            }
            else if (zombieType == 1)
            {
                Vector3 spawnRot = new Vector3(projectileZombie.transform.rotation.x, projectileZombie.transform.rotation.y, projectileZombie.transform.rotation.z);
                Instantiate(projectileZombie, spawn, Quaternion.Euler(spawnRot));
            }
            else if (zombieType == 2)
            {
                Vector3 spawnRot = new Vector3(bombZombie.transform.rotation.x, bombZombie.transform.rotation.y, bombZombie.transform.rotation.z);
                Instantiate(bombZombie, spawn, Quaternion.Euler(spawnRot));
            }
        }
        else
        {
            Instantiate(regularZombie, spawn, regularZombie.transform.rotation);
        }
    }
}
