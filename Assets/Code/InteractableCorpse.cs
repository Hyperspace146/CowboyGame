using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerCharacterController))]
public class InteractableCorpse : MonoBehaviour
{
    [Tooltip("Move speed debuff applied to the player that carries this corpse. Negative number.")]
    public int MoveSpeedDebuff = -5;
    [Tooltip("Sprite outline material needed to when turning the player into an interactable. Go look in the Materials folder")]
    public Material SpriteOutlineMaterial;

    private BoxCollider2D corpseCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        GetComponent<Health>().OnDeath += TurnPlayerIntoCorpse;

        corpseCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // This method is subscribed to the player's death. Once they die, disable player control and
    // enable components to turn the player object into an interactable
    void TurnPlayerIntoCorpse()
    {
        Debug.Log("corpse");

        // Turn the player object into an interactable object
        gameObject.AddComponent<SpriteOutline>();
        gameObject.AddComponent<Interactable>().OnInteract += PickUpCorpse;
        spriteRenderer.material = SpriteOutlineMaterial;

        // Also make the collider bigger and turn it into a trigger (rather than solid hitbox)
        corpseCollider.isTrigger = true;
        corpseCollider.size = corpseCollider.size + new Vector2(5, 5);
    }

    // This method is subscribed to when another player is in range of and interacts with the corpse
    void PickUpCorpse(GameObject playerPickingUp)
    {
        Debug.Log("picked up");

        //playerPickingUp.GetComponent<PlayerCharacterController>().CorpseBeingCarried = this;

        // TODO: play corpse pickup animation

        // Actually, just turn the sprite off loam and turn off the collider
        spriteRenderer.enabled = false;
        corpseCollider.enabled = false;

        // Lower the move speed of the player picking up
        playerPickingUp.GetComponent<PlayerStats>().ChangeSpeedStat(MoveSpeedDebuff);
    }

    // While the other player is shouldering the corpse, wait until they input to put it down
    public void DropCorpse(GameObject playerHoldingThisCorpse)
    {
        Debug.Log("dropped");

        // Once the player with the corpse inputs, drop the corpse and reenable the corpse's collider and 
        // undo their move speed debuff
        // TODO: deal with placing the corpse in wall or something and placing where the player is facing
        gameObject.transform.position = playerHoldingThisCorpse.transform.position + new Vector3(2, 0, 0);
        spriteRenderer.enabled = true;
        corpseCollider.enabled = true;
        playerHoldingThisCorpse.GetComponent<PlayerStats>().ChangeSpeedStat(-MoveSpeedDebuff);
    }
}
