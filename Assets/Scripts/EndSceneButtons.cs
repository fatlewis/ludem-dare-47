using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneButtons : MonoBehaviour
{
	public Text scoreLabel;
	public GameObject duck;
	void Start()
	{
		scoreLabel.text = GameManager.gameManager.GetScoreInt() + " s";

		Material playerMaterial = GameManager.gameManager.GetMaterial();
        Renderer[] childRenderers = duck.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in childRenderers) {
            if (r.gameObject.tag == "ColouredPart") {
                r.material = playerMaterial;
            }
        }
	}
    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DuckSelectScene");
        GameManager.gameManager.ResetScore();

        if (GameManager.gameManager.IsMusicEnabled())
        {
            GameManager.gameManager.PlayMenuMusic();
        }
    }

    public void MenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        GameManager.gameManager.ResetScore();
    }
}
