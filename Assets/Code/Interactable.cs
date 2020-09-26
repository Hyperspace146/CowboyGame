using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteOutline))]
public class Interactable : MonoBehaviour
{
    // Other scripts attached to the same object will subscribe and customize the effects/events 
    // of this interactable
    public event UnityAction<GameObject> OnInteract;

    private SpriteOutline spriteOutline;

    void Start()
    {
        spriteOutline = GetComponent<SpriteOutline>();
    }

    // If in range of the interactable and the player inputs Interact, invoke any OnInteract stuff
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerInputHandler playerInput = collision.GetComponent<PlayerInputHandler>();
        if (playerInput != null && playerInput.GetInteractInputDown() && OnInteract != null)
        {
            OnInteract.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteOutline.Color = Color.yellow;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteOutline.Color = Color.white;
    }

}
