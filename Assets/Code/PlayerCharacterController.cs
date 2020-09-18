using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody2D rb;
    public Transform cam; //Transform provides information about position, rotation, and scale

    private Vector2 displacement;
    private Vector2 rotation;
    private Vector2 crosshairPos;

    private PlayerInputHandler inputHandler; //get the inputhandler script so we have access to its methods from here
    private GameObject crosshair;
    private Crosshair crosshairScript;

    void Start() {
        //store the player's playerinputhandler script here
        //so that we have access to its methods
 
        inputHandler = GetComponent<PlayerInputHandler>();
        crosshair = GameObject.FindWithTag("Crosshair");
        crosshairScript = crosshair.GetComponent<Crosshair>();
    }

    /*
    PlayerCharacterController - handles movement using the info from PlayerInputHandler
    has a field that disables/enables player control (for during cutscenes and stuff) 
    void HandleCharacterMovement() (called in void Update()): handles camera, aiming, rotating, and moving based on inputs
    */

    //input
    void Update() {
        //HandleCharacterActions();
        HandleCharacterMovement();
    }

    void ShiftCamera() {
        //have the camera follow the player
        //implement functionality that makes it so the camera follows the crosshair(up to a certain extent)
        float offset = .5f;

 
        int range = 20; //specified range at which moving the crosshair will have an affect on the camera's position
        float minX = rb.position.x - range;
        float maxX = rb.position.x + range;
        float minY = rb.position.y - range;
        float maxY = rb.position.y + range;

        float xPos = Mathf.Clamp((rb.position.x + crosshairPos.x) * offset, minX, maxX);
        float yPos = Mathf.Clamp((rb.position.y + crosshairPos.y) * offset, minY, maxY);

        cam.transform.position = new Vector3(xPos, yPos, cam.transform.position.z);
       
    }
    
    void HandleCharacterMovement() {
        displacement = moveSpeed * inputHandler.GetMoveInput();
        crosshairPos = crosshairScript.GetCrosshairPos();
    }

    //physics
    void FixedUpdate() {
        
        //actually change the position of the character
        //still a lil' confused by Time.fixedDeltaTime, but I'll figure it out later
        rb.MovePosition(rb.position + displacement * Time.fixedDeltaTime);

        //atan2 uses trig to find the angle 
        float angle = Mathf.Atan2(crosshairPos.y, crosshairPos.x) * Mathf.Rad2Deg - 90f; //offset by 90
        rb.rotation = angle; //finally, change the player's rotation based on crosshair vector
        ShiftCamera();

    }


/*
    //checks if player chooses to do an action
    //actions such as: shoot, melee, ability, interact
    //if a player decides to do an action, a method from another class will be called
    //ex: to fire, we'll call another function which will spawn a bullet
    void HandleCharacterActions() {
        
        //These are just tests to make sure the methods work just the way we need them
        if (inputHandler.GetFireInputHeld()) {
            Debug.Log("fire button is held down");
        } 
        if (inputHandler.GetFireInputUp()) {
            Debug.Log("Done shooting");
        }

    }
*/
    /* ***METHODS OF PLAYER INPUT HANDLER(a "- 1" means that the method has already been incorporated to this class)
    Vector2 GetMoveInput(): returns the input axis for movement in Vector2 form - 1
    float GetLookInput(): returns the value of the axis for looking/aiming (crosshair or controller stick) - 1
    bool GetRollInputDown(): returns true when the roll button is initially pressed down
    bool GetRollInputHeld(): returns true when the roll button is currently pressed down
    bool GetRollInputUp(): returns true when the roll button is released
    bool GetFireInputDown(): returns true when the shoot button is initially pressed down
    bool GetFireInputHeld(): returns true when the shoot button is currently pressed down
    bool GetFireInputUp(): returns true when the shoot button is released
    bool GetMeleeInputDown(): returns true when the melee button is initially pressed down
    bool GetMeleeInputHeld(): returns true when the melee button is currently pressed down
    bool GetMeleeInputUp(): returns true when the melee button is released
    bool GetAbilityInputDown(): returns true when the ability button is initially pressed down
    bool GetAbilityInputHeld(): returns true when the ability button is currently pressed down
    bool GetAbilityInputUp(): returns true when the ability button is released
    bool GetInteractInputDown(): returns true when the interact button is initially pressed down
    bool GetInteractInputHeld(): returns true when the interact button is currently pressed down
    bool GetInteractInputUp(): returns true when the interact button is released
    */





}