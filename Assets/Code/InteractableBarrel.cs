using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class InteractableBarrel : MonoBehaviour
{
    [Tooltip("How fast the barrel rolls.")]
    public float BarrelSpeed;
    [Tooltip("The solid, non-trigger collider for this barrel.")]
    public BoxCollider2D SolidCollider;

    private Rigidbody2D rb;
    private Vector2 rollDirection;  // The direction the barrel is rolling in

    void Start()
    {
        GetComponent<Interactable>().OnInteract += RollBarrel;
        rb = GetComponent<Rigidbody2D>();
        rollDirection = Vector2.zero;
    }

    // Depending on the angle of the player's position relative to the barrel, roll the barrel
    // up, down, left or right
    void RollBarrel(GameObject playerRollingTheBarrel)
    {
        // Find the angle in degrees of the player's position relative to the barrel's position.
        // Mathf.Atan2 returns an angle between -180 and 180
        float y = playerRollingTheBarrel.transform.position.y - transform.position.y;
        float x = playerRollingTheBarrel.transform.position.x - transform.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        rollDirection = Vector2.zero;

        // If the player is north of the barrel, roll the barrel down
        if (135.0f > angle && angle >= 45.0f)
        {
            rollDirection = Vector2.down;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        // If the player is east of the barrel, roll the barrel west
        else if (45.0f > angle && angle >= -45.0f)
        {
            rollDirection = Vector2.left;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        // If the player is south of the barrel, roll the barrel north
        else if (-45.0f > angle && angle >= -135.0f)
        {
            rollDirection = Vector2.up;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        // If the player is west of the barrel, roll the barrel east
        else if ((180.0f >= angle && angle >= 135.0f) || (-135.0f > angle && angle >= -180.0f))
        {
            rollDirection = Vector2.right;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        // Only if casting in the direction that the barrel would roll towards encounters no hits
        // (no obstructing objects), roll the barrel
        float castDistance = 0.1f;
        if (SolidCollider.Cast(rollDirection, new RaycastHit2D[1], castDistance, true) == 0)
        {
            // Set the barrel in motion for a time in the determined direction
            rb.velocity = (rollDirection * BarrelSpeed);
        }
    }

    // This method is called when the child object with the solid hitbox collides with something.
    // Here, we check if the barrel had run into an object in the direction it was moving; if so,
    // stop the barrel in its tracks
    void ChildOnCollisionEnter2D(Collision2D collision)
    {
        // If the cast in the direction that the barrel is rolling towards encounters any hits, stop
        // the barrel from rolling
        float castDistance = 0.1f;
        if (SolidCollider.Cast(rollDirection, new RaycastHit2D[1], castDistance, true) > 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
