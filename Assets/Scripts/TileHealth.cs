using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip crack;
    
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 2)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0.5f, 0.4f, 1f);
        }
        
        if (currentHealth == 1)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f,0f,0f,1f);
        }
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audioSource.PlayOneShot(crack);
    }

    
}
