using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerTurn playerTurn;
    [SerializeField] AudioSource jumpAudio;
    [SerializeField] AudioClip jump;
    private Animator animator;
    private float walkingSpeed = 5f;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
                animator.SetBool("Run", true);
            }



            //  }
        }

         bool IsTouchingFloor()
        {
            RaycastHit hit;

            return Physics.SphereCast(transform.position, 0.1f, -transform.up, out hit, 1f); // creates a sphere to check if it hits something. Mine isn't working as i hoped to, but i couldn't figure out why

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
            rb.AddForce(transform.up * 200);
            jumpAudio.PlayOneShot(jump);
            
        }





    }
}
