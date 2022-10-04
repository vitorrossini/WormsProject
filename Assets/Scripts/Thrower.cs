using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Thrower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] public TrajectoryLine trajectoryLine;
    [SerializeField] public PlayerTurn playerTurn;




    private float speed = 200f;
    float timer = 0.0f;
    private int timesShot = 0;
    

    private void Start()
    {
        trajectoryLine.enabled = false;
        

    }


    private void Update()
    {
       
        if (playerTurn.IsPlayerTurn() && !PauseMenu.gameIsPaused)
        {


            Vector3 force = (transform.forward * speed * timer + transform.up * speed * timer); // took hours to realize that what i needed was acceleration

           

            if (Input.GetKey(KeyCode.F))
            {
                Timer();
                trajectoryLine.enabled = true;
                trajectoryLine.DrawCurvedTrajectory(force, shootingStartPosition.position);

            }

            if (Input.GetKeyUp(KeyCode.F))
            {


                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<Projectile>().Initialize(force);
                trajectoryLine.DrawCurvedTrajectory(Vector3.zero, shootingStartPosition.position);
                ResetTimer();
                timesShot++;
                
                if (timesShot == 2) // changes turn every 2 throws
                {

                    TurnManager.GetInstance().TriggerChangeTurn();

                        timesShot = 0;
                }
            }

        }



            
    }


        void Timer()  // this was the moment i realized i could create timers for things. Awesome moment for me
        {

            timer += Time.deltaTime;

            if (timer > 2f)
            {
                ResetTimer();
            }



        }

        void ResetTimer()
        {

            timer = 0.0f;

        }
  
    
  
}

