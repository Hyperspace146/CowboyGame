using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Health victimHealth = collision.GetComponent<Health>();
        if (victimHealth != null)
        {
            int damage = GetComponentInParent<PlayerWeaponManager>().Damage;
            victimHealth.ChangeHealth(-damage);
        }
        Destroy(this.gameObject);
    }
}
