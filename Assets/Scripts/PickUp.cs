using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
