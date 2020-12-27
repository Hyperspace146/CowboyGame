﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int BaseMaxHealth;
    public UnityAction OnDeath;

    private int maxHealth;      
    private int health;         
    private bool isDead;        
    RespawnManager respawnManager;
    SpriteRenderer spriteRenderer;  // temp

    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = BaseMaxHealth;
        health = BaseMaxHealth;
        isDead = false;

        if (BaseMaxHealth < 0)
        {
            Debug.LogWarning("Player Base Health is negative.");
        }
    }

    public void RefillAllHealth()
    {
        isDead = false;
        health = maxHealth;
    }

    public void ChangeMaxHealth(int value)
    {
        if (!isDead)
        {
            maxHealth += value;
            if (maxHealth < 1)
            {
                maxHealth = 1;
            }
        }
    }

    // Change the player's health by the given value 
    public void ChangeHealth(int value)
    {
        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0 && !isDead)
        {
            Kill();
        }
    }

    // Handle the player's death
    void Kill()
    {
        Debug.Log("killed");

        isDead = true;

        if (OnDeath != null)
        {
            OnDeath.Invoke();
        }

        if (Equals(this.gameObject.tag, "Player"))
        {
            // Disable any character control
            PlayerCharacterController playerCharacterController = GetComponent<PlayerCharacterController>();
            playerCharacterController.PlayerActionsEnabled = false;
            playerCharacterController.PlayerControlEnabled = false;

            // TODO: Play the death animation


            // TODO: Set up respawning the player
            //respawnManager.RespawnPlayer(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
