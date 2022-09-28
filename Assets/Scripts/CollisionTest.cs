using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CollisionTest : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        

        
    }

   private void OnTriggerEnter(Collider other)
   {
       
       other.gameObject.GetComponent<Thrower>().enabled = false;
      other.gameObject.GetComponent<PlayerMovement>().enabled = false;
      other.gameObject.GetComponent<RotationalView>().enabled = false;


      if (other.TryGetComponent(out DestructionFree free))
      {
          //free.gameObject
      }
   }

   //trhoemrore = collisionObject.GetComponent<DestructionFree>();
}
