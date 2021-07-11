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
    }
}
