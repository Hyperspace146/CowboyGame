using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats), typeof(PlayerInputHandler), typeof(PlayerMelee))]
[RequireComponent(typeof(Crosshair), typeof(Rigidbody2D))]

/*
 *  PlayerCharacterController reads player inputs from PlayerInputHandler and will produce actions 
 *  (e.g. shooting, moving) based on those inputs. Character actions/control can be disabled or enabled here.
 */
public class PlayerCharacterController : MonoBehaviour
{
    public Transform Crosshair;

    [Tooltip("The location between the ")]
    [Range(0f, 1f)]
    public float CameraOffset = 0.5f;

    private Vector2 displacement;
    private Vector2 rotation;
    private float moveSpeedMultiplier = 0.5f;
    
    private Rigidbody2D rb;
    private Transform cam;

    void Start()
    {
        //Manually set the Z pos so that the player is always in front of the background
        transform.position = new Vector3(transform.position.x, transform.position.y, 19);
        
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main.transform;

        //when the "InteractPressedOnInteractable" event is triggered, the interact method is initiated
        //Interactable.script.InteractableInRange += interact;
    }

    //physics
    void FixedUpdate()
    {
        //actually change the position of the character
        //still a lil' confused by Time.fixedDeltaTime, but I'll figure it out later
        rb.MovePosition(rb.position + displacement * Time.fixedDeltaTime);

        ShiftCamera();
    }

    void ShiftCamera()
    {
        /*int range = 20; //specified range at which moving the crosshair will have an affect on the camera's position
        float minX = rb.position.x - range;
        float maxX = rb.position.x + range;
        float minY = rb.position.y - range;
        float maxY = rb.position.y + range;*/

        float xPos = rb.position.x + (rb.position.x - Crosshair.transform.position.x) * CameraOffset;
        float yPos = rb.position.y + (rb.position.y - Crosshair.transform.position.y) * CameraOffset;

        cam.transform.position = new Vector3(xPos, yPos, -10);
    }
}