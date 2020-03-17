using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(10);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Successfully Quit");
    }
    public void ExitMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Instructions()
    {
        SceneManager.LoadScene(22);
    }
    public void returnToLevelScreen(){
      string sceneName = PlayerPrefs.GetString("lastLoadedScene");
      SceneManager.LoadScene(sceneName);//back to previous scene
    }
    public void Shop()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(9);
    }
    public void SceneScreen()
    {
        SceneManager.LoadScene(10);
    }
    public void ScenePlay1()
    {
        SceneManager.LoadScene(7);
    }
    public void ScenePlay2()
    {
        SceneManager.LoadScene(6);
    }
    public void ScenePlay4()
    {
        SceneManager.LoadScene(8);
    }

    public void ScenePlay3()
    {
        SceneManager.LoadScene(15);
    }
    public void ScenePlay6()
    {
        SceneManager.LoadScene(16);

    }
    public void ScenePlay8()
    {
        SceneManager.LoadScene(21);

    }

    public void ScenePlay5()
    {
        SceneManager.LoadScene(24);
    }
}
