using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public Transform spawnPoint;

    public void OnCollisionEnter(Collision collision)
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CapsulePlayer") )
        {
            Debug.Log("Player hit me!");

            other.gameObject.transform.position = spawnPoint.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
