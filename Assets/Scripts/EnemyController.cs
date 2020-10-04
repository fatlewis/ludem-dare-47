using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;

    public float rangeY = 3;

    Vector3 initialPos;

    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movementY = speed * Time.deltaTime * direction;

        float newY = transform.position.y + movementY;

        if(Mathf.Abs(newY - initialPos.y) > rangeY)
        {
        	direction *= -1;
        }
        else
        {
        	if(direction == -1)
        	{
        		transform.position += new Vector3(0, (movementY * 1.2f), 0);
        	}
        	else
        	{
        		transform.position += new Vector3(0, movementY, 0);        		
        	}
        }
    }
}
