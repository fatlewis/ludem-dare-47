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
    bool hooked = false;

    void Start()
    {
        radius = (float)Math.Sqrt(Math.Pow(transform.position.x, 2) + Math.Pow(transform.position.z, 2));
        angle = (float)Math.Atan(transform.position.z / transform.position.x);
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

        transform.Rotate(Vector3.up * angleRot, Space.World);
        transform.position = new Vector3(posX, transform.position.y, posZ);
    }

    void HookedHandler()
    {
        transform.position += new Vector3(0, 0.3f, 0);

        // When they get high enough, just kill them.
        if (transform.position.y > 20) {
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
            case "Enemy":
                HandleHookCollision();
                break;
            default:
                Quack();
                break;
        }
    }
}
