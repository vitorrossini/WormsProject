using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerHealth playerHealth;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chicken"))
        {
            other.gameObject.GetComponent<PlayerHealth>().Heal(20);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision player)
    {
       
    }

   
}
