using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//static instance of the GM can be accessed from anywhere
	public static GameManager gameManager;   

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

        //find an object of type HudManager
        //hudManager = FindObjectOfType<HUDManager>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
