using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBarrel : MonoBehaviour
{
    [Tooltip("How fast the barrel rolls.")]
    public float BarrelSpeed;

    void Start()
    {
        GetComponent<Interactable>().OnInteract += RollBarrel;
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

        Vector2 rollDirection = Vector2.zero;

        // If the player is north of the barrel, roll the barrel down
        if (135.0f > angle && angle >= 45.0f)
        {
            rollDirection = Vector2.down;
        }
        // If the player is east of the barrel, roll the barrel west
        else if (45.0f > angle && angle >= -45.0f)
        {
            rollDirection = Vector2.left;
        }
        // If the player is south of the barrel, roll the barrel north
        else if (-45.0f > angle && angle >= -135.0f)
        {
            rollDirection = Vector2.up;
        }
        // If the player is west of the barrel, roll the barrel east
        else if ((180.0f >= angle && angle >= 135.0f) || (-135.0f > angle && angle >= -180.0f))
        {
            rollDirection = Vector2.right;
        }

        // Set the barrel in motion for a time in the determined direction
        GetComponent<Rigidbody2D>().AddForce(rollDirection * BarrelSpeed);
    }
}
