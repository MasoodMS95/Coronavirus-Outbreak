using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterScene : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public int done = 0;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(TheSequence());
    }

    void Update(){
      if (done ==1){
        SceneManager.LoadScene(2);
      }
    }
    // Update is called once per frame
    IEnumerator TheSequence(){
      yield return new WaitForSeconds(3);
      Cam2.SetActive(true);
      //Cam2.SetActive(false);
      //yield return new WaitForSeconds(1);
      done = 1;
    }
}
