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
    
    public Vector2 GetLookInput() {
        return crossHair;
    }

    void Update() {
        DetectInput();
    }

    //this method is responsible for updating our move and rotate values according to input
    private void DetectInput() {
       
                                                       

        DetectMoveInput();
        DetectCrosshairInput();
        DetectShootInput();
        DetectInteractInput();
        DetectRollInput();


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
        controls.Gameplay.PressShoot.canceled += context => shootPressed = false;
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
        controls.Gameplay.PressMelee.canceled += context => meleePressed = false;
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
        controls.Gameplay.PressInteract.canceled += context => interactPressed = false;
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



   }





}