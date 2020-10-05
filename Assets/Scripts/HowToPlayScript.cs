using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DuckSelectScene");
    }
}
