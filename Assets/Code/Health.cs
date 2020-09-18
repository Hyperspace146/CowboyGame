using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int BaseMaxHealth;

    public int _maxHealth;      // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int _health;         // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public bool _isDead;        // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    RespawnManager _respawnManager;
    SpriteRenderer _spriteRenderer;  // temp

    void Start()
    {
        _respawnManager = FindObjectOfType<RespawnManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _maxHealth = BaseMaxHealth;
        _health = BaseMaxHealth;
        _isDead = false;
    }

    public void RefillHealth()
    {
        _isDead = false;
        _health = _maxHealth;
    }

    public void ChangeMaxHealth(int value)
    {
        _maxHealth += value;
        if (_maxHealth < 1)
        {
            _maxHealth = 1;
        }
    }

    // Change the player's health by the given value 
    public void ChangeHealth(int value)
    {
        _health += value;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        if (_health <= 0 && !_isDead)
        {
            _isDead = true;
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
            _spriteRenderer.enabled = false;
            // TODO: Play the death animation
            // After a certain amount of respawn time, respawn in a certain location
            _respawnManager.RespawnPlayer(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // TEMP
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeHealth(-10);
            Debug.Log(_health);
        }
    }
}
