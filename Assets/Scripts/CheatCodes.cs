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
      if (Input.GetKeyDown(KeyCode.Z)) //level 1 start screen
      {
        SceneManager.LoadScene(10);
      }
      if (Input.GetKeyDown(KeyCode.X)) //level 2 start screen
      {
        SceneManager.LoadScene(12);
      }
      if (Input.GetKeyDown(KeyCode.C)) //level 3 start screen
      {
        SceneManager.LoadScene(13);
      }
      if (Input.GetKeyDown(KeyCode.V)) //level 4 Start scene
      {
        SceneManager.LoadScene(14);
      }
      if (Input.GetKeyDown(KeyCode.B)) //level 5 start screen
      {
        SceneManager.LoadScene(18);
      }
      if (Input.GetKeyDown(KeyCode.N)) //level 6 start screen
      {
        SceneManager.LoadScene(17);
      }
      if (Input.GetKeyDown(KeyCode.M)) //level 7 start screen
      {
        SceneManager.LoadScene(19);
      }
      if (Input.GetKeyDown(KeyCode.Comma)) //level 8 start screen
      {
        SceneManager.LoadScene(20);
      }
      if (Input.GetKeyDown(KeyCode.Period))
      {
        SceneManager.LoadScene(23);// helicopter cut scene
      }
    }
}
