﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed;

    //Rigidbody component
    Rigidbody rb;

    bool hooked = false;
    Transform hookLocation;

    // This is the required offset from the hook's transform to the duck's transform to make the hook line up with the loop
    Vector3 hookOffset = new Vector3(11, 13, 0);

    // Start is called before the first frame update
    void Start()
    {
        Material playerMaterial = GameManager.gameManager.GetMaterial();
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in childRenderers) {
            if (r.gameObject.tag == "ColouredPart") {
                r.material = playerMaterial;
            }
        }

        rb = GetComponent<Rigidbody>();

        if (GameManager.gameManager.IsMusicEnabled())
        {
            GameManager.gameManager.PlayGameMusic();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hooked) {
            WalkHandler();
        } else {
            HookedHandler();
        }
        GameManager.gameManager.IncreaseScore(Time.deltaTime);
    }

    void WalkHandler()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float rotationSpeed = 100;
        transform.Rotate(0f, hAxis * rotationSpeed * Time.deltaTime, 0f);

        // Correct for weird default duck rotation
        Vector3 forwardDirection = Vector3.right;
        float speedAmplifier = 1000;

        rb.AddRelativeForce(forwardDirection * vAxis * walkingSpeed * speedAmplifier * Time.deltaTime);
    }

    void HookedHandler()
    {
        transform.position = hookLocation.position + hookOffset;

        if (transform.position.y > 140) {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }
    }

    void HandleHookCollision(GameObject hook)
    {
        hooked = true;
        rb.useGravity = false;

        hookLocation = hook.transform;

        // Rotate the ducks so the hook is on the right place
        // TODO: Make it look nice whatever their rotation
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag) {
            case "Hook":
                HandleHookCollision(other.gameObject);
                break;
        }
    }
}
