using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler), typeof(Rigidbody2D))]

/*
* Gives the player the ability to roll. For the duration of the roll, the player is invlunerable
* and cannot move or do other actions.
*/
public class PlayerRoll : MonoBehaviour
{
    [Tooltip("The duration of the roll in seconds.")]
    public float RollDuration = 5f;

    [Tooltip("Proportional to fast the player will be moving during the roll.")]
    public float RollVelocity = 10f;

    [Tooltip("The ratio of the duration of the roll during which the player will be " +
        "invulnerable. The invulnerability time will take place in the middle of the roll, " +
        "meaning the player will be vulnerable during the starting and final portion of the" +
        "roll if the ratio is not 1.")]
    [Range(0f, 1f)]
    public float RollInvulnerabilityRatio = 0.7f;

    private bool RollAvailable = true;
    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        sprite = GetComponent<SpriteRenderer>();

        input.OnRollInputDown.AddListener(TryRoll);
    }

    /* 
     * The character will roll unless currently in the duration of a roll.
     */
    public void TryRoll()
    {
        print("tried roll");
        if (RollAvailable && input.PlayerActionsEnabled)
        {
            print("rolling!");
            StartCoroutine(Roll());
        }
    } 

    /* 
     * Method that begins the roll action and handles movement, invulnerability, and 
     * disabling/enabling character control using the above timing parameters 
     * (duration and invulnerability ratio).
     */
    IEnumerator Roll()
    {
        // Disable character control
        input.PlayerActionsEnabled = false;
        input.PlayerMovementEnabled = false;

        // Set the player moving at a constant velocity
        rb.velocity = (input.MoveInput.normalized * RollVelocity);

        // Make the player invlunerable (and part transparent to show this) in the middle portion of the roll
        yield return new WaitForSeconds(RollDuration * ((1 - RollInvulnerabilityRatio) / 2));
        gameObject.layer = LayerMask.NameToLayer("Ignore Gunfire");
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 150);
        yield return new WaitForSeconds(RollDuration * RollInvulnerabilityRatio);
        gameObject.layer = LayerMask.NameToLayer("Player");
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255);
        yield return new WaitForSeconds(RollDuration * ((1 - RollInvulnerabilityRatio) / 2));

        // Stop the player
        rb.velocity = Vector2.zero;

        // Reenable character control
        input.PlayerActionsEnabled = true;
        input.PlayerMovementEnabled = true;  // i feel like there's some bugs in the making with this method, but uh yea
    }
}
