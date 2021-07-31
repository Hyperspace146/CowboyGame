using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Gives the player the ability to interact with interactable objects.
 */
public class PlayerInteract : MonoBehaviour
{
    // A list that contains all the interactable objects currently in range of the player
    private List<Interactable> interactablesInRange = new List<Interactable>();

    // The interactable closest to the player out of all interactables in range (should be indicated by
    // something like a yellow outline)
    private Interactable closestInteractable;

    private PlayerInputHandler input;

    private void Start()
    {
        input = GetComponent<PlayerInputHandler>();

        input.OnInteractInputDown.AddListener(InteractWithClosestInteractable);
    }

    public void Interact()
    {
        // Interact with the interactable closest to us
        if (closestInteractable != null && input.PlayerActionsEnabled)
        {
            closestInteractable.Interact(gameObject);
            closestInteractable = null;
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
        // While we are in range of at least one interactable, update the closest interactable and make that one
        // the only one the player is able to interact with. As a visual indicator, change 
        // its sprite outline color to yellow, while other interactables are white
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

            // Change the closest interactable's outlines, and make only the closest one interactable
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
        else
        {
            closestInteractable = null;
        }
    }

    private void InteractWithClosestInteractable()
    {
        if (closestInteractable != null)
        {
            closestInteractable.Interact(this.gameObject);
        }
    }
}
