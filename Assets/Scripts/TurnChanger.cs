using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnChanger : MonoBehaviour
{
   /* private static TurnChanger instance;
    [SerializeField] private PlayerTurn one;
    [SerializeField] private PlayerTurn two;
    [SerializeField] private float timeBetweenTurns = 2f;
    [SerializeField] private Camera cam0;
    [SerializeField] private Camera cam1;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 0;
            one.SetPlayerTurn(0);
            two.SetPlayerTurn(1);
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 2;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return  false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnChanger GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 0)
        {
            currentPlayerIndex = 1;
            cam0.gameObject.SetActive(false);
            cam1.gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 0;
            cam0.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
        }
    }*/
}
