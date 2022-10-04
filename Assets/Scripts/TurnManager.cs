
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [Header("Player Turn")]
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns = 3f;
    [SerializeField] private Camera cam0;
    [SerializeField] private Camera cam1;
    [SerializeField] private GameObject turnUI;
    private float turnDelay;
    public int turnNum = 1;
    public int currentPlayerIndex;
    private bool waitingForNextTurn;
    private PlayerHealth playerHealth;
    



    [Header("Item Spawn")]

    [SerializeField] private GameObject spawnItem;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform spawnPosition2;
    public int itemTime = 0;



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
            turnUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            
            turnDelay += Time.deltaTime;
            if (turnDelay >= 0.5f)
            {
                turnUI.SetActive(true); // starts the next turn UI
            }
            
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }

        if (itemTime == 3 )                // spawn an item every 3 turns 
        {
            ItemTime();
            

        }

        

    }

        private void ItemTime()                    // spawning the item
        {
           GameObject newPickup = Instantiate(spawnItem);
           GameObject newPickup2 = Instantiate(spawnItem);
           newPickup.transform.position = spawnPosition.position;

           newPickup2.transform.position = spawnPosition2.position;

           itemTime = 0;

        }

        public bool IsItPlayerTurn(int index)
        {
            if (waitingForNextTurn)
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
            else if (currentPlayerIndex == 1)
            {
                currentPlayerIndex = 0;
                cam0.gameObject.SetActive(true);
                cam1.gameObject.SetActive(false);
            } 
            
            turnUI.SetActive(false);  // hides the next turn UI 
            turnNum++;
            itemTime++;
    }


}


