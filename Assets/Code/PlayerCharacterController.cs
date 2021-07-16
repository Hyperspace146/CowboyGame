using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  description needed
 */
public class PlayerCharacterController : MonoBehaviour
{
    [Tooltip("The larger the value, the more the player's current speed stat affects move speed.")]
    public float MoveSpeedStatMultiplier = 0.5f;

    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private PlayerStats playerStats;
    private Animator animator;

    void Start()
    {
        //Manually set the Z pos so that the player is always in front of the background
        transform.position = new Vector3(transform.position.x, transform.position.y, 19);
        
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
    }

    //physics
    void FixedUpdate()
    {
        // Have the displacement when moving scale with the player's current speed stat
        Vector2 displacement = input.MoveInput * Time.fixedDeltaTime * (1 + playerStats.speed * MoveSpeedStatMultiplier);
        rb.MovePosition(rb.position + displacement);
        animator.SetFloat("Speed", displacement.magnitude);
    }
}