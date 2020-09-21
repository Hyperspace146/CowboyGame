using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int BaseMaxHealth;

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
    }

    public void RefillHealth()
    {
        isDead = false;
        health = maxHealth;
    }

    public void ChangeMaxHealth(int value)
    {
        maxHealth += value;
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }

    // Change the player's health by the given value 
    public void ChangeHealth(int value)
    {
        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Kill();
        }
    }

    // Handle the player's death
    void Kill()
    {
        if (Equals(this.gameObject.tag, "Player"))
        {
            // TODO: Disable any character control
            // temp: disabling sprite renderer
            spriteRenderer.enabled = false;
            // TODO: Play the death animation
            // After a certain amount of respawn time, respawn in a certain location
            respawnManager.RespawnPlayer(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
