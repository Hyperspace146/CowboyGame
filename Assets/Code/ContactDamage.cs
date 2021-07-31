using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ContactDamage : MonoBehaviour
{
    // This value is usually assigned by a different script, the one that instantiated/activated 
    // this object
    public int Damage;

    [Tooltip("If true, destroys this object immediately after contact.")]
    public bool DestroyThisOnCollisions;

    [Tooltip("If true, disables collisions with any victims it comes in contact with " +
        "immediately after contact.")]
    public bool DisableCollisionsWithVictim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health victimHealth = collision.GetComponentInParent<Health>();
        if (victimHealth != null)
        {
            victimHealth.ChangeHealth(-Damage);
        }
        if (DisableCollisionsWithVictim)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
        if (DestroyThisOnCollisions)
        {
            Destroy(this.gameObject);
        }
    }
}
