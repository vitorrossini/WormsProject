using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
   // [SerializeField] private GameObject damageIndicatorPrefab;
   private int regularDamage = 20;
   private int floorDamage = 1;
   public PlayerHealth playerhealth;
    private bool isActive;

    public void Initialize(Vector3 direction)
    {
        isActive = true;
        

        // -------- This method is for projectiles that have a parabole. ----------
        // We add a force only once, not every frame
        // Make sure to have "useGravity" toggled on in the rigid body
        projectileBody.AddForce(direction);
    }

    void Update()
    {
        if (isActive)
        {
            // -------- This method is for projectiles that go in a straight line. ----------
            // We change the position every frame
            // Make sure to have "useGravity" toggled off in the rigid body, otherwise it will fall as it flies (unless thats what you want)

            // Use either the following line (movement with the rigid body)
            //projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

            // or this one (movement with the transform), both are ok
            //transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        GameObject collisionObject = collision.gameObject;

          if (collisionObject.CompareTag("chicken"))
          {
              DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
              collisionObject.GetComponent<PlayerHealth>()?.TakeDamage(regularDamage);
              Destroy(gameObject);
          }
          
          else if (collisionObject.CompareTag("floor"))
          {
              DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
              collisionObject.GetComponent<TileHealth>()?.TakeDamage(floorDamage);
              Destroy(gameObject);
          }

          Destroy(gameObject);
       
        
        /*
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab); // i dont remember what this is, but i will leave it here for further study
        damageIndicator.transform.position = collision.GetContact(0).point;
        */
    }   
}
