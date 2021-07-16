using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]

/*
 *  This script determines the position of the crosshair image based on the player's look input.
 */
public class Crosshair : MonoBehaviour
{
    [Tooltip("The location where bullets will shoot from on the character sprite.")]
    public Transform ShootPoint;

    [Tooltip("Affects the distance the crosshair object will be placed from the player's position.")]
    public float CrosshairDistanceMultiplier;

    [Tooltip("The sprite object used to represent the crosshair.")]
    public GameObject crosshair;

    private PlayerInputHandler input;

    void Start()
    {
        input = GetComponentInParent<PlayerInputHandler>();
    }
    
    void FixedUpdate()
    {
        // Place the crosshair based on look input
        crosshair.transform.position = (Vector2) ShootPoint.position + input.LookInput * CrosshairDistanceMultiplier;

        // Flip the character to face left/right depending on which direction we're looking
        if (input.LookInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);  // Face right
        }
        else if (input.LookInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);  // Face left
        }
    }
}
