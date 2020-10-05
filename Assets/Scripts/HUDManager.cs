using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	// score label text
	public Text scoreLabel;

    void Update()
    {
    	scoreLabel.text = "Score: " + GameManager.gameManager.GetScoreInt();
    }
}
