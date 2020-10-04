﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSelect : MonoBehaviour
{
	GameObject duck;
	Renderer[] childRenderers;
	public Material[] availableMaterials;
	int currentMaterial = 0;
    // Start is called before the first frame update
	void Start()
	{
		duck = GameObject.FindGameObjectWithTag("Player");
		childRenderers = duck.GetComponentsInChildren<Renderer>();
	}

	void Update()
	{
		duck.transform.Rotate(0, 60*Time.deltaTime, 0);
	}

	public void PlayButton()
	{
        Debug.Log("Play button pressed");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
	}

	public void LeftButton()
	{
		//Modulo in C# is actually a remainder, doesn't work for negative numbers. This is a hacky fix.
		int choiceCount = availableMaterials.Length;
		currentMaterial = (((currentMaterial - 1) % choiceCount) + choiceCount) % choiceCount;

		foreach (Renderer r in childRenderers) {
			if (r.gameObject.tag == "ColouredPart") {
				r.material = availableMaterials[currentMaterial];
			}
		}
	}

	public void RightButton()
	{
		currentMaterial = (currentMaterial + 1) % availableMaterials.Length;
		foreach (Renderer r in childRenderers) {
			if (r.gameObject.tag == "ColouredPart") {
				r.material = availableMaterials[currentMaterial];
			}
		}
	}
}
