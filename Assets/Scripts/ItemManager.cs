using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private TurnManager turnManager;
    private static ItemManager instance;
    [SerializeField] GameObject purpleEgg;
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
        

        if (turnManager.turnNum % 3 == 0)
        {
            GameObject newPickup = Instantiate(purpleEgg);  // spawn when it reaches x turns (ask turn manager)
            newPickup.transform.position = new Vector3(Random.Range(-2f, 2f), 2f, Random.Range(-2f, 2f));
            newPickup.transform.position = new Vector3(Random.Range(-2f, 2f), 2f, Random.Range(-2f, 2f));
            newPickup.transform.position = new Vector3(Random.Range(-2f, 2f), 2f, Random.Range(-2f, 2f));
            newPickup.transform.position = new Vector3(Random.Range(-2f, 2f), 2f, Random.Range(-2f, 2f));
            newPickup.transform.position = new Vector3(Random.Range(-2f, 2f), 2f, Random.Range(-2f, 2f));

        }

    }



}
