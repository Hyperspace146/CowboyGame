using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {

    //we need an instance of the input system asset that we made
    PlayerControls controls;
    Vector2 move;
    Vector2 crossHair;

    private bool shootPressed;
    private bool shootHeldDown;

    private bool meleePressed;
    private bool meleeHeld;

    private bool interactPressed;
    private bool interactHeld;

    private bool rollPressed;
    private bool rollHeld;

    private bool ReloadPressed;

    //PlayerInputHandler - handles inputs and applies things like sensitivity, invert, etc. 
    //***these methods will be called within an update() method of another class

    //awake() is called even before start is called
    void Awake() {
        
        controls = new PlayerControls();            
        controls.Gameplay.Enable(); //starts the controls

    }

    public Vector2 GetMoveInput() {
        return move;
    }
    
    public Vector2 GetMousePosition() {
        return crossHair;
    }

    // Returns the vector pointing from the player's position to the crosshair in screenspace.
    public Vector2 GetLookInput()
    {
        return GetMousePosition() - (Vector2) Camera.main.WorldToScreenPoint(transform.position);
    }

    void Update() {
        DetectInput();

        //reset the "pressed" variables to false at this point
        //(We want the "pressed" variables to only be true for one frame)
        resetPressedButtons();

    }

    void resetPressedButtons() {
        shootPressed = false;
        meleePressed = false;
        interactPressed = false;
        rollPressed = false;
    }

    //this method is responsible for updating our move and rotate values according to input
    private void DetectInput() {
       
        DetectMoveInput();
        DetectCrosshairInput();
        DetectMeleeInput();
        DetectShootInput();
        DetectInteractInput();
        DetectRollInput();
        DetectReload();

   }

   private void DetectMoveInput() {
                                                           //context provides information from thumbstick(player input)
        controls.Gameplay.Move.performed += context => move = context.ReadValue<Vector2>();
              //.Actionmap.Action 
                               //Callbacks: 
                               //.started
                               //.performed
                               //.canceled
        //those three are callbacks, which means we can "add" functions/methods
        //to them which get triggered when the action is performed        
        controls.Gameplay.Move.canceled += context => move = Vector2.zero; //reset value when not moving thumbstick

   }

   private void DetectCrosshairInput() {
        controls.Gameplay.Rotate.performed += context => crossHair = context.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += context => crossHair = Vector2.zero;//new Vector2(1f, 1f); //reset value when not moving thumbstick
   }

   private void DetectShootInput() {

        controls.Gameplay.PressShoot.started += context => shootPressed = true;
        controls.Gameplay.HoldShoot.performed += context => shootHeldDown = true;
        controls.Gameplay.HoldShoot.canceled += context => shootHeldDown = false;

   }

   public bool GetFireInputDown() {
       return shootPressed;
   }

   public bool GetFireInputHeld() {
       return shootHeldDown;
   }

   public bool GetFireInputUp() {
       return !shootPressed && !shootHeldDown;
   }

   private void DetectMeleeInput() {
  
        controls.Gameplay.PressMelee.started += context => meleePressed = true; 
        controls.Gameplay.HoldMelee.performed += context => meleeHeld = true;
        controls.Gameplay.HoldMelee.canceled += context => meleeHeld = false;

   } 

   public bool GetMeleeInputDown() {
       return meleePressed;
   }

   public bool GetMeleeInputHeld() {
       return meleeHeld;
   }

   public bool GetMeleeInputUp() {
       return !meleePressed && !meleeHeld;
   }

   private void DetectInteractInput() {
        controls.Gameplay.PressInteract.started += context => interactPressed = true;
        controls.Gameplay.HoldInteract.performed += context => interactHeld = true;
        controls.Gameplay.HoldInteract.canceled += context => interactHeld = false;
   }

   public bool GetInteractInputDown() {
       return interactPressed;
   }

   public bool GetInteractInputHeld() {
       return interactHeld;
   }

   public bool GetInteractInputUp() {
       return !interactPressed && !interactHeld;
   }

   private void DetectRollInput() {
        controls.Gameplay.PressRoll.started += context => rollPressed = true;
        controls.Gameplay.HoldRoll.performed += context => rollHeld = true;
        controls.Gameplay.HoldRoll.canceled += context => rollHeld = false;
   }

   public bool GetRollInputDown() {
       return rollPressed;
   }

   public bool GetRollInputHeld() {
       return rollHeld;
   }

   public bool GetRollInputUp() {
       return !rollPressed && !rollHeld;
   }

   private void DetectReload() {
        
        controls.Gameplay.HoldReload.performed += context => ReloadPressed = true;
        controls.Gameplay.HoldReload.canceled += context => ReloadPressed = false;

   }

   public bool GetReloadWeaponHeldDown() {
       return ReloadPressed;
   }





}