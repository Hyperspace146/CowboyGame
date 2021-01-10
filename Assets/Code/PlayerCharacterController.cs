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

    public InteractableCorpse CorpseBeingCarried;       // reference to the corpse object that this player is carrying
    private List<Interactable> interactablesInRange;    // A list that contains all the interactable objects currently in range of the player
    private Interactable closestInteractable;           // The interactable closest to the player out of all interactables in range (will have yellow outline)

    void Start() {

        RollInvulnerabilityTime = .4f;
        RollCooldownTime = 2f;
        RollDistance = 3f;
        //Debug.Log(RollCooldownTime + " " + RollInvulnerabilityTime + " " + RollDuration);
        
        //Manually set the Z pos so that the player is always in front of the background
        transform.position = new Vector3(transform.position.x, transform.position.y, 19);

        CorpseBeingCarried = null;
        interactablesInRange = new List<Interactable>();
        
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

        // Interacting (includes interacting and dropping corpses)
        if (inputHandler.GetInteractInputDown())
        {
            Debug.Log("interact");
            // Interact with the interactable closest to us
            if (closestInteractable != null)
            {
                closestInteractable.Interact(gameObject);
                closestInteractable = null;
            }

            // If there is no interactable in range, and we are carrying a corpse, drop it
            else if (CorpseBeingCarried != null)
            {
                CorpseBeingCarried.DropCorpse(gameObject);
                CorpseBeingCarried = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is an interactable; if so, add it to the list of interactables in range
        Interactable interactable = collision.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Remove the interactable (if it is one) from the list of interactables in range
        Interactable interactable = collision.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactablesInRange.Remove(interactable);
            interactable.GetComponent<SpriteOutline>().Color = Color.white;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //// We check if the collider is an interactable, and if so, check if interact button is pressed
        //// so we can interact with it
        //// sidenote: getinteractinputdown is unreliable for some reason, so input held is used instead
        //Interactable interactable = collision.GetComponent<Interactable>();
        //if (interactable != null && PlayerActionsEnabled && inputHandler.GetInteractInputDown())
        //{
        //    interactable.Interact(gameObject);
        //}

        // While we are in range of at least one interactable, change the sprite outline color of only the closest 
        // interactable to yellow, the others being white
        if (interactablesInRange.Count >= 1)
        {
            // Find the interactable closest to us
            closestInteractable = interactablesInRange[0];
            float closestDistance = (interactablesInRange[0].transform.position - transform.position).magnitude;
            for (int i = 1; i < interactablesInRange.Count; i++)
            {
                float distance = (interactablesInRange[i].transform.position - transform.position).magnitude;
                if (distance < closestDistance)
                {
                    closestInteractable = interactablesInRange[i];
                    closestDistance = distance;
                }
            }

            // Change the closest interactable's outline to yellow while keeping the others white
            foreach (Interactable inter in interactablesInRange)
            {
                if (inter.Equals(closestInteractable))
                {
                    inter.GetComponent<SpriteOutline>().Color = Color.yellow;
                }
                else
                {
                    inter.GetComponent<SpriteOutline>().Color = Color.white;
                }
            }
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

        cam.transform.position = new Vector3(xPos, yPos, -10);
       
    }
    
    void HandleCharacterMovement() {
        
        displacement = /*playerStats.speed*/ 10f * moveSpeedMultiplier * inputHandler.GetMoveInput();
        crosshairPos = crosshairScript.GetCrosshairPos();
    }

    private void TestInputCommands() {
         
         
        //if (inputHandler.GetFireInputDown()) {
        //    Debug.Log("fire pressed");
        //} 

        //if (inputHandler.GetFireInputHeld())
        //{
        //   Debug.Log("fire held");
        //}

        //if (inputHandler.GetFireInputUp())
        //{
        //   Debug.Log("fire stopped");
        //}

        /*
        if (inputHandler.GetMeleeInputDown())
        {
           Debug.Log("melee pressed");
        }

        //if (inputHandler.GetMeleeInputHeld())
        //{
        //   Debug.Log("melee held");
        //}

        if (inputHandler.GetMeleeInputUp())
        {
           Debug.Log("melee stopped");
        }
        */


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