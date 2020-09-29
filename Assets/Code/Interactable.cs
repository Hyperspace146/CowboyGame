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

<<<<<<< HEAD

    public Pickup PickupScript;
    public static Interactable script;

    public event Action InteractableInRange;



    public void InvokePickupEffect() {

        //Invoke the chinese exclusion act effect on player


    }


    private void Awake() {
        script = this;
=======
    private SpriteOutline spriteOutline;

    void Start()
    {
        spriteOutline = GetComponent<SpriteOutline>();
>>>>>>> db20a7632f600a6f509935bfe9656c766d5c0333
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

<<<<<<< HEAD
    //trigger event as "happened" if player touches
    private void OnTriggerStay2D(Collider2D other) {

        //call the event system and tell it to dispatch the event
        script.OnInteractableTriggerPlayerAbilityToInteract();
    }




    // Start is called before the first frame update
    void Start()
=======
    private void OnTriggerEnter2D(Collider2D collision)
>>>>>>> db20a7632f600a6f509935bfe9656c766d5c0333
    {
        spriteOutline.Color = Color.yellow;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteOutline.Color = Color.white;
    }

}
