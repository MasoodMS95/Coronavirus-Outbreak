using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private Text timer;
    private float startTime;
    public float surviveTime = 120f;
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Time").GetComponent<Text>();
        startTime = Time.time;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = surviveTime - (Time.time - startTime);

        if (t < 0)
        {
            pc.HellicopterReady = true;
            t = 0;
        }

        string minutes = ((int)(t / 60)).ToString();
        string seconds = (t % 60).ToString("f2");

        if (t % 60 < 10)
        {
            seconds = "0" + seconds;
        }

        timer.text = "TIME: " + minutes + ":" + seconds;
    }
}
