using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int stepCount = 2;
    [SerializeField] private LineRenderer lineRenderer;


    public void DrawCurvedTrajectory(Vector3 force, Vector3 initialPosition)
    {
        
        float projectileMass = projectilePrefab.GetComponent<Rigidbody>().mass;
        Vector3 velocity = (force / projectileMass) * Time.fixedDeltaTime;
        float flightDuration = (2 * velocity.y) / -Physics.gravity.y;
        float stepTime = flightDuration / (float)stepCount;

        lineRenderer.positionCount = stepCount;

        for (int i = 0; i < stepCount; i++)
        {
            float timePassed = stepTime * i;
            float height = velocity.y * timePassed - (0.5f * -Physics.gravity.y * timePassed * timePassed);
            Vector3 curvePoint = initialPosition + new Vector3(velocity.x * timePassed, height, velocity.z * timePassed);
            lineRenderer.SetPosition(i, curvePoint);
        }
    }
}
