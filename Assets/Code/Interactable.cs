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

    // Method called by the player gameobject that is interacting with this interactable
    public void Interact(GameObject playerInteracting)
    {
        if (OnInteract != null)
        {
            OnInteract.Invoke(playerInteracting);
        }
    }
}
