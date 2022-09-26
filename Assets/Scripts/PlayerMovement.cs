using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float walkingSpeed = 10f;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
              if(Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal"),
                   Space.World);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"),
                   Space.World);
        }

        if(Input.GetKeyDown(KeyCode.B) && IsTouchingFloor())
        {
            rigidbody.AddForce(transform.up * 300);
        }

    }

    private bool IsTouchingFloor()
    {
        /*
         * Parameters: Center from where we shoot,radius of sphere, direction of sphere, hit parameter, distance of the sphere
         * 
         */
        RaycastHit hit;

        return Physics.SphereCast(transform.position, 0.05f, -transform.up, out hit, 1f); // creates a sphere to check if it hits something

    }
}
