using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
  private Button button;
  public GameObject BlueChosen;
  public GameObject GreenChosen;
  public GameObject RedChosen;
  private float coin;
    // Start is called before the first frame update
    void Start()
    {
      button = GetComponent<Button>();
      button.onClick.AddListener(checkButton);
      BlueChosen.gameObject.SetActive(true);
      GreenChosen.gameObject.SetActive(false);
      RedChosen.gameObject.SetActive(false);
      //PlayerPrefs.SetFloat("Gold", 20000);
      coin = PlayerPrefs.GetFloat("Gold");
    }
    void checkButton()
    {
      if (button.gameObject.name == "BlueBuyButton"){
        BlueChosen.gameObject.SetActive(true);

      }
      if (button.gameObject.name == "GreenBuyButton"){
        if ((PlayerPrefs.GetFloat("Gold", 0)) >= 4000){
          if (GreenChosen.gameObject.activeInHierarchy == false){
            coin -=4000;
            PlayerPrefs.SetFloat("Gold", coin);
            GreenChosen.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("GreenBullet", 1);
          }
        }
      }
      if (button.gameObject.name == "RedBuyButton"){
        if ((PlayerPrefs.GetFloat("Gold", 0)) >= 8000){
          if (RedChosen.gameObject.activeInHierarchy == false){
            coin -=8000;
            PlayerPrefs.SetFloat("Gold", coin);
            RedChosen.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("RedBullet", 1);
          }
        }
      }
      if(button.gameObject.name == "SceneButton"){
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);//back to previous scene
      }
    }
}
