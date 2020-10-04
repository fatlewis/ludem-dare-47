using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDucks : MonoBehaviour
{
    float speed;
    float angleRot = -0.32f;
    float angle;
    float radius;
    bool hooked = false;

    void Start()
    {
        radius = (float)Math.Sqrt(Math.Pow(transform.position.x, 2) + Math.Pow(transform.position.z, 2));
        angle = (float)Math.Atan2(transform.position.z, transform.position.x);
        var rand = new System.Random((int)(angle + DateTime.Now.Millisecond));
        speed = (float)(0.5f*rand.NextDouble()) + 0.2f;
        Debug.Log($"speed = {speed}");
        //Debug.Log($"angle = {angle}, x = {transform.position.x}, z = {transform.position.z}");
    }

    void Update()
    {
        // Normally just move round the circle, but if hooked, move straight upwards.
        if (!hooked) {
            WalkHandler();
        } else {
            HookedHandler();
        }
    }

    void WalkHandler()
    {
        angle += speed * Time.deltaTime;
        float posX = (float)Math.Cos(angle)*radius;
        float posZ = (float)Math.Sin(angle)*radius;

        //orients the ducks to always face the origin at their height
        transform.LookAt(new Vector3(0, transform.position.y, 0));

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }

    void HookedHandler()
    {
        transform.position += new Vector3(0, 0.8f, 0);

        // When they get high enough, just kill them.
        if (transform.position.y > 400) {
            Destroy(gameObject);

            // @TODO: Player outlived a rival duck, increase score?
        }
    }

    void HandleHookCollision()
    {
        hooked = true;
    }

    void Quack()
    {
        print("Quack");
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.tag) {
            case "Hook":
                HandleHookCollision();
                break;
            default:
                Quack();
                break;
        }
    }
}
