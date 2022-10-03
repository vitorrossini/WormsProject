using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurn : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("NextTurn");
    }
}
