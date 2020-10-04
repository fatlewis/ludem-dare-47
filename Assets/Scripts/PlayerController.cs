using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed;

    //Rigidbody component
    Rigidbody rb;

    //Colider component
    Collider col;

    //size of the player
    Vector3 size;

    bool hooked = false;

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
        col = GetComponent<Collider>();

        //get player size
        size = col.bounds.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hooked) {
            WalkHandler();
        } else {
            HookedHandler();
        }
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
        transform.position += new Vector3(0, 0.8f, 0);

        if (transform.position.y > 400) {
            Destroy(gameObject);

            // @TODO: Player is dead, end game sequence?
        }
    }

    void HandleHookCollision()
    {
        hooked = true;
        rb.useGravity = false;
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
