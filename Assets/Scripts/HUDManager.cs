using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

	// score label text
	public Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        //start with fresh score
        //ResetHud();
        //scoreLabel.text = "Score: " + GameManager.gameManager.scoreInt;
    }

    void Update()
    {
    	scoreLabel.text = "Score: " + GameManager.gameManager.scoreInt;
    }

    // show up to date stats of the player
    public void ResetHud()
    {
    	//set score to 0?
    }

   
}
