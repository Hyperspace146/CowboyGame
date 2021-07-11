using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
    /* Represents the direction the player wishes to move in. */
    public Vector2 MoveInput { get; private set; } = Vector2.zero;

    /* The vector pointing from the player character to the crosshair. Normalized. */
    public Vector2 LookInput { get; private set; } = Vector2.zero;  

    public UnityEvent OnRollInputDown;
    public UnityEvent OnRollInputHeld;
    public UnityEvent<double> OnRollInputUp;
    public UnityEvent OnShootInputDown;
    public UnityEvent OnShootInputHeld;
    public UnityEvent<double> OnShootInputUp;
    public UnityEvent OnReloadInputDown;
    public UnityEvent OnReloadInputHeld;
    public UnityEvent<double> OnReloadInputUp;
    public UnityEvent OnMeleeInputDown;
    public UnityEvent OnMeleeInputHeld;
    public UnityEvent<double> OnMeleeInputUp;
    public UnityEvent OnInteractInputDown;
    public UnityEvent OnInteractInputHeld;
    public UnityEvent<double> OnInteractInputUp;
    public Transform ShootPoint;  /* The location that the bullets spawn from. */

    public bool ActionInputEnabled = true;
    public bool MoveInputEnabled = true;

    private bool rollInputHeld;
    private bool shootInputHeld;
    private bool reloadInputHeld;
    private bool meleeInputHeld;
    private bool interactInputHeld;

    private void Update()
    {
        if (rollInputHeld && OnRollInputHeld != null)
            OnRollInputHeld.Invoke();
        if (shootInputHeld && OnShootInputHeld != null)
            OnShootInputHeld.Invoke();
        if (reloadInputHeld && OnReloadInputHeld != null)
            OnReloadInputHeld.Invoke();
        if (meleeInputHeld && OnMeleeInputHeld != null)
            OnMeleeInputHeld.Invoke();
        if (interactInputHeld && OnInteractInputHeld != null)
            OnInteractInputHeld.Invoke();
    }

    public void SetMoveInput(CallbackContext callbackContext)
    {
        MoveInput = callbackContext.ReadValue<Vector2>();
    }

    /* 
     * Determines the normalized Vector2 representing which direction the character is aiming
     * in. Requires additional calculation based on what kind of device was used for input.
     */
    public void SetLookInput(CallbackContext callbackContext)
    {
        // If current controller is mouse and keyboard, then the callback's Vector2 represents the 
        // mouse's absolute position. Subtract to find the vector pointing from the player to 
        // the mouse's position.
        if (callbackContext.control.device.name == "Mouse")
        {
            LookInput = (Vector2) Camera.main.ScreenToWorldPoint(callbackContext.ReadValue<Vector2>())
                - (Vector2) ShootPoint.transform.position;
        }
        // If gamepad, then the Vector2 should be the stick's input, (0,0) being the stick at neutral.
        // No need for more calculation (needs testing to see if this is right)
        else if (callbackContext.control.device.name == "Gamepad")
        {
            LookInput = callbackContext.ReadValue<Vector2>();
        }
        else
        {
            Debug.LogWarning("Unsupported device found setting character look input.");
        }
    }


    /* 
     *      ----------- ACTIONS -----------
     */
    public void SetRollInput(CallbackContext callbackContext)
    {
        // This applies to all the action callbacks: if a call
        if (ActionInputEnabled)
        {
            if (callbackContext.started && OnRollInputDown != null)
                OnRollInputDown.Invoke();
            else if (callbackContext.canceled && OnRollInputUp != null)
                OnRollInputUp.Invoke(callbackContext.duration);
            rollInputHeld = callbackContext.started || !callbackContext.canceled;
        }
        // issue: called multiple time per button press+release, so up is invoked multiple times
        else if (callbackContext.phase != InputActionPhase.Waiting)
        {
            OnInteractInputUp.Invoke(callbackContext.duration);
        }
    }

    public void OnShootInput(CallbackContext callbackContext)
    {
        if (callbackContext.started && OnShootInputDown != null)
            OnShootInputDown.Invoke();
        else if (callbackContext.canceled && OnShootInputUp != null)
            OnShootInputUp.Invoke(callbackContext.duration);
        shootInputHeld = callbackContext.started || !callbackContext.canceled;
    }

    public void SetReloadInput(CallbackContext callbackContext)
    {
        if (callbackContext.started && OnReloadInputDown != null)
            OnReloadInputDown.Invoke();
        else if (callbackContext.canceled && OnReloadInputUp != null)
            OnReloadInputUp.Invoke(callbackContext.duration);
        reloadInputHeld = callbackContext.started || !callbackContext.canceled;
    }

    public void SetMeleeInput(CallbackContext callbackContext)
    {
        if (callbackContext.started && OnMeleeInputDown != null)
            OnMeleeInputDown.Invoke();
        else if (callbackContext.canceled && OnMeleeInputUp != null)
            OnMeleeInputUp.Invoke(callbackContext.duration);
        meleeInputHeld = callbackContext.started || !callbackContext.canceled;
    }

    public void SetInteractInput(CallbackContext callbackContext)
    {
        if (callbackContext.started && OnInteractInputDown != null)
            OnInteractInputDown.Invoke();
        else if (callbackContext.canceled && OnInteractInputUp != null)
            OnInteractInputUp.Invoke(callbackContext.duration);
        interactInputHeld = callbackContext.started || !callbackContext.canceled;
    }
}
