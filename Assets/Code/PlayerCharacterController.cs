using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats), typeof(PlayerInputHandler), typeof(Rigidbody2D))]
[RequireComponent(typeof(Crosshair))]

public class PlayerCharacterController : MonoBehaviour {

    public Rigidbody2D rb;
    public Transform cam; //Transform provides information about position, rotation, and scale

    private Vector2 displacement;
    private Vector2 rotation;
    private Vector2 crosshairPos;
    private float moveSpeedMultiplier = 0.5f;

    public PlayerInputHandler inputHandler; //get the inputhandler script so we have access to its methods from here
    private PlayerStats playerStats;
    private GameObject crosshair;
    private Crosshair crosshairScript;

    public float RollInvulnerabilityTime; //time that player is invulnerable while rolling
    public float RollCooldownTime;
    private float TimeOfLastRoll;
    private bool RollAvailable;

    public bool PlayerControlEnabled;

    void Start() {

        RollInvulnerabilityTime = 5f;
        RollCooldownTime = 5f;
        //Debug.Log(RollCooldownTime + " " + RollInvulnerabilityTime);
        
        PlayerControlEnabled = true;
        TimeOfLastRoll = float.NegativeInfinity; //this is so we have a roll available from the start
        //store the player's playerinputhandler script here
        //so that we have access to its methods
 
        inputHandler = GetComponent<PlayerInputHandler>();
        playerStats = GetComponent<PlayerStats>();
        crosshair = GameObject.FindWithTag("Crosshair");
        crosshairScript = crosshair.GetComponent<Crosshair>();

        //when the "InteractPressedOnInteractable" event is triggered, the interact method is initiated
        //Interactable.script.InteractableInRange += interact;
        

    }

    public void DisableCharacterControl() {
        PlayerControlEnabled = false;
    }


    /*
    PlayerCharacterController - handles movement using the info from PlayerInputHandler
    has a field that disables/enables player control (for during cutscenes and stuff) 
    void HandleCharacterMovement() (called in void Update()): handles camera, aiming, rotating, and moving based on inputs
    */

    //input
    void Update() {
        
        if (PlayerControlEnabled) {
            HandleCharacterMovement();
            HandleCharacterActions();
        }

        //TestInputCommands();
       
    }

    void HandleCharacterActions() {
        
        //roll
        RollAvailable = (Time.time - TimeOfLastRoll) > RollCooldownTime;
        //Debug.Log("curr time: " + Time.time + ", TimeOfLastRoll: " + TimeOfLastRoll + " RollCooldownTime: " + RollCooldownTime);
        if (inputHandler.GetRollInputDown() && RollAvailable) {
            TimeOfLastRoll = Time.time;

            //thrust player forward physically
            rb.AddForce(inputHandler.GetMoveInput() * 2000, ForceMode2D.Force);
            StartCoroutine(BecomeInvulnerableForTime());
        }
        
    }


    //coroutine - become invulnerable for an amount of time
    //also sets player back to being vulnerable once time is over
    IEnumerator BecomeInvulnerableForTime() {

        //****NOTE: NEED PLAYER AND OBJECTS THAT THE PLAYER IS INVULNERABLE FROM TO HAVE LAYERS(SET IN UNITY INSPECTOR)
        Physics2D.IgnoreLayerCollision(8, 9, true); //set player invulnerable to bullets/enemy-fire
        Debug.Log("Player is now invulnerable");
        yield return new WaitForSeconds(RollInvulnerabilityTime);
        Debug.Log("Player is vulnerable again");
        //set player back to being invulnerable
        Physics2D.IgnoreLayerCollision(8, 9, true); //set player back to being vulnerable to bullets/enemy-fire

    }


    private void TestInputCommands() {
         
         
        if (inputHandler.GetFireInputDown()) {
            Debug.Log("fire pressed");
        }

        //if (inputHandler.GetFireInputHeld())
        //{
        //    Debug.Log("fire held");
        //}

        //if (inputHandler.GetFireInputUp())
        //{
        //    Debug.Log("fire stopped");
        //}


        //if (inputHandler.GetMeleeInputDown())
        //{
        //    Debug.Log("melee pressed");
        //}

        //if (inputHandler.GetMeleeInputHeld())
        //{
        //    Debug.Log("melee held");
        //}

        //if (inputHandler.GetMeleeInputUp())
        //{
        //    Debug.Log("melee stopped");
        //}



        //if (inputHandler.GetRollInputDown())
        //{
        //    Debug.Log("roll pressed");
        //}

        //if (inputHandler.GetRollInputHeld())
        //{
        //    Debug.Log("roll held");
        //}

        //if (inputHandler.GetRollInputUp())
        //{
        //    Debug.Log("roll stopped");
        //}

        //if (inputHandler.GetInteractInputDown())
        //{
        //    Debug.Log("interact pressed");
        //}

        //if (inputHandler.GetInteractInputHeld())
        //{
        //    Debug.Log("interact held");
        //}

        //if (inputHandler.GetInteractInputUp())
        //{
        //    Debug.Log("interact stopped");
        //}
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
        
        displacement = /*playerStats.speed*/ 10f * moveSpeedMultiplier * inputHandler.GetMoveInput();
        crosshairPos = crosshairScript.GetCrosshairPos();
    }

    //physics
    void FixedUpdate() {
        
        //actually change the position of the character
        //still a lil' confused by Time.fixedDeltaTime, but I'll figure it out later
        rb.MovePosition(rb.position + displacement * Time.fixedDeltaTime);

        ShiftCamera();

    }







}