using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerTurn playerTurn;
    private Animator animator;
    private float walkingSpeed = 5f;
    private Rigidbody rigidbody;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                WalkHorizontal();

            }

            if (Input.GetAxis("Vertical") != 0)
            {
                WalkVertical();
            }

            if (Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0 || !IsTouchingFloor())
            {
                animator.SetBool("Run", false);

            }

            if (Input.GetKeyDown(KeyCode.B) && IsTouchingFloor())
            {
                Jump();
                animator.SetBool("Run", true);
            }



            //  }
        }

         bool IsTouchingFloor()
        {
            /*
             * Parameters: Center from where we shoot,radius of sphere, direction of sphere, hit parameter, distance of the sphere
             * 
             */
            RaycastHit hit;

            return Physics.SphereCast(transform.position, 0.1f, -transform.up, out hit, 1f); // creates a sphere to check if it hits something

        }

        void WalkHorizontal()
        {
            Vector3 directionZ = transform.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            transform.Translate(directionZ, Space.World);
            if (directionZ.magnitude > 0f)
            {
                animator.SetBool("Run", true);

            }

        }

        void WalkVertical()
        {
            Vector3 directionX = transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.Translate(directionX,
                Space.World);
            if (directionX.magnitude > 0f)
            {
                animator.SetBool("Run", true);

            }

        }

        void Jump()
        {
            rigidbody.AddForce(transform.up * 200);
            
        }





    }
}
