using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currScoreText : MonoBehaviour
{
    public TextMeshProUGUI currText;
    // Start is called before the first frame update
    void Start()
    {
        float time = PlayerPrefs.GetFloat("CurrentTime");
        string minutes = ((int)(time / 60)).ToString();
        string seconds = (time % 60).ToString("f2");
        currText.text = "TIME: " + minutes + ":" + seconds;
    }

}
