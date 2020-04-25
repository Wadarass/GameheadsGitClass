using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed; //Amount of units to move per second
    
    //Amount of degrees per second to turn
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 currentSpeed = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed.x = -speed.x; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed.x = speed.x;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed.z = speed.z;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed.z = -speed.z;
        }

        //Speed is a Vector3 defines how fast to move in 3D space
        gameObject.transform.Translate(currentSpeed * Time.deltaTime);
    }*/

    void Update()
    {
        float currentSpeed = 0.0f;
        float currentTurnAmount = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            currentTurnAmount -= turnSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentTurnAmount += turnSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = speed.x;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = -speed.x;
        }

        //Speed is a Vector3 defines how fast to move in 3D space
        gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
        gameObject.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
