using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField]private GameObject item;
   

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision item)
    {
        if(gameObject.CompareTag("chicken"))
        {
            item.gameObject.GetComponent<PlayerHealth>().currentHealth =+ 20;
            Destroy(gameObject);
        }
    }
}
