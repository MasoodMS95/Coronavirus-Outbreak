using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHasKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HasKey", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
