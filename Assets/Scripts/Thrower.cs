using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] public TrajectoryLine trajectoryLine;
    // [SerializeField] private PlayerTurn playerTurn;
    private float speed = 200f;
    float timer = 0.0f;
    int seconds;
    bool maxTime = false;

    private void Start()
    {
        trajectoryLine.enabled = false;
        
    }


    private void Update()
    {
        /* bool IsPlayerTurn = playerTurn.IsPlayerTurn();                  // ainda não criei o turn manager
         trajectoryLine.enabled = IsPlayerTurn;
         if (IsPlayerTurn)
         {   */
        

        Vector3 force = (transform.forward * speed * timer + transform.up * speed * timer);

        if (Input.GetKey(KeyCode.Mouse0))
            {
            Timer();
            trajectoryLine.enabled = true;
            trajectoryLine.DrawCurvedTrajectory(force, shootingStartPosition.position);
            
            }
           
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
            // TurnManager.GetInstance().TriggerChangeTurn();
            
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<Projectile>().Initialize(force);
            trajectoryLine.DrawCurvedTrajectory(Vector3.zero, shootingStartPosition.position);
            ResetTimer();

            
            }

        
         
        }


    void Timer()
    {

        timer += Time.deltaTime;

        if(timer > 2f)
        {
            ResetTimer();
        }

    }

    void ResetTimer()
    {

     timer = 0.0f;
                // }
    }

    



   
}
