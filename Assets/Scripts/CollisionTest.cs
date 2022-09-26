using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("dead");
    }
}
