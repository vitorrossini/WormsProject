using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    [SerializeField] GameObject otherPlayerWins;
    [SerializeField] GameObject playerWin;
    [SerializeField] AudioSource sfxPlayer;
    [SerializeField] public AudioClip damageSfx;
    [SerializeField] public AudioClip ded;
    [SerializeField] public AudioClip pickupSound;
    [SerializeField] GameObject player;
    [SerializeField] GameObject otherPlayer;
    
   

    

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        otherPlayerWins.SetActive(false);

        
        
    
    }

    // Update is called once per frame
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            sfxPlayer.PlayOneShot(ded);
        }   

        if(otherPlayer.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            playerWin.SetActive(true);
        }   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        sfxPlayer.PlayOneShot(damageSfx);
    }         

    public void Heal(int healthItem)
    {
        currentHealth += healthItem;
        healthBar.SetHealth(currentHealth);
        sfxPlayer.PlayOneShot(pickupSound);
    }

    public void Die()
    {
        Cursor.visible = true;
        player.SetActive(false);
        Time.timeScale = 0f;
        otherPlayerWins.SetActive(true);
        
       /* if (gameObject.GetComponent<PlayerTurn>().IsPlayerTurn()) // i wrote this cause i had a problem when the player died and his camera was disabled, i had no screen to render anymore.
        {
            TurnManager.GetInstance().ChangeTurn();
        }*/

    }

    
}


