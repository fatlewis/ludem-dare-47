using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed;
    public float jumpSpeed;

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
        //input on x (horiz)
        float hAxis = Input.GetAxis("Horizontal");

        //input on y (vert)
        float vAxis = Input.GetAxis("Vertical");

        //Movement vector
        Vector3 movement = new Vector3(hAxis * walkingSpeed * Time.deltaTime, 0, vAxis * walkingSpeed * Time.deltaTime);

        //Calculate new position
        Vector3 newPos = transform.position + movement;

        //Move
        //rb.MovePosition(newPos);
        Vector3 direction = new Vector3(vAxis, 0, hAxis);
        float speed = walkingSpeed * Time.deltaTime;
        rb.AddRelativeForce(direction * speed);
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
