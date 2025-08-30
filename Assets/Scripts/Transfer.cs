using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Teleport : MonoBehaviour
{
    public Transform teleportDestination; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            if(teleportDestination != null)
            other.transform.position = teleportDestination.position; 
        }
    }
}


