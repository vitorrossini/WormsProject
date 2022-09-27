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
    int seconds;
    bool maxTime = false;
    private int timesShot = 0;

    private void Start()
    {
        trajectoryLine.enabled = false;

    }


    private void Update()
    {
       
        if (playerTurn.IsPlayerTurn())
        {


            Vector3 force = (transform.forward * speed * timer + transform.up * speed * timer);

           

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Timer();
                trajectoryLine.enabled = true;
                trajectoryLine.DrawCurvedTrajectory(force, shootingStartPosition.position);

            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {


                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<Projectile>().Initialize(force);
                trajectoryLine.DrawCurvedTrajectory(Vector3.zero, shootingStartPosition.position);
                ResetTimer();
                timesShot++;
                
                if (timesShot >= 2)
                {
                    TurnManager.GetInstance().TriggerChangeTurn();
                    timesShot = 0;
                    
                }


            }



            //}
        }


        void Timer()
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
}

