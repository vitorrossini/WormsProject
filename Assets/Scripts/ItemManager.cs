using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    
    private static ItemManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static ItemManager GetInstance()
    {
        return instance;
    }
   
    private void Update()
    {                                  
        

        
    }



}
