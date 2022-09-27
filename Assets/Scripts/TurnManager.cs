
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;

    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns = 2f;
    [SerializeField] private Camera cam0;
    [SerializeField] private Camera cam1;

    public int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;

    public static TurnManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 0;
            playerOne.SetPlayerTurn(0);
            playerTwo.SetPlayerTurn(1);
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if(turnDelay>= timeBetweenTurns)
            {
                turnDelay = 2;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    private bool IsPlayerTurn(int index)
    {
        if(waitingForNextTurn)
        {
            return false;
        }
        return index == currentPlayerIndex;
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
        else if (currentPlayerIndex ==1)
        {
            currentPlayerIndex = 0;
            cam0.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
        }
    }


  }

