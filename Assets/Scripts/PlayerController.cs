using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed;
    public float jumpSpeed;

    //Rigidbody component
    Rigidbody rb;

    //Colider component
    Collider col;

    //Coin playing sound
    //public AudioSource coinSound;

    //size of the player
    Vector3 size;

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
        WalkHandler();
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
        rb.MovePosition(newPos);
    }

    void OnTriggerEnter(Collider other)
    {
        // if(other.CompareTag("Coin"))
        // {
        //     //increase score
        //     GameManager.gameManager.IncreaseScore(1);

        //     //play sound
        //     coinSound.Play();

        //     //Destroy coin
        //     Destroy(other.gameObject);
        // }
        if(other.CompareTag("Enemy"))
        {
            print("We have run into an enemy");

            //reset the game
            //GameManager.gameManager.ResetGame();
        }
    }
}
