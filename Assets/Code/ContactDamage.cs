﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class ContactDamage : MonoBehaviour
{
    // This value is usually assigned by a different script, the one that instantiated/activated 
    // this object
    public int Damage;
    public bool DestroyThisOnCollisions;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health victimHealth = collision.GetComponent<Health>();
        if (victimHealth != null)
        {
            victimHealth.ChangeHealth(-Damage);
        }
        if (DestroyThisOnCollisions)
        {
            Destroy(this.gameObject);
        }
    }
}