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

        controls.Gameplay.Rotate.performed += context => crossHair = context.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += context => crossHair = Vector2.zero;//new Vector2(1f, 1f); //reset value when not moving thumbstick

        DetectShootInput();
        DetectInteractInput();
        DetectRollInput();

   }


   private void DetectShootInput() {
       controls.Gameplay.Shoot.started += context => shootPressed = true;
       controls.Gameplay.Shoot.performed += context => shootHeldDown = true;
       controls.Gameplay.Shoot.canceled += context => shootPressed = false;
       controls.Gameplay.Shoot.canceled += context => shootHeldDown = false;
   }

   public bool GetFireInputDown() {
       return shootPressed;
   }

   public bool GetFireInputHeld() {
       return shootHeldDown;
   }

   public bool GetFireInputUp() {
       return !shootPressed;
   }


   private void DetectInteractInput() {


   }

   private void DetectRollInput() {



   }





}