using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class currCoins : MonoBehaviour
{
    public TextMeshProUGUI currText;

    // Start is called before the first frame update
    void Start()
    {
        string gold = PlayerPrefs.GetFloat("Gold", 0).ToString() + " Gold";
        currText.text = gold;
    }
    void Update(){
      string gold = PlayerPrefs.GetFloat("Gold", 0).ToString() + " Gold";
      currText.text = gold;
    }
}
