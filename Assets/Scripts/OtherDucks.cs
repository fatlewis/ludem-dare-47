using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDucks : MonoBehaviour
{
    float speed;
    float angle;
    float radius;
    bool hooked = false;
    Transform hookLocation;

    // This is the required offset from the hook's transform to the duck's transform to make the hook line up with the loop
    Vector3 hookOffset = new Vector3(11, 13, 0);

    private AudioSource[] quacks;

    void Start()
    {
        quacks = GetComponents<AudioSource>();

        radius = (float)Math.Sqrt(Math.Pow(transform.position.x, 2) + Math.Pow(transform.position.z, 2));
        angle = (float)Math.Atan2(transform.position.z, transform.position.x);
        var rand = new System.Random((int)(angle + DateTime.Now.Millisecond));
        speed = (float)(0.5f*rand.NextDouble()) + 0.2f;
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
        transform.position = hookLocation.position + hookOffset;

        // When they get high enough, just kill them.
        if (transform.position.y > 140) {
            Destroy(gameObject);
        }
    }

    void HandleHookCollision(GameObject hook)
    {
        hooked = true;
        hookLocation = hook.transform;

        // Rotate the ducks so the hook is on the right place
        // TODO: Make it look nice whatever their rotation
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    void Quack()
    {
        System.Random rand = new System.Random();
        quacks[rand.Next(quacks.Length)].Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag) {
            case "Hook":
                HandleHookCollision(collision.gameObject);
                break;
            default:
                Quack();
                break;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Hook":
                HandleHookCollision(collider.gameObject);
                break;
            default:
                Quack();
                break;
        }
    }
}
