﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButtons : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject AboutMenu;
    public GameObject SettingsMenu;

    void Start()
    {
        MainMenuButton();
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        AboutMenu.SetActive(false);
    }

    public void PlayButton()
    {
        // UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        AboutMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void AboutButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        AboutMenu.SetActive(true);
    }
}
