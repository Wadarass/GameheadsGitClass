using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed; //Amount of units to move per second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}
