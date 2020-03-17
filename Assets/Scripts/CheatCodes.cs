using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //level 1 start screen
        {
            SceneManager.LoadScene(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //level 2 start screen
        {
            SceneManager.LoadScene(12);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //level 3 start screen
        {
            SceneManager.LoadScene(13);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) //level 4 cut scene
        {
            SceneManager.LoadScene(11);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) //level 5 start screen
        {
            SceneManager.LoadScene(18);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) //level 6 start screen
        {
            SceneManager.LoadScene(17);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) //level 7 start screen
        {
            SceneManager.LoadScene(19);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) //level 8 start screen
        {
            SceneManager.LoadScene(20);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene(23);// helicopter cut scene
        }
    }
}
