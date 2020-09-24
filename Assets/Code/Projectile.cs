using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Tooltip("Damage the projectile will deal")]
    public int Damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health victimHealth = collision.GetComponent<Health>();
        if (victimHealth != null)
        {
            victimHealth.ChangeHealth(-Damage);
        }
        Destroy(this.gameObject);
    }
}
