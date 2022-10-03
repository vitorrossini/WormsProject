using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesMenu : MonoBehaviour
{
    [SerializeField]public GameObject rules;
    [SerializeField]public GameObject pause;
    public void Start()
    {
        rules.SetActive(true);
        
        pause.SetActive(false);
        
    }

    public void GoBack()
    {
        pause.SetActive(true);
        
        rules.SetActive(false);
    }
}
