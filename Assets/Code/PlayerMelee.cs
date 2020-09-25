using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [Tooltip("Time in seconds between input and the appearance of the hitbox")]
    public float StartupTime;
    [Tooltip("Time in seconds the melee hitbox will last")]
    public float ActiveTime;
    [Tooltip("Time in seconds the between the disappearance of the hitbox and " +
        "being actionable again")]
    public float RecoveryTime;
    [Tooltip("The number of health points that the melee attack will deal")]
    public int Damage;
    [Tooltip("The hitbox object child to this one ")]
    public CircleCollider2D MeleeHitbox;
    [Tooltip("The distance from the player that at which the melee attack hitbox will originate")]
    public float MeleeHitboxOffset;

    private PlayerInputHandler inputHandler;

    void Start()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        if (inputHandler.GetMeleeInputDown()) 
        {
            MeleeAttack();
        }
    }

    // Performs the melee attack by enabling the hitbox in the current look direction, all
    // in accordance with the attack's given startup, active, and recovery time.
    void MeleeAttack()
    {
        StartCoroutine(MeleeAttackCoroutine());
    }

    // Helper method that allows the melee attack to follow startup, active, and recovery time
    // in real-time seconds
    IEnumerator MeleeAttackCoroutine()
    {
        // TODO: make inactionable (to rolls, interact, shoot, anything but walk). In inputHandler?
        // TODO: Apply knockback

        // Update the position of the melee hit box to be in the direction the player is facing
        // at the right offset. It's a circle collider, so we can disregard rotating the collider
        MeleeHitbox.GetComponent<Transform>().position = inputHandler.GetLookInput().normalized
            * MeleeHitboxOffset;

        yield return new WaitForSeconds(StartupTime);

        // Reenable the hitbox
        MeleeHitbox.enabled = true;
        // Have the game ignore collisions between the player and their own melee hitbox.
        // Must be called everytime after enabling since the ignore collision will be lost
        // after the hitbox is disabled again
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), MeleeHitbox);  

        yield return new WaitForSeconds(ActiveTime);

        // Disable the hitbox after waiting the active time
        MeleeHitbox.enabled = false;

        yield return new WaitForSeconds(RecoveryTime);

        // TODO: make actionable
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Maybe should use OnTriggerStay2D for consistent detection. Needs testing

        Debug.Log("Melee hit!");

        // Apply damage if the collision happens with an object with Health (table, player, etc.)
        Health victimHealth = collision.GetComponent<Health>();
        if (victimHealth != null)
        {
            victimHealth.ChangeHealth(-Damage);
        }
    }*/
}
