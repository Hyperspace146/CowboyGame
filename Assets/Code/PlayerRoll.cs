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
    
    private bool RollAvailable;
    private Rigidbody2D rb;
    private PlayerInputHandler input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    /* 
     * The character will roll unless currently in the duration of a roll.
     */
    public void TryRoll()
    {
        if (RollAvailable)
        {
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
        // TODO: Disable char control (still can look around though)
        rb.velocity = Vector2.zero;
        rb.AddForce(input.LookInput * RollVelocity);  // Assumes rb has no drag (else the roll would slow down I think)
        yield return new WaitForSeconds(RollDuration * (1 - RollInvulnerabilityRatio / 2));
        gameObject.layer = LayerMask.NameToLayer("Ignore Gunfire");
        yield return new WaitForSeconds(RollDuration * RollInvulnerabilityRatio);
        gameObject.layer = LayerMask.NameToLayer("Player");
        yield return new WaitForSeconds(RollDuration * (1 - RollInvulnerabilityRatio / 2));
        rb.velocity = Vector2.zero;
        // TODO: Reenable char control
    }
}
