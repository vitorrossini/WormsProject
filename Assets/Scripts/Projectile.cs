using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
   // [SerializeField] private GameObject damageIndicatorPrefab;
   private int regularDamage = 20;
   private int floorDamage = 1;
   private bool isActive;

    public void Initialize(Vector3 direction)
    {
        isActive = true;
        

        projectileBody.AddForce(direction);
    }

       private void OnCollisionEnter(Collision collision)
    { 
        GameObject collisionObject = collision.gameObject;

          if (collisionObject.CompareTag("chicken"))
          {
              DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
              collisionObject.GetComponent<PlayerHealth>().TakeDamage(regularDamage);
              Destroy(gameObject);
          }
          
          else if (collisionObject.CompareTag("floor"))
          {
              DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
              collisionObject.GetComponent<TileHealth>().TakeDamage(floorDamage);
              Destroy(gameObject);
          }

          Destroy(gameObject);
       
        
        /*
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab); // i dont remember what this is, but i will leave it here for further study
        damageIndicator.transform.position = collision.GetContact(0).point;
        */
    }   
}
