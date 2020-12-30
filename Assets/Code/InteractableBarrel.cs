using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class InteractableBarrel : MonoBehaviour
{
    [Tooltip("How fast the barrel rolls.")]
    public float BarrelSpeed;

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

        // Set the barrel in motion for a time in the determined direction
        rb.velocity = (rollDirection * BarrelSpeed);
    }

    // If we collide into anything, stop moving
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider2D barrelCollider = GetComponentInChildren<BoxCollider2D>();  // Solid hitbox is stored in child object
        float leftSideOfCollider = barrelCollider.bounds.center.x - barrelCollider.bounds.extents.x;
        float rightSideOfCollider = barrelCollider.bounds.center.x + barrelCollider.bounds.extents.x;
        float topSideOfCollider = barrelCollider.bounds.center.y + barrelCollider.bounds.extents.y;
        float bottomSideOfCollider = barrelCollider.bounds.center.y - barrelCollider.bounds.extents.y;

        Vector2 contactPoint = collision.GetContact(0).point;

        Debug.Log(contactPoint);

        Debug.Log(topSideOfCollider);

        // If we have a collision on the side of the collider in which we are rolling towards, stop
        // the barrel from moving
        if (contactPoint.x == leftSideOfCollider && rollDirection == Vector2.left
            || contactPoint.x == rightSideOfCollider && rollDirection == Vector2.right
            || contactPoint.y == topSideOfCollider && rollDirection == Vector2.up
            || contactPoint.x == bottomSideOfCollider && rollDirection == Vector2.down)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
