using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Timer and text code provided by youtube guide https://youtu.be/x-C95TuQtf0
    private Text timer, gold;
    public float startTime;
    public float stage = 0;
    private GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timer = GameObject.Find("Timer").GetComponent<Text>();
        gold = GameObject.Find("Gold").GetComponent<Text>();
        healthBar = GameObject.Find("Health");
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)(t / 60)).ToString();
        string seconds = (t % 60).ToString("f2");
        timer.text = "TIME: " + minutes + ":" + seconds;
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
}
