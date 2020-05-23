using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool pickedUp = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !pickedUp)
        {
            PlayerData data = other.gameObject.GetComponent<PlayerData>();
            data.ChangeScore();
            pickedUp = true;
        }
    }
}
