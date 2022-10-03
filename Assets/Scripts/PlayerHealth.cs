using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    [SerializeField] GameObject playerWin;
   

    

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerWin.SetActive(false);

        
        
    
    }

    // Update is called once per frame
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            
    }   }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Thrower>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<RotationalView>().enabled = false;

        playerWin.SetActive(true);
                  


    }

    private void OnCollisionEnter(Collision item)
    {
        if (item.gameObject.CompareTag("Items"))
        {
            currentHealth += 20;
            Destroy(item.gameObject);
        }
    }
}


