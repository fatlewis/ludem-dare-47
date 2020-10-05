using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//static instance of the GM can be accessed from anywhere
	public static GameManager gameManager;  

	float score = 0;
	int scoreInt = 0;

	public bool musicEnabled = true;
	public bool soundEnabled = true;

	public AudioClip menuMusic;
	public AudioClip gameMusic;
	AudioSource music;

	Material playerMaterial; 

    // Awake is called when the script is being loaded
	void Awake()
	{
    	//check that it exists
		if(gameManager == null)
		{
    		//assign it to the current object
			gameManager = this;
		}

    	//make sure that it is equal to the current object
		else if(gameManager != this)
		{
    		//destroy the current game object - we only want the original
			Destroy(gameObject);
		}

        //don't destroy this object when changing scenes
		DontDestroyOnLoad(gameObject);
		music = GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		RefreshToggles();
	}

	public void IncreaseScore(float amount)
	{
    	//increase score by the amount
		score += amount;
		scoreInt = (int)score;
	}

	public int GetScoreInt()
	{
		return scoreInt;
	}

	public void ResetScore()
	{
		score = 0;
		scoreInt = 0;
	}

	public void SetMaterial(Material chosenMaterial)
	{
		playerMaterial = chosenMaterial;
	}

	public Material GetMaterial()
	{
		return playerMaterial;
	}

	public void PlayMenuMusic()
	{
		StopMusic();
		music.clip = menuMusic;
		music.Play();
	}

	public void PlayGameMusic()
	{
		StopMusic();
		music.clip = gameMusic;
		music.Play();
	}

	public void StopMusic()
	{
		music.Stop();
	}

	public void ToggleMusic(bool val)
	{
		musicEnabled = val;
		if (musicEnabled)
		{
			PlayMenuMusic();
		}
		else
		{
			StopMusic();
		}
	}

	public void ToggleSound(bool val)
	{
		soundEnabled = val;
		Debug.Log(soundEnabled);
	}

	public bool IsMusicEnabled()
	{
		return musicEnabled;
	}

	public bool IsSoundEnabled()
	{
		return soundEnabled;
	}


	public void RefreshToggles()
	{
		GameObject settingsMenu = GameObject.FindGameObjectWithTag("SettingsMenu");
        Toggle[] toggles = settingsMenu.GetComponentsInChildren<Toggle>();
        foreach (Toggle t in toggles)
        {
            Debug.Log(t.tag);
            if (t.tag == "MusicToggle")
            {
                t.onValueChanged.AddListener((value) => {
                    ToggleMusic(value);
                    });
                t.isOn = IsMusicEnabled();
            }
            if (t.tag == "SoundToggle")
            {
                t.onValueChanged.AddListener((value) => {
                    ToggleSound(value);
                    });
                t.isOn = IsSoundEnabled();
            }

        }
	}
}
