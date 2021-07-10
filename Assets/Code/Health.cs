using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int BaseMaxHealth;
    [Tooltip("If this GameObject is a player, it needs to know its character prefab so it can respawn.")]
    public GameObject CharacterPrefab;

    public event UnityAction OnHealthChange;
    public event UnityAction OnDeath;

    public int maxHealth { get; private set; }
    public int health { get; private set; }
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
            if (OnHealthChange != null)
            {
                OnHealthChange.Invoke();
            }

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
        if (OnHealthChange != null)
        {
            OnHealthChange.Invoke();
        }

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
            PlayerInputHandler inputHandler = GetComponent<PlayerInputHandler>();
            inputHandler.ActionInputEnabled = false;
            inputHandler.MoveInputEnabled = false;

            // TODO: Play the death animation

            
            respawnManager.RespawnPlayer(CharacterPrefab);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
