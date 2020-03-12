using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneFlow : MonoBehaviour
{
    private Button button;
    public GameObject Cam1;
    public GameObject Text1;
    public GameObject Cam2;
    public GameObject Text2;
    // Start is called before the first frame update
    void Start()
    {
      button = GetComponent<Button>();
      button.onClick.AddListener(checkButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void checkButton(){
      if (button.gameObject.name == "Continue_Button1"){
        Cam1.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Cam2.gameObject.SetActive(true);
        Text2.gameObject.SetActive(true);
      }
      else if (button.gameObject.name == "Continue_Button2"){
        SceneManager.LoadScene(14);
      }
    }
}
