using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CollisionTest : MonoBehaviour   // it started as a test, but became the dropping in the ocean script
{
   private PlayerHealth playerHealth;
    private int instantDeath = 100;

    private void Start()
    {
        

        
    }

   private void OnTriggerEnter(Collider other )
   {
       GameObject otherObject = other.gameObject;
       
       
       if( otherObject.CompareTag("chicken"))

       {
           otherObject.GetComponent<PlayerHealth>().TakeDamage(instantDeath);
           otherObject.GetComponent<Thrower>().enabled = false;
           otherObject.GetComponent<PlayerMovement>().enabled = false;
           otherObject.GetComponent<RotationalView>().enabled = false;
           Debug.LogError("ded chinken");
       }

   }
   


   //trhoemrore = collisionObject.GetComponent<DestructionFree>();
}
