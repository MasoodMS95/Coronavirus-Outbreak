﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void Shop()
    {
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
}
