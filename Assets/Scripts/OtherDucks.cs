using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDucks : MonoBehaviour
{
	float speed = 1;
	float angleRot = -0.25f;

	float angle;
	float radius;
    // Start is called before the first frame update
    void Start()
    {
    	radius = (float)Math.Sqrt(Math.Pow(transform.position.x, 2) + Math.Pow(transform.position.z, 2));
    	angle = (float)Math.Atan(transform.position.z / transform.position.x);
        //initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    	angle += speed * Time.deltaTime;

    	float posX = (float)Math.Cos(angle)*radius;
    	float posZ = (float)Math.Sin(angle)*radius;

        transform.Rotate(Vector3.up * angleRot, Space.World);

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }
}