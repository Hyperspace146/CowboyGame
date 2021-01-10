using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats), typeof(PlayerInputHandler), typeof(PlayerMelee))]
[RequireComponent(typeof(Crosshair), typeof(Rigidbody2D))]

public class PlayerCharacterController : MonoBehaviour {

    public Rigidbody2D rb;
    public Transform cam; //Transform provides information about position, rotation, and scale

    private Vector2 displacement;
    private Vector2 rotation;
    private Vector2 crosshairPos;
    private float moveSpeedMultiplier = 0.5f;

    private PlayerInputHandler inputHandler; //get the inputhandler script so we have access to its methods from here
    private PlayerStats playerStats;
    private PlayerMelee playerMelee;
    private PlayerWeaponManager playerWeaponManager;
    private GameObject crosshair;
    private Crosshair crosshairScript;

    public float RollInvulnerabilityTime; //time that player is invulnerable while rolling
    public float RollCooldownTime;
    public float RollDistance;
    private float TimeOfLastRoll;
    private bool RollAvailable;

    public bool PlayerControlEnabled;
    public bool PlayerActionsEnabled;

    void Start() {

        RollInvulnerabilityTime = .4f;
        RollCooldownTime = 2f;
        RollDistance = 3f;
        //Debug.Log(RollCooldownTime + " " + RollInvulnerabilityTime + " " + RollDuration);
        
        PlayerControlEnabled = true;
        PlayerActionsEnabled = true;
        TimeOfLastRoll = float.NegativeInfinity; //this is so we have a roll available from the start
        //store the player's playerinputhandler script here
        //so that we have access to its methods
 
        inputHandler = GetComponent<PlayerInputHandler>();
        playerStats = GetComponent<PlayerStats>();
        playerMelee = GetComponent<PlayerMelee>();
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
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

            if (PlayerActionsEnabled)
            {
                HandleCharacterActions();
            }
            TestInputCommands();
        }

        
       
    }

    void HandleCharacterActions() {
        
        //ROLL | JOSEPH 
        RollAvailable = (Time.time - TimeOfLastRoll) > RollCooldownTime;
        //Debug.Log("curr time: " + Time.time + ", TimeOfLastRoll: " + TimeOfLastRoll + " RollCooldownTime: " + RollCooldownTime);
        if (inputHandler.GetRollInputDown() && RollAvailable)
        {

            //Cooldown
            TimeOfLastRoll = Time.time;
            
            //Performing the roll
            if(displacement.magnitude != 0) {
                StartCoroutine(rollEffects(true));
            }
            else {
                StartCoroutine(rollEffects(false));
            }
            
            //rb.AddForce(inputHandler.GetMoveInput() * RollDistance, ForceMode2D.Force);

        }

        // Melee
        if (inputHandler.GetMeleeInputDown())
        {
            playerMelee.MeleeAttack();
        }

        // Shooting
        if (inputHandler.GetFireInputHeld())
        {
            playerWeaponManager.TryShoot();                               
        }

        // Reloading
        if (inputHandler.GetReloadWeaponHeldDown())
        {
            playerWeaponManager.TryReloadWeapon();
        }

    }

    //coroutine - become invulnerable for an amount of time
    //also sets player back to being vulnerable once time is over
    IEnumerator rollEffects(bool isMoving) {
            
            /*
             * Zero the dispacement vector while movement is disabled
             * Manually set the velocity (rb.velocity) based on last inputed direction (roll in the direction of corsshair for now)
             * Reset the velocity, and unzero the displacement
            */
        
        //zero the displacement
        

        //****NOTE: NEED PLAYER AND OBJECTS THAT THE PLAYER IS INVULNERABLE FROM TO HAVE LAYERS(SET IN UNITY INSPECTOR)
        Physics2D.IgnoreLayerCollision(8, 9, true); //set player invulnerable to bullets/enemy-fire
        Debug.Log("Player is now invulnerable");
        PlayerControlEnabled = false; PlayerActionsEnabled = false;

        //velocity applied
        if (isMoving) {
            rb.velocity = displacement.normalized * (RollDistance / RollInvulnerabilityTime);
        }
        else {
            Vector2 crosshairDir = (inputHandler.GetMousePosition() -
                (Vector2) Camera.main.WorldToScreenPoint(rb.position));

            rb.velocity = crosshairDir.normalized * (RollDistance / RollInvulnerabilityTime);
        }

        yield return new WaitForSeconds(RollInvulnerabilityTime);


        Physics2D.IgnoreLayerCollision(8, 9, false); //set player back to being vulnerable to bullets/enemy-fire
        Debug.Log("Player is vulnerable again");
        PlayerControlEnabled = true; PlayerActionsEnabled = true;

    }

    private void TestInputCommands() {


        /*  // if (inputHandler.GetFireInputDown()) {
         //     Debug.Log("fire pressed");
         // } */

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
        //   Debug.Log("melee pressed");
        //}

        //if (inputHandler.GetMeleeInputHeld())
        //{
        //   Debug.Log("melee held");
        //}

        //if (inputHandler.GetMeleeInputUp())
        //{
        //   Debug.Log("melee stopped");
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


        if (inputHandler.GetReloadWeaponHeldDown())
        {
            Debug.Log("reload held");
        }

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
        if(PlayerControlEnabled == true) 
        {
            rb.MovePosition(rb.position + displacement * Time.fixedDeltaTime);
        }
        ShiftCamera();

    }







}