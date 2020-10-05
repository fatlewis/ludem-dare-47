using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneButtons : MonoBehaviour
{
	public Text scoreLabel;
	void Start()
	{
		scoreLabel.text = "Score: " + GameManager.gameManager.scoreInt;
	}
    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DuckSelectScene");
        GameManager.gameManager.PlayMenuMusic();
        GameManager.gameManager.ResetScore();
    }

    public void MenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        GameManager.gameManager.ResetScore();
    }
}
