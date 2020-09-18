using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {


    //we need an instance of the input system asset that we made
    PlayerControls controls;
    Vector2 move;
    Vector2 crossHair;


    //***bool down = Input.GetButtonDown("Jump"); ---> check if key is pressed(after first press, returns to false)
    //  Input.GetButton("Jump"); --> check if key is being held down
    //  Input.GetUp("Jump");
    
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
        //Debug.Log("input coordinates: " + crossHair.x + " " + crossHair.y);
   }


/*
    //Vector2 GetMoveInput(): returns the input axis for movement in Vector2 form 
    //we don't need to worry about speed here; we'll multiply the vector2D value
    //by this method's return value at the location which we call this method
    public Vector2 GetMoveInput() {

        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    //float GetLookInputHorizontal(): returns the value of the axis for looking/aiming (mouse or controller stick)
    public Vector2 GetLookInput() {
        //return GetMouseOrStickLookAxis(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"));

        //get screen position of mouse in pixel coordinates
        //but game doesn't use pixel coordinates, it uses in-game units
        //so, we must convert the value of Input.mousePosition from a screen point
        //to a world point. We'll use our camera to achieve this
        return cam.ScreenToWorldPoint(Input.mousePosition);

    }

    //bool GetRollInputDown(): returns true when the roll button is initially pressed down
    public bool GetRollInputDown() {
        return Input.GetButtonDown("Roll");
    }

   // bool GetRollInputHeld(): returns true when the roll button is currently pressed down
    public bool GetRollInputHeld() {
        return Input.GetButton("Roll");
    }

   // bool GetRollInputUp(): returns true when the roll button is released
    public bool GetRollInputUp() {
        return Input.GetButtonUp("Roll");
    }

   // bool GetFireInputDown(): returns true when the shoot button is initially pressed down
    public bool GetFireInputDown() {
        return Input.GetButtonDown("Fire1");
    }

    public bool GetFireInputHeld() {
        return Input.GetButton("Fire1");
    }

    public bool GetFireInputUp() {
        return Input.GetButtonUp("Fire1");
    }

       // bool GetAltFireInputHeld(): returns true when the shoot button is currently pressed down
   // bool GetFireInputUp(): returns true when the shoot button is released
   // bool GetAltFireInputDown(): returns true when the alternate shoot button is initially pressed down
   // bool GetAltFireInputHeld(): returns true when the alternate shoot button is currently pressed down
  //  bool GetAltFireInputUp(): returns true when the alternate shoot button is released



  //  bool GetMeleeInputDown(): returns true when the melee button is initially pressed down
    public bool GetMeleeInputDown() {
        return Input.GetButtonDown("Melee");
    }

  //  bool GetMeleeInputHeld(): returns true when the melee button is currently pressed down
    public bool GetMeleeInputHeld() {
        return Input.GetButton("Melee");
    }

 //   bool GetMeleeInputUp(): returns true when the melee button is released
    public bool GetMeleeInputUp() {
        return Input.GetButtonUp("Melee");
    }

 //   bool GetAbilityInputDown(): returns true when the ability button is initially pressed down
    public bool GetAbilityInputDown() {
        return Input.GetButtonDown("Ability");
    }

  //  bool GetAbilityInputHeld(): returns true when the ability button is currently pressed down
    public bool GetAbilityInputHeld() {
        return Input.GetButton("Ability");
    }
  //  bool GetAbilityInputUp(): returns true when the ability button is released
    public bool GetAbilityInputUp() {
        return Input.GetButtonUp("Ability");
    }

  //  bool GetInteractInputDown(): returns true when the interact button is initially pressed down
    public bool GetInteractInputDown() {
        return Input.GetButtonDown("Interact");
    }
  //  bool GetInteractInputHeld(): returns true when the interact button is currently pressed down
    public bool GetInteractInputHeld() {
        return Input.GetButton("Interact");
    }
  //  bool GetInteractInputUp(): returns true when the interact button is released
    public bool GetInteractInputUp() {
        return Input.GetButtonUp("Interact");
    }




    */



}