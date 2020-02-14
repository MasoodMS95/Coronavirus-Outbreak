using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bestScoreText : MonoBehaviour
{
    public TextMeshProUGUI besttext;
    // Start is called before the first frame update
    void Start()
    {
        float curr = PlayerPrefs.GetFloat("CurrentTime");
        float best = PlayerPrefs.GetFloat("BestTime", 0);
        if(curr > best)
        {
            PlayerPrefs.SetFloat("BestTime", curr);
            best = PlayerPrefs.GetFloat("BestTime");
        }
        string minutes = ((int)(best / 60)).ToString();
        string seconds = (best % 60).ToString("f2");
        besttext.text = "BEST: " + minutes + ":" + seconds;
    }
}
