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
        DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
        collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(regularDamage);
        if (destruction == null)
        {
          
            //Destroy(collisionObject);

        }
       
        
        /*
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;
        */
    }   
}
