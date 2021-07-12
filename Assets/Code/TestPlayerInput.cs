using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class TestPlayerInput : MonoBehaviour
{
    private PlayerInputHandler input;
    private Vector2 prevLookInput = Vector2.zero;
    private Vector2 prevMoveInput = Vector2.zero;

    private void Start()
    {
        input = GetComponent<PlayerInputHandler>();
        input.OnRollInputDown.AddListener(PrintOnRollDown);
        input.OnRollInputUp.AddListener(PrintOnRollUp);
        input.OnShootInputDown.AddListener(PrintOnShootDown);
        input.OnShootInputUp.AddListener(PrintOnShootUp);
        input.OnReloadInputDown.AddListener(PrintOnReloadDown);
        input.OnReloadInputUp.AddListener(PrintOnReloadUp);
        input.OnMeleeInputDown.AddListener(PrintOnMeleeDown);
        input.OnMeleeInputUp.AddListener(PrintOnMeleeUp);
        input.OnInteractInputDown.AddListener(PrintOnInteractDown);
        input.OnInteractInputUp.AddListener(PrintOnInteractUp);
    }

    private void Update()
    {
        if (input.LookInput != prevLookInput)
        {
            print("Look input: " + input.LookInput);
        }
        prevLookInput = input.LookInput;

        if (input.MoveInput != prevMoveInput)
        {
            print("Move input: " + input.MoveInput);
        }
        prevMoveInput = input.MoveInput;
    }


    public void PrintOnRollDown()
    {
        print("Roll input down");
    }

    public void PrintOnRollUp(double duration)
    {
        print("Roll input up, duration: " + duration);
    }


    public void PrintOnShootDown()
    {
        print("Shoot input down");
    }

    public void PrintOnShootUp(double duration)
    {
        print("Shoot input up, duration: " + duration);
    }


    public void PrintOnReloadDown()
    {
        print("Reload input down");
    }

    public void PrintOnReloadUp(double duration)
    {
        print("Reload input up, duration: " + duration);
    }


    public void PrintOnMeleeDown()
    {
        print("Melee input down");
    }

    public void PrintOnMeleeUp(double duration)
    {
        print("Melee input up, duration: " + duration);
    }


    public void PrintOnInteractDown()
    {
        print("Interact input down");
    }

    public void PrintOnInteractUp(double duration)
    {
        print("Interact input up, duration: " + duration);
    }
}
