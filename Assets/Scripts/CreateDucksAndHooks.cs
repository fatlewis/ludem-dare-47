using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDucksAndHooks : MonoBehaviour
{
	public GameObject duckPrefab;
	public GameObject hookPrefab;
	System.Random rand = new System.Random();
    // Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("MakeRandomDuck", 1f, 1f);
		InvokeRepeating("MakeRandomHook", 1f, 5f);
	}

    // Update is called once per frame
	void Update()
	{	
	}

	void MakeRandomDuck()
	{
		Vector3 pos = RandomPos();
		pos.y = 80;
		Instantiate(duckPrefab, pos, Quaternion.identity);
	}

	void MakeRandomHook()
	{
		Vector3 pos = RandomPos();
		pos.y = 100;
		Instantiate(hookPrefab, pos, Quaternion.identity);
	}

	Vector3 RandomPos()
	{
		int radius = rand.Next(170, 260);
		double angle = (double)rand.Next();
		float posX = (float)Math.Cos(angle)*radius;
		float posZ = (float)Math.Sin(angle)*radius;

		return new Vector3(posX, 0, posZ);
	}
}
